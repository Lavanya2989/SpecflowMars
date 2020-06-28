using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MarsQA_1.SpecflowTests
{
    [Binding]
    class ProfileDetails
    {
        [Scope(Tag ="Availability")]
        [Given(@"I clicked Availability button")]
        public void GivenIClickedAvailabilityButton()
        {
            //Click availability
            Driver.driver.FindElement(By.XPath("(//i[@class='right floated outline small write icon'])[1]")).Click();
        }

        [When(@"I select the Available time")]
        public void WhenISelectTheAvailableTime()
        {
            //Populate excel data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //Select availability
            SelectElement time = new SelectElement(Driver.driver.FindElement(By.XPath("//select")));
         time.SelectByText(ExcelLibHelper.ReadData(2, "Availability"));
        }
    

        [Then(@"the available time should be displayed")]
        public void ThenTheAvailableTimeShouldBeDisplayed()
        {
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //assert Availability
            String Time = (Driver.driver.FindElement(By.XPath("((//span)[5]//option)[3]"))).Text;
            Assert.AreEqual(Time,ExcelLibHelper.ReadData(2, "Availability"));
        }

        [Scope(Tag = "Hours")]

        [Given(@"I clicked Hours button")]
        public void GivenIClickedHoursButton()
        {
            //Click Hours
            Driver.driver.FindElement(By.XPath("(//i[@class='right floated outline small write icon'])[2]")).Click();
        }

        [When(@"I select hours can work")]
        public void WhenISelectHoursCanWork()
        {
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //Select hours
            SelectElement time = new SelectElement(Driver.driver.FindElement(By.XPath("//select")));
            time.SelectByText(ExcelLibHelper.ReadData(2, "Hours"));
        }

        [Then(@"the hours should be displayed")]
        public void ThenTheHoursShouldBeDisplayed()
        {
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            String Hour = (Driver.driver.FindElement(By.XPath("(//select//option)[3]"))).Text;
            //Assert Hour
            Assert.AreEqual(Hour,ExcelLibHelper.ReadData(2, "Hours"));
        }

        [Scope(Tag = "EarnTarget")]

        [Given(@"I clicked Earntarget button")]
        public void GivenIClickedEarntargetButton()
        {
            //Click Earntarget
            Driver.driver.FindElement(By.XPath("(//i[@class='right floated outline small write icon'])[3]")).Click();
        }

        [When(@"I select the earn target")]
        public void WhenISelectTheEarnTarget()
        {
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //Select EarnTarget
            SelectElement Earn = new SelectElement(Driver.driver.FindElement(By.XPath("//select")));
            Earn.SelectByText(ExcelLibHelper.ReadData(2, "EarnTarget"));
        }

        [Then(@"the earn target should be displayed")]
        public void ThenTheEarnTargetShouldBeDisplayed()
        {
            //Assert EarnTarget
            String EarnT = (Driver.driver.FindElement(By.XPath("(//select//option)[4]"))).Text;
            Assert.AreEqual(EarnT,ExcelLibHelper.ReadData(2, "EarnTarget"));
        }

        [Scope(Tag = "Description")]
        [Given(@"I clicked Description button")]
        public void GivenIClickedDescriptionButton()
        {
            //Click Description
            Driver.driver.FindElement(By.XPath("(//i[@class='outline write icon'])[1]")).Click();
        }

        [When(@"I add the description in textarea")]
        public void WhenIAddTheDescriptionInTextarea()
        {
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //Add description
            Driver.driver.FindElement(By.XPath("//textarea")).SendKeys(ExcelLibHelper.ReadData(2, "Description"));
            //Click Save
            Driver.driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }

        [Then(@"i should see the description in my profile")]
        public void ThenIShouldSeeTheDescriptionInMyProfile()
        {
            //Assert Description
            String addMessage = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']//div")).Text;
            String expectedAddMessage = "Description has been saved successfully";
            Assert.AreEqual(addMessage, expectedAddMessage);
        }

        [Scope(Tag = "Profilename")]
        [Given(@"I clicked profile name button")]
        public void GivenIClickedProfileNameButton()
        {
            //Click profile name
            Driver.driver.FindElement(By.XPath("(//i[@class='dropdown icon'])[2]")).Click();
        }

        [When(@"I add the username")]
        public void WhenIAddTheUsername()
        {
            //Populate excel data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //Enter Firstname
            Driver.driver.FindElement(By.XPath("//input[@name='firstName']")).Clear();
            Driver.driver.FindElement(By.XPath("//input[@name='firstName']")).SendKeys(ExcelLibHelper.ReadData(2, "Firstname"));
            //Enter Lastname
            Driver.driver.FindElement(By.XPath("//input[@name='lastName']")).Clear();
            Driver.driver.FindElement(By.XPath("//input[@name='lastName']")).SendKeys(ExcelLibHelper.ReadData(2, "Lastname"));
            //Click save
            Driver.driver.FindElement(By.XPath("//button[@class='ui teal button']")).Click();
        }

        [Then(@"i should see the username in my profile")]
        public void ThenIShouldSeeTheUsernameInMyProfile()
        {
            //Populate excel data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //Assert name
            var fname = ExcelLibHelper.ReadData(2, "Firstname");
            var Lname = ExcelLibHelper.ReadData(2, "Lastname");
            var title = fname + " " + Lname;
            String Titlename = (Driver.driver.FindElement(By.XPath("//div[@class='title' and contains(text(),'Lavanya Rajendran')]"))).Text;
            Assert.AreEqual(Titlename, title);
        }

    }
}
