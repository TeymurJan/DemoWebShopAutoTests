//using DemoWebShopAutomationHW;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Support.UI;
//using System;
//using System.Linq;
//using System.Threading;
//using TechTalk.SpecFlow;
//using TestProject.Helper;
//using TestProject.POM;

//namespace TestProject
//{
//    ////a[@class="ico-register"]
//    [TestFixture]
//    class Tests : IWebDriverShell
//    { 
//        HomePage homePage;
//        Desktops desktops;
//        ItemPage itemPage;
//        LogInPage logInPage;
//        ShoppingCart shoppingCart;
//        RegisterPage registerPage;
//        ContactUsPage contactUsPage;
//        ItemCategories itemCategories;
//        OnePageCheckOut onePageCheckOut;
//        CompareProductsPage compareProductsPage;
//        RegisterConfirmationPage registerConfirmationPage;

//        [SetUp]
//        public void SetUp()
//        {
//            GetDriver().Navigate().GoToUrl(@"http://demowebshop.tricentis.com/");

//            homePage = new HomePage();
//            desktops = new Desktops();
//            itemPage = new ItemPage();
//            logInPage = new LogInPage();
//            shoppingCart = new ShoppingCart();
//            registerPage = new RegisterPage();
//            contactUsPage = new ContactUsPage();
//            itemCategories = new ItemCategories();
//            onePageCheckOut = new OnePageCheckOut();
//            compareProductsPage = new CompareProductsPage();
//            registerConfirmationPage = new RegisterConfirmationPage();
//            Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
//        }
//        [Test]
//        public void RegistrationTest()
//        {
//            registerPage.Registration();
//            registerPage.RegisterClick();
//            Assert.AreEqual("Your registration completed", registerConfirmationPage.SuccesfullyRegistrated());
//        }
//        [Test]
//        public void SameEmailRegistrationTest()
//        {
//            registerPage.Registration(GlobalConst.EMAIL);
//            registerPage.RegisterClick();
//            Assert.AreEqual("The specified email already exists", registerPage.EmailAlreadyExistsMessage());
//        }
//        [Test]
//        public void InvalidRepeatPasswordTest()
//        {
//            registerPage.Registration();
//            registerPage.InputPassword("asdasdasd");
//            registerPage.RegisterClick();
//            Assert.AreEqual("The password and confirmation password do not match.", registerPage.InvalidRepeatPasswordMessage());
//        }
//        [Test]
//        public void TestAuthorizathion()
//        {
//            homePage.LogInBtnClick();
//            logInPage.EmailInput(GlobalConst.EMAIL + "@mail.ru");
//            logInPage.PasswordInput(GlobalConst.PASSWORD);
//            logInPage.RememberMeClick();
//            logInPage.LogInClick();
//            Assert.AreEqual(GlobalConst.EMAIL + "@mail.ru", homePage.MyAccountEmail());
//        }
//        [Test]
//        public void AddItemToShoppingCart()
//        {
//            homePage.SelectPage(HomePage.Pages.Computers);
//            itemCategories.GoToDesktop();
//            desktops.AddToCartList();
//            itemPage.AddToCartItem();
//            homePage.ShoppingCartListClick();
//            Assert.AreNotEqual("Your Shopping Cart is empty!", shoppingCart.EmptyShoppingCart().Trim());
//        }
//        [Test]
//        public void CheckPriceOfComputerTest()
//        {
//            homePage.SelectPage(HomePage.Pages.Computers);
//            itemCategories.GoToDesktop();
//            new SelectElement(FindElement(By.Id("products-orderby"))).SelectByText("Name: Z to A");
//            desktops.AddToCartList();
//            string expectedPrice = FindElement(By.XPath("//span[@class='price-value-75']")).Text;
//            itemPage.AddToCompareList();
//            Assert.AreEqual(expectedPrice, compareProductsPage.ProductPrice());
//        }
//        [Test]
//        public void ShoppingCheckOut()
//        {
//            registerPage.Registration();
//            registerPage.RegisterClick();
//            Navigate().GoToUrl(@"http://demowebshop.tricentis.com/");
//            homePage.SelectPage(HomePage.Pages.Gift);
//            itemCategories.GiftSelect100CardClick();
//            itemPage.InputRecipientName("Bla-bla-bla");
//            itemPage.SendMessageOnGiftCard("Hope you got my giftcard");
//            itemPage.AddToCartItem();
//            homePage.SelectPage(HomePage.Pages.Books);
//            itemCategories.BookComputingAndInternetClick();
//            itemPage.AddToCartItem();
//            homePage.SelectPage(HomePage.Pages.Apparel);
//            itemCategories.ApparelDenimShotsClick();
//            itemPage.AddToCartItem();
//            homePage.ShoppingCartListClick();
//            shoppingCart.TemsOfServiceCheckout();
//            shoppingCart.CheckOutBtnClick();
//            var click = onePageCheckOut.ContinueBtn().ToList();

//            for (int i = 0; i < click.Count; i++)
//            {
//                if (i == 0)
//                {
//                    new SelectElement(FindElement(By.Id("BillingNewAddress_CountryId"))).SelectByText("Azerbaijan");
//                    onePageCheckOut.InputCityName("Baku");
//                    onePageCheckOut.InputAdress1Name("HA pr18");
//                    onePageCheckOut.InputPhoneNumber("+994513808853");
//                    onePageCheckOut.InputZipPostalCode("AZ1149");
//                }
//                if (i == 3)
//                    onePageCheckOut.CheckoutCreditCardPayment();
//                if (i == 4)
//                {
//                    onePageCheckOut.InputCardHolderName("Sexyboi Nonetvoy");
//                    onePageCheckOut.InputCardNumber("4111111111111111");
//                    onePageCheckOut.InputCardCode("000");
//                }
//                while (!click[i].Displayed) ;
//                click[i].Click();
//            }
//            onePageCheckOut.ClickConfirmBtn();
//            Assert.AreEqual("Your order has been successfully processed!", FindElement(By.XPath("//div[@class='title']//strong")).Text);
//        }
//        [Test]
//        public void WriteEmailTest()
//        {
//            homePage.GoToContactUs();
//            contactUsPage.InputFullName("Firstname SecondName");
//            contactUsPage.InputEmail(GlobalConst.EMAIL + "@mail.ru");
//            contactUsPage.InputText($"You demo is another level of pure sh1t" +
//                $"\n{Randomizer.Date}" +
//                $"\n{Randomizer.Date}" +
//                $"\n{Randomizer.Date}" +
//                $"\n{Randomizer.Date}" +
//                $"\n{Randomizer.Date}" +
//                $"\n{Randomizer.Date}" +
//                $"\n{Randomizer.Date}" +
//                $"\n{Randomizer.Date}" +
//                $"\n{Randomizer.Date}" +
//                $"\n{Randomizer.Date}" +
//                $"\n{Randomizer.Date}");
//            contactUsPage.SubmitMessageClick();
//            Assert.AreEqual("Your enquiry has been successfully sent to the store owner.", contactUsPage.SuccesfullySent().Trim());
//        }
//        [TearDown]
//        public void TearDown() => Quit();
//    }
//}

//        //[Test]
//        //public void AddElementToShoppingCartTest()
//        //{
//        //    SelectPage(Pages.Computers);
//        //    FindElement(_desktopsHrefImage).Click();
//        //    var computers = FindElements(By.XPath("//div[@class='item-box']//input[@type='button']"));
//        //    var url = Url;
//        //    for(int i = 0; i < computers.Count; i++)
//        //    {
//        //        computers[i].Click();
//        //        FindElement(By.XPath("//ul[@class='option-list']//input")).Click(); 
//        //        FindElement(_onComputerAddToCartBtn).Click();
//        //        Navigate().GoToUrl(url);
//        //        computers = null;
//        //        computers = FindElements(By.XPath("//div[@class='item-box']//input[@type='button']"));
//        //    }
//        //}