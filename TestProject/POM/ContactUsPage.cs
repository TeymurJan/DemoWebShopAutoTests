using DemoWebShopAutomationHW;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.POM
{
    public class ContactUsPage : IWebDriverShell
    {
        private static readonly By _fullNameInput = By.XPath("//input[@class='fullname']");
        private static readonly By _emailInput = By.XPath("//input[@class='email']");
        private static readonly By _textAreaEnquiry = By.XPath("//textarea[@class='enquiry']");
        private static readonly By _submitMessage = By.XPath("//input[@class='button-1 contact-us-button']");
        private static readonly By _emailSuccessfullySentText = By.XPath("//div[@class='result']");
        
        public void InputFullName(string str) => FindElement(_fullNameInput).SendKeys(str);
        public void InputEmail(string str) => FindElement(_emailInput).SendKeys(str);
        public void InputText(string str) => FindElement(_textAreaEnquiry).SendKeys(str);
        public void SubmitMessageClick() => FindElement(_submitMessage).Click();
        public string SuccesfullySent() => FindElement(_emailSuccessfullySentText).Text;
    }
}
