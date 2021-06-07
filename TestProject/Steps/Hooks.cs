using DemoWebShopAutomationHW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestProject.Steps
{
    [Binding]
    class Hooks : IWebDriverShell
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            ScenarioContext.Current["driver"] = CreateDriver();
            Navigate().GoToUrl(@"http://demowebshop.tricentis.com/");
        }
        [AfterScenario]
        public void AfterScenario() => Quit();
    }
}
