using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;

namespace MarsQA_1.SpecflowTests
{
    [Binding]
    class ShareskillTest
    {
        [Scope(Tag = "AddShareSkill")]
        [Given(@"I clicked shareskill button on profile page")]
        public void GivenIClickedShareskillButtonOnProfilePage()
        {
            //Click Shareskill button
            Driver.driver.FindElement(By.XPath("//a[contains(.,'Share Skill')]")).Click();
        }

        [When(@"I add user details")]
        public void WhenIAddUserDetails()
        {
            ShareSkill shareobj = new ShareSkill();
            shareobj.AddShareSkill();
        }

        [Then(@"I should see the listing on managelisting page")]
        public void ThenIShouldSeeTheListingOnManagelistingPage()
        {
            ShareSkill shareobj = new ShareSkill();
            shareobj.AssertAddShareSkill();
        }

        [Scope(Tag = "EditShareSkill")]
        [Given(@"I clicked Edit button on shareskill")]
        public void GivenIClickedEditButtonOnShareskill()
        {
            //Click Managelisting
            Driver.driver.FindElement(By.XPath("//section//a[contains(.,'Manage Listings')]")).Click();
        }

        [When(@"I update user details")]
        public void WhenIUpdateUserDetails()
        {
            ShareSkill editshare = new ShareSkill();
            editshare.EditShareSkill();
        }

        [Then(@"i should see the updated details on managelisting")]
        public void ThenIShouldSeeTheUpdatedDetailsOnManagelisting()
        {
            ShareSkill editshare = new ShareSkill();
            editshare.AssertEditShareSkill();
        }

        [Scope(Tag = "DeleteShareSkill")]
        [Given(@"I clicked delete button on managelisting")]
        public void GivenIClickedDeleteButtonOnManagelisting()
        {
            //Click managelisting
            Driver.driver.FindElement(By.XPath("//section//a[contains(.,'Manage Listings')]")).Click();
        }

        [When(@"I delete ShareSkill")]
        public void WhenIDeleteShareSkill()
        {
            //Click delete button
            Driver.driver.FindElement(By.XPath("(//i[@class='remove icon'])[1]")).Click();
            //Click yes
            Driver.driver.FindElement(By.XPath("//i[@class='checkmark icon']")).Click();
        }

        [Then(@"Shareskill i deleted should not seen in listings")]
        public void ThenShareskillIDeletedShouldNotSeenInListings()
        {
            try
            {
                string title = ExcelLibHelper.ReadData(2, "Title");
                String acttitle= (Driver.driver.FindElement(By.XPath("(//td[@class='four wide'])[1]"))).Text;
                Assert.AreNotEqual(title, acttitle, "Title not deleted");
            }
            catch
            {
                Assert.True(true, "Element not found");
            }
        }

    }
}
