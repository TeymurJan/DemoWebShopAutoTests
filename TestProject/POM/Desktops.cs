using DemoWebShopAutomationHW;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.POM
{
    public class Desktops : IWebDriverShell
    {
        private static readonly By _addToCartBtn = By.XPath("//div[@class='item-box']//input[@type='button']");

        public void AddToCartList() => FindElements(_addToCartBtn).First().Click();
    }
}
