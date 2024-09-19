using Atata;
using NUnit.Framework;
using System;

namespace AtataDemoQA
{
    public sealed class WebTablesTests : UITestFixture
    {
        [Test]
        public void Test()
        {
            Go.To<WebTablesPage>()
                .People
                .Rows[r => r.FirstName.Content.Value.Equals("Alden")].DeleteButton.Click();
        }

    }
}
