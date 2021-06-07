using DemoWebShopAutomationHW;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.POM
{
    public class CompareProductsPage : IWebDriverShell
    {
        private static readonly By _productPrice = By.XPath("//tr[@class='product-price']//td[@class='a-center']");

        public string ProductPrice() => FindElement(_productPrice).Text;
    }
}
