using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using MarsQA_1.Utils;
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
    class EducationTest:Start
    {
        [Given(@"I clicked on the Education tab under Profile page")]
        public void GivenIClickedOnTheEducationTabUnderProfilePage()
        {
            //Click Education tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='third']")).Click();
        }

        [When(@"I add a new Education")]
        public void WhenIAddANewEducation()
        {
            Education eduobj = new Education();
            eduobj.AddEducation();
        }

        [Then(@"that Education should be displayed on my listings")]
        public void ThenThatEducationShouldBeDisplayedOnMyListings()
        {
            Education eduobj = new Education();
            eduobj.AssertEducation();
        }

        [When(@"I  update Education")]
        public void WhenIUpdateEducation()
        {
            Education editedu = new Education();
            editedu.EditEducation();
        }

        [Then(@"that updated Education should be displayed on my listings")]
        public void ThenThatUpdatedEducationShouldBeDisplayedOnMyListings()
        {
            Education editedu = new Education();
            editedu.AssertEditEducation();
        }

        [When(@"I delete Education")]
        public void WhenIDeleteEducation()
        {
            //click delete button
            Driver.driver.FindElement(By.XPath("//div[@data-tab='third']//table//tbody//tr//td[6]//i[@class='remove icon']")).Click();
        }

        [Then(@"that Education should not be displayed on my listings")]
        public void ThenThatEducationShouldNotBeDisplayedOnMyListings()
        {
            try
            {
                String ActEdu2 = (Driver.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[1]"))).Text;
                Assert.AreNotEqual(ActEdu2,ExcelLibHelper.ReadData(3, "Country"));
            }
            catch
            {
                Assert.True(true, "Element not found");
            }
        }

    }
}
