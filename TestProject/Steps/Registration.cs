using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestProject.Helper;
using TestProject.POM;

//10 конфирм пароль разный
//11 все пустые поля

namespace TestProject.Steps
{
    [Binding]
    class Registration
    {
        HomePage homePage;
        RegisterPage registerPage;
        RegisterConfirmationPage registerConfirmationPage;
        public Registration()
        {
            homePage = new HomePage();
            registerPage = new RegisterPage();
            registerConfirmationPage = new RegisterConfirmationPage();
        }
        [Given(@"Registration page is opened")]
        public void GivenRegistrationPageIsOpened() => homePage.RegistrerBtnClick();

        [When(@"I submit new account")]
        public void WhenISubmitNewAccount(Table table)
        {
            //homePage.GoToContactUs();
            registerPage.InputFisrtName(table.Rows[0][0]);
            registerPage.InputSecondName(table.Rows[0][1]);
            registerPage.InputEmail($"{Randomizer.Date}@mail.ru");
            registerPage.InputPassword(table.Rows[0][2]);
            registerPage.ConfirmPassword(table.Rows[0][2]);
            registerPage.RegisterClick();
        }

        [Then(@"Check the confirmation of registration")]
        public void ThenCheckTheConfirmationOfRegistration() => Assert.AreEqual("Your registration completed", registerConfirmationPage.SuccesfullyRegistrated());

        
        [When(@"I submit with existing account")]
        public void WhenISubmitWithExistingAccount(Table table)
        {
            registerPage.InputFisrtName(table.Rows[0][0]);
            registerPage.InputSecondName(table.Rows[0][1]);
            registerPage.InputEmail(GlobalConst.EMAIL + "@mail.ru");
            registerPage.InputPassword(table.Rows[0][2]);
            registerPage.ConfirmPassword(table.Rows[0][2]);
            registerPage.RegisterClick();
        }

        [Then(@"Check that the specified email already exists")]
        public void ThenCheckThatTheSpecifiedEmailAlreadyExists() => Assert.AreEqual("The specified email already exists", registerPage.EmailAlreadyExistsMessage());


        [When(@"I submit with invalid mail")]
        public void WhenISubmitWithInvalidMail(Table table)
        {
            registerPage.InputFisrtName(table.Rows[0][0]);
            registerPage.InputSecondName(table.Rows[0][1]);
            registerPage.InputEmail(table.Rows[0][2]);
            registerPage.InputPassword(table.Rows[0][3]);
            registerPage.ConfirmPassword(table.Rows[0][3]);
            registerPage.RegisterClick();
        }

        [Then(@"Check that the entered mail is invalid")]
        public void ThenCheckThatTheEnteredMailIsInvalid() => Assert.AreEqual("Wrong email", registerPage.WrongEmailSpan());

        [When(@"I submit with empty mail")]
        public void WhenISubmitWithEmptyMail(Table table)
        {
            registerPage.InputFisrtName(table.Rows[0][0]);
            registerPage.InputSecondName(table.Rows[0][1]);
            registerPage.InputEmail(table.Rows[0][2]);
            registerPage.InputPassword(table.Rows[0][3]);
            registerPage.ConfirmPassword(table.Rows[0][3]);
            registerPage.RegisterClick();
        }

        [Then(@"Check that email is required")]
        public void ThenCheckThatEmailIsRequired() => Assert.AreEqual("Email is required.", registerPage.WrongEmailSpan());

        [When(@"I submit with empty first name")]
        public void WhenISubmitWithEmptyFirstName(Table table)
        {
            registerPage.InputFisrtName(table.Rows[0][0]);
            registerPage.InputSecondName(table.Rows[0][1]);
            registerPage.InputEmail($"{Randomizer.Date}@mail.ru");
            registerPage.InputPassword(table.Rows[0][2]);
            registerPage.ConfirmPassword(table.Rows[0][2]);
            registerPage.RegisterClick();
        }

        [Then(@"Check that first name is required")]
        public void ThenCheckThatFirstNameIsRequired() => Assert.AreEqual("First name is required.", registerPage.EmptyFirstNameSpan());

        [When(@"I submit with empty second name")]
        public void WhenISubmitWithEmptySecondName(Table table)
        {
            registerPage.InputFisrtName(table.Rows[0][0]);
            registerPage.InputSecondName(table.Rows[0][1]);
            registerPage.InputEmail($"{Randomizer.Date}@mail.ru");
            registerPage.InputPassword(table.Rows[0][2]);
            registerPage.ConfirmPassword(table.Rows[0][2]);
            registerPage.RegisterClick();
        }

        [Then(@"Check that second name is required")]
        public void ThenCheckThatSecondNameIsRequired() => Assert.AreEqual("Last name is required.", registerPage.EmptySecondNameSpan());

        [When(@"I submit with empty password")]
        public void WhenISubmitWithEmptyPassword(Table table)
        {
            registerPage.InputFisrtName(table.Rows[0][0]);
            registerPage.InputSecondName(table.Rows[0][1]);
            registerPage.InputEmail($"{Randomizer.Date}@mail.ru");
            registerPage.InputPassword("");
            registerPage.ConfirmPassword(table.Rows[0][2]);
            registerPage.RegisterClick();
        }

        [Then(@"Check that password and confirmation password do not match")]
        public void ThenCheckThatPasswordAndConfirmationPasswordDoNotMatch() => Assert.AreEqual("The password and confirmation password do not match.", registerPage.InvalidRepeatPasswordMessage());

        [When(@"I submit with empty confirm password")]
        public void WhenISubmitWithEmptyConfirmPassword(Table table)
        {
            registerPage.InputFisrtName(table.Rows[0][0]);
            registerPage.InputSecondName(table.Rows[0][1]);
            registerPage.InputEmail($"{Randomizer.Date}@mail.ru");
            registerPage.InputPassword(table.Rows[0][2]);
            registerPage.ConfirmPassword("");
            registerPage.RegisterClick();
        }

        [Then(@"Check that password is required")]
        public void ThenCheckThatPasswordIsRequired() => Assert.AreEqual("Password is required.", registerPage.ConfirmPasswordSpan());

        [When(@"I submit with (.*)-character password")]
        public void WhenISubmitWith_CharacterPassword(int p0, Table table)
        {
            registerPage.InputFisrtName(table.Rows[0][0]);
            registerPage.InputSecondName(table.Rows[0][1]);
            registerPage.InputEmail($"{Randomizer.Date}@mail.ru");
            registerPage.InputPassword(table.Rows[0][2]);
            registerPage.ConfirmPassword(table.Rows[0][2]);
            registerPage.RegisterClick();
        }

        [Then(@"Check that password should have at least (.*) characters")]
        public void ThenCheckThatPasswordShouldHaveAtLeastCharacters(int p0) => Assert.AreEqual("The password should have at least 6 characters.", registerPage.EmptyPasswordSpan());

        [When(@"I submit with different confirm password")]
        public void WhenISubmitWithDifferentConfirmPassword(Table table)
        {
            registerPage.InputFisrtName(table.Rows[0][0]);
            registerPage.InputSecondName(table.Rows[0][1]);
            registerPage.InputEmail($"{Randomizer.Date}@mail.ru");
            registerPage.InputPassword(table.Rows[0][2]);
            registerPage.ConfirmPassword(table.Rows[0][3]);
            registerPage.RegisterClick();
        }

        [When(@"I submit with empty fields")]
        public void WhenISubmitWithEmptyFields()
        {
            registerPage.InputFisrtName("");
            registerPage.InputSecondName("");
            registerPage.InputEmail($"");
            registerPage.InputPassword("");
            registerPage.ConfirmPassword("");
            registerPage.RegisterClick();
        }

    }
}
