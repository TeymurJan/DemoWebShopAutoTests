using DemoWebShopAutomationHW;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Helper;

namespace TestProject.POM
{
   public class RegisterPage : IWebDriverShell
    {
        private static readonly By _genderMaleRadioBtn = By.Id("gender-male");
        private static readonly By _genderFemaleRadioBtn = By.Id("gender-female");
        private static readonly By _firstNameInput = By.XPath("//label[@for='FirstName']/following-sibling::input");
        private static readonly By _secondNameInput = By.XPath("//label[@for='LastName']/following-sibling::input");
        private static readonly By _emailInput = By.XPath("//label[@for='Email']/following-sibling::input");
        private static readonly By _passwordInput = By.XPath("//label[@for='Password']/following-sibling::input");
        private static readonly By _confirmPasswordInput = By.XPath("//label[@for='ConfirmPassword']/following-sibling::input");
        private static readonly By _registerInput = By.XPath("//input[@class='button-1 register-next-step-button']");
        private static readonly By _emailAlreadyExistMessage = By.XPath("//div[@class='validation-summary-errors']");
        private static readonly By _invalidRepeatPasswordSpan = By.XPath("//span[@for='ConfirmPassword']");
        private static readonly By _wrongEmailSpan = By.XPath("//span[@for='Email']");
        private static readonly By _emptyMailSpan = By.XPath("//span[@class='field-validation-error']");
        private static readonly By _emptyFirstNameSpan = By.XPath("//span[@for='FirstName']");
        private static readonly By _emptySecondNameSpan = By.XPath("//span[@for='LastName']");
        private static readonly By _emptyPasswordSpan = By.XPath("//span[@for='Password']");
        private static readonly By _emptyConfirmPasswordSpan = By.XPath("//span[@for='ConfirmPassword']");

        public void SelectGender(bool isMale = true)
        {
            if (isMale)
                FindElement(_genderMaleRadioBtn).Click();
            else
            FindElement(_genderFemaleRadioBtn).Click();
        }
        public void InputFisrtName(string str) => FindElement(_firstNameInput).SendKeys(str);
        public void InputSecondName(string str) => FindElement(_secondNameInput).SendKeys(str);
        public void InputEmail(string str) => FindElement(_emailInput).SendKeys(str);
        public void InputPassword(string str) => FindElement(_passwordInput).SendKeys(str);
        public void ConfirmPassword(string str) => FindElement(_confirmPasswordInput).SendKeys(str);
        public void RegisterClick() => FindElement(_registerInput).Click();
        public string EmailAlreadyExistsMessage() => FindElement(_emailAlreadyExistMessage).Text.Trim();
        public string InvalidRepeatPasswordMessage() => FindElement(_invalidRepeatPasswordSpan).Text.Trim();
        public string WrongEmailSpan() => FindElement(_wrongEmailSpan).Text.Trim();
        public string EmptyMailSpan() => FindElement(_emptyMailSpan).Text.Trim();
        public string EmptyFirstNameSpan() => FindElement(_emptyFirstNameSpan).Text.Trim();
        public string EmptySecondNameSpan() => FindElement(_emptySecondNameSpan).Text.Trim();
        public string EmptyPasswordSpan() => FindElement(_emptyPasswordSpan).Text.Trim();
        public string ConfirmPasswordSpan() => FindElement(_emptyConfirmPasswordSpan).Text.Trim();
        public void Registration(string mail = null, bool isMale = true, string password = "Qwerty123")
        {
            var homePage = new HomePage();
            var registerPage = new RegisterPage();
            if (mail == null)
                mail = Randomizer.Date;
            homePage.RegistrerBtnClick();
            registerPage.SelectGender(isMale);
            registerPage.InputFisrtName("Name");
            registerPage.InputSecondName("SecondName");
            registerPage.InputEmail(mail + "@mail.ru");
            registerPage.InputPassword(password);
            registerPage.ConfirmPassword(password);
        }
    }
}
