using DemoWebShopAutomationHW;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.POM
{
    class RegisterConfirmationPage : IWebDriverShell
    {
        private static readonly By _succesfullyRegistratedDiv = By.XPath("//div[@class='result']");

        public string SuccesfullyRegistrated() => FindElement(_succesfullyRegistratedDiv).Text;
    }
}
