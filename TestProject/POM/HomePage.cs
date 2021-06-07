using DemoWebShopAutomationHW;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.POM
{
    public class HomePage : IWebDriverShell
    {
        IWebDriver driver;
        private static readonly By _myAccount = By.XPath("//div[@class='header-links']//a[@class='account']");//Only for logged account
        private static readonly By _registerBtn = By.XPath("//a[@class='ico-register']");
        private static readonly By _categoriesListPages = By.XPath("//li[@class='inactive']//a");
        private static readonly By _loginBtn = By.XPath("//a[@class='ico-login']");
        private static readonly By _contactUs = By.XPath("//div[@class='column information']//li/a");
        private static readonly By _shoppingCartItemCount = By.XPath("//span[@class='cart-qty']");



        public string MyAccountEmail() => FindElement(_myAccount).Text;
        public void RegistrerBtnClick() => FindElement(_registerBtn).Click();
        public void LogInBtnClick() => FindElement(_loginBtn).Click();
        public void ShoppingCartListClick() => FindElement(_shoppingCartItemCount).Click();
        public void GoToContactUs() => FindElements(_contactUs).First(elem => elem.Text.Contains("Contact us")).Click();
        public void SelectPage(Pages pages) => FindElements(_categoriesListPages).First(page => page.Text.Contains(pages.ToString())).Click();
        public enum Pages
        {
            Books, Computers, Electronics, Apparel, Digital, Jewelry, Gift
        }
    }
}
