using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace PlayWrightWs
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class ExampleTest : UITestFixture
    {
        [Test]
        public async Task HasTitle()
        {
            Console.WriteLine("start");


            /*
              --------------------------
            ws://localhost:52385/d7a5b1ce43a943cebdf6831703f64f3e/browserLinkSignalR/connect?transport=webSockets&connectionToken=AQAAANCMnd8BFdERjHoAwE%2FCl%2BsBAAAADuSEtdDm6U29VlmrhsDmiwAAAAACAAAAAAAQZgAAAAEAACAAAADI7AbCo4BIHUJ%2FwpEY0bi5JuGRdXAYhK7RVqmBFmmHagAAAAAOgAAAAAIAACAAAABpHbzAFJAxOXQZLDabylBbmb6ajt1fncpsMsbtiiAArDAAAACSd7WnpwXKTSiubc1OEmg4OFLXdXn4btumOO7CbgciT22fpvhYplnjyfphDuZrShtAAAAAY3IkhohP8gVzmYuICac%2FA6jTmC3KE9lgOQDlxOg7ycuvE5SsHDJqjTgPNuYZPCgDAOcwGCSub3i7L%2BJDW4s01A%3D%3D&requestUrl=https%3A%2F%2Flocalhost%3A44339%2Ftransaction&browserName=&userAgent=Mozilla%2F5.0+(Windows+NT+10.0%3B+Win64%3B+x64)+AppleWebKit%2F537.36+(KHTML%2C+like+Gecko)+Chrome%2F130.0.0.0+Safari%2F537.36&browserIdKey=window.browserLink.initializationData.browserId&browserId=9b49-f680&tid=8
            --------------------------
            wss://localhost:44339/_blazor?id=iUGxa5RCcIdtH0ZSmuTbzA
            --------------------------
            {"protocol":"blazorpack","version":1}
            --------------------------
            wss://localhost:44369/OpenBudgeteer.Blazor/

             */

            await Page.RouteWebSocketAsync(new Regex("ws://localhost:5.*"), ws =>
            {
                Console.WriteLine("ws.Url: " + ws.Url);
                try
                {
                    var server = ws.ConnectToServer();
                    ws.OnMessage(message =>
                    {
                        Console.WriteLine("OnMessage -->" + ws.Url);
                        ////Console.WriteLine(message.Text);
                        ////Console.WriteLine(message.Binary?.Length);
                        //if (message.Binary != null)
                        //{
                        //    server.Send(message.Binary);
                        //}
                        //else if (message.Text != null)
                        //{
                        //    server.Send(message.Text);
                        //}
                        //    //Console.WriteLine("END -------->");

                        //    server.OnMessage(message => {
                        //        Console.WriteLine("OnMessage <--" + ws.Url);
                        //        //Console.WriteLine(message.Text);
                        //        //Console.WriteLine(message.Binary?.Length);
                        //        if (message.Binary != null)
                        //        {
                        //            ws.Send(message.Binary);
                        //        }
                        //        else if (message.Text != null)
                        //        {
                        //            ws.Send(message.Text);
                        //        }
                        //        //Console.WriteLine("END <--------");
                        //    });
                        });
                    }
                catch (Exception ex)
                {
                    Console.WriteLine("0000000000000000000000000000000");
                    Console.WriteLine(ex.ToString());
                }

            });

            await Page.GotoAsync("https://localhost:44339/transaction");
            //await Page.PauseAsync();
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

                 



            await Page.GetByRole(AriaRole.Button, new() { Name = "Create Transaction" }).ClickAsync();
            await Page.GetByRole(AriaRole.Cell, new() { Name = "No Account" }).GetByRole(AriaRole.Combobox).SelectOptionAsync(new[] { "1b136143-eb38-480f-995a-4f33965fef16" });
            await Page.GetByRole(AriaRole.Spinbutton).First.ClickAsync();
            await Page.GetByRole(AriaRole.Spinbutton).First.FillAsync("10");
            await Page.GetByRole(AriaRole.Cell, new() { Name = "No Selection " }).GetByRole(AriaRole.Spinbutton).ClickAsync();
            await Page.GetByRole(AriaRole.Cell, new() { Name = "No Selection  Remaining" }).GetByRole(AriaRole.Spinbutton).FillAsync("10");
            await Page.GetByRole(AriaRole.Button, new() { Name = "" }).ClickAsync();
            await Assertions.Expect(Page.GetByRole(AriaRole.Cell, new() { Name = "$10.00" }).Nth(2)).ToBeVisibleAsync();


            // Expect a title "to contain" a substring.
            //await Assertions.Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
        }

        [Test]
        public async Task GetStartedLink()
        {
            await Page.RouteWebSocketAsync(new Regex(".*"), ws =>
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine(ws.Url);
                ws.OnMessage(message =>
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine(message.Text);
                    Console.WriteLine(message.Binary);
                    var server = ws.ConnectToServer();
                    ws.OnMessage(message => {
                        Console.WriteLine(message.Text);
                        server.Send(message.Binary);
                    });
                });
            });
            await Page.GotoAsync("https://echo.websocket.org/.ws");

            // Click the get started link.
            await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

            // Expects page to have a heading with the name of Installation.
            await Assertions.Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
        } 
    }
}
