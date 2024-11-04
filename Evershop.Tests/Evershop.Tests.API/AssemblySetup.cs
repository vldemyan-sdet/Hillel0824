using Evershop.Tests.API.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evershop.Tests.API
{
    [SetUpFixture]
    public class AssemblySetup
    {
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            ApiConfigurationLoader.LoadConfiguration();
        }

        //[OneTimeTearDown]
        //public void GlobalTeardown()
        //{
        //    // Code that runs once after all tests in the assembly
        //    Console.WriteLine("Global teardown for the test assembly.");
        //    // Example: Clean up resources, close database connection, etc.
        //}
    }

}
