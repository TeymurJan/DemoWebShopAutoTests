using DemoWebShopAutomationHW;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.POM
{
    public class OnePageCheckOut : IWebDriverShell
    {
        private static readonly By _cityInput = By.XPath("//input[@name='BillingNewAddress.City']");
        private static readonly By _billingAdress1Input = By.XPath("//input[@name='BillingNewAddress.Address1']");
        private static readonly By _zipPostalCodeInput = By.XPath("//input[@name='BillingNewAddress.ZipPostalCode']");
        private static readonly By _phoneNumberInput = By.XPath("//input[@name='BillingNewAddress.PhoneNumber']");
        private static readonly By _continueButton = By.XPath("//input[@value='Continue']");
        private static readonly By _creditCardRadioBtn = By.Id("paymentmethod_2");
        private static readonly By _cardHolderNameINput = By.XPath("//input[@name='CardholderName']");
        private static readonly By _cardNumberInput = By.XPath("//input[@name='CardNumber']");
        private static readonly By _cardCodeInput = By.XPath("//input[@name='CardCode']");
        private static readonly By _confirmCheckoutBtn = By.XPath("//input[@class='button-1 confirm-order-next-step-button']");

        public void InputCityName(string str) => FindElement(_cityInput).SendKeys(str);
        public void InputAdress1Name(string str) => FindElement(_billingAdress1Input).SendKeys(str);
        public void InputZipPostalCode(string str) => FindElement(_zipPostalCodeInput).SendKeys(str);
        public void InputPhoneNumber(string str) => FindElement(_phoneNumberInput).SendKeys(str);
        public void CheckoutCreditCardPayment() => FindElement(_creditCardRadioBtn).Click();
        public void InputCardHolderName(string str) => FindElement(_cardHolderNameINput).SendKeys(str);
        public void InputCardNumber(string str) => FindElement(_cardNumberInput).SendKeys(str);
        public void InputCardCode(string str) => FindElement(_cardCodeInput).SendKeys(str);
        public void ClickConfirmBtn() => FindElement(_confirmCheckoutBtn).Click();
        public IEnumerable<IWebElement> ContinueBtn()
        {
            var buttons = FindElements(_continueButton);
            for (int i = 0; i < buttons.Count; i++)
            {
                IWebElement item = buttons[i];
                yield return item;
            }
        }
    }
}
