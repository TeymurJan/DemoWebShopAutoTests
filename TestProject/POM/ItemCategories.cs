using DemoWebShopAutomationHW;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.POM
{
    public class ItemCategories : IWebDriverShell
    {
        private static readonly By _desktopsHrefImage = By.XPath("//img[@alt='Picture for category Desktops']");
        private static readonly By _100dollarGiftCard = By.XPath("//div[@class='product-item']//img[@alt='Picture of $100 Physical Gift Card']");
        private static readonly By _itemHref = By.XPath("//div[@class='details']//a");
        
        public void GoToDesktop() => FindElement(_desktopsHrefImage).Click();
        public void GiftSelect100CardClick() => FindElement(_100dollarGiftCard).Click();
        public void BookComputingAndInternetClick() => FindElements(_itemHref).First(book => book.Text.Contains("Computing and Internet")).Click();
        public void ApparelDenimShotsClick() => FindElements(_itemHref).First(shorts => shorts.Text.Contains("Denim Short with Rhinestones")).Click();
    }
}
