using LambdatestEcom.Pages;
using System;
using TechTalk.SpecFlow;

namespace LambdatestEcom.Steps

    [Binding]
    public class ExistingUserTestsStepDefinitions : UITestFixture
{
        [Given(@"open home page")]
        public void GivenOpenHomePage()
        {
            var homePage = new HomePage(page);
        }

        [Given(@"open My account")]
        public void GivenOpenMyAccount()
        {
            throw new PendingStepException();
        }
    }
}
