using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;

namespace MarsQA_1.Pages
{
    [Binding]
    public static class SignIn
    {
        private static IWebElement SignInBtn =>  Driver.driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a"));
        private static IWebElement Email => Driver.driver.FindElement(By.XPath("//input[@name='email']"));
        private static IWebElement Password => Driver.driver.FindElement(By.XPath("//input[@name='password']"));
        private static IWebElement LoginBtn => Driver.driver.FindElement(By.XPath("//button[@class='fluid ui teal button']"));
        private static IWebElement ProfileTitle => Driver.driver.FindElement(By.XPath("//a[contains(text(),'Mars Logo')]"));
       
        [Given(@"Login to the website")]
        public static void GivenLoginToTheWebsite()
        {
            //Navigate to Url
            Driver.NavigateUrl();
            SignInBtn.Click();
        }

        [When(@"I enter valid username and password")]
        public static void WhenIEnterValidUsernameAndPassword()
        {
            //Populate data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "SignIn");
            //Enter username
            Email.SendKeys(ExcelLibHelper.ReadData(2, "Username"));
            //Enter Password
            Password.SendKeys(ExcelLibHelper.ReadData(2, "Password"));
            //Click login
            LoginBtn.Click();
        }

        [Then(@"I should be at the homepage")]
        public static void ThenIShouldBeAtTheHomepage()
        {
            Driver.TurnOnWait();
            var ProfileTitle = Driver.driver.FindElement(By.XPath("//a[contains(text(),'Mars Logo')]"));
            Assert.AreEqual(ProfileTitle.Text, "Mars Logo");
        }


    }
}