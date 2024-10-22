using LambdatestEcom.Pages;
using System;
using TechTalk.SpecFlow;

namespace LambdatestEcom.Steps 
{ 

    [Binding]
    public class ExistingUserTestsStepDefinitions : UITestFixture
{
        public ExistingUserTestsStepDefinitions() : base(false)
        {
        }

        [Given(@"open home page")]
        public async Task GivenOpenHomePageAsync()
        {
            var homePage = new HomePage(page);
            await homePage.Open();
        }

        [Given(@"open My account")]
        public async Task GivenOpenMyAccount()
        {
            var homePage = new HomePage(page);
            await homePage.OpenMyAccount();
        }
    }
}
