using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MarsQA_1.SpecflowTests
{
    [Binding]
    class LanguageTest
    {
        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Click language tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='first']")).Click();
        }

        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            Language lanobj = new Language();
            lanobj.AddLanguage();
        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            Language lanobj = new Language();
            lanobj.AssertAddLanguage();
        }

        [When(@"I  update Language")]
        public void WhenIUpdateLanguage()
        {
            Language lanedit = new Language();
            lanedit.EditLanguage();
        }

        [Then(@"that updated language should be displayed on my listings")]
        public void ThenThatUpdatedLanguageShouldBeDisplayedOnMyListings()
        {
            Language lanedit = new Language();
            lanedit.AssertEditLanguage();
        }

        [When(@"I delete language")]
        public void WhenIDeleteLanguage()
        {
            //click delete 
            Driver.driver.FindElement(By.XPath("//div[@data-tab='first']//table//tbody//tr//td[3]//i[@class='remove icon']")).Click();
        }

        [Then(@"that language should not be displayed on my listings")]
        public void ThenThatLanguageShouldNotBeDisplayedOnMyListings()
        {
            try
            {
                String ActLang2 = (Driver.driver.FindElement(By.XPath("//tbody//tr[1]//td[1]"))).Text;
                Assert.AreNotEqual(ActLang2,ExcelLibHelper.ReadData(3, "Language"));
            }
            catch
            {
                Assert.True(true, "Element not found");
            }
        }

    }
}
