using DemoWebShopAutomationHW;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.POM
{
    public class ItemPage : IWebDriverShell
    {
        private static readonly By _addToCartBtn = By.XPath("//input[@class='button-1 add-to-cart-button']");
        private static readonly By _addToCompareListBtn = By.XPath("//input[@class='button-2 add-to-compare-list-button']");
        private static readonly By _recipientInput = By.XPath("//input[@class='recipient-name']");
        private static readonly By _textAreaGiftCard = By.XPath("//textarea[@class='message']");

        public void AddToCartItem() => FindElement(_addToCartBtn).Click();
        public void AddToCompareList() => FindElement(_addToCompareListBtn).Click();
        public void InputRecipientName(string str) => FindElement(_recipientInput).SendKeys(str);
        public void SendMessageOnGiftCard(string str) => FindElement(_textAreaGiftCard).SendKeys(str);
    }
}
