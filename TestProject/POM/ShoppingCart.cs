using DemoWebShopAutomationHW;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.POM
{
    public class ShoppingCart : IWebDriverShell
    {
        private static readonly By _emptyShoppingCart = By.XPath("//div[@class='order-summary-content']");
        private static readonly By _termsOfServiceCheckBox = By.Id("termsofservice");
        private static readonly By _checkoutBtn = By.XPath("//button[@class='button-1 checkout-button']");

        public string EmptyShoppingCart() => FindElement(_emptyShoppingCart).Text;
        public void TemsOfServiceCheckout() => FindElement(_termsOfServiceCheckBox).Click();
        public void CheckOutBtnClick() => FindElement(_checkoutBtn).Click();
    }
}
