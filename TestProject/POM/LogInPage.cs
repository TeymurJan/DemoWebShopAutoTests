using DemoWebShopAutomationHW;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.POM
{ 
    public class LogInPage : IWebDriverShell
    {
        private static readonly By _emailInput = By.XPath("//input[@class='email']");
        private static readonly By _passwordInput = By.XPath("//input[@class='password']");
        private static readonly By _rememberMeCheckBox = By.Id("RememberMe");
        private static readonly By _loginBtn = By.XPath("//input[@class='button-1 login-button']");
        
        public void EmailInput(string str) => FindElement(_emailInput).SendKeys(str);
        public void PasswordInput(string str) => FindElement(_passwordInput).SendKeys(str);
        public void RememberMeClick() => FindElement(_rememberMeCheckBox).Click();
        public void LogInClick() => FindElement(_loginBtn).Click();

    }
}
