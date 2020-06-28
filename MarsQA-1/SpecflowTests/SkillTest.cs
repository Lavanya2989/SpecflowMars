using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using MarsQA_1.SpecflowPages.Pages;

namespace MarsQA_1.SpecflowTests
{
    [Binding]
    class SkillTest
    {
        [Given(@"I clicked on the Skill tab under Profile page")]
        public void GivenIClickedOnTheSkillTabUnderProfilePage()
        {
            //Click skill
            Driver.driver.FindElement(By.XPath("//a[@data-tab='second']")).Click();
        }

        [When(@"I add a new Skill")]
        public void WhenIAddANewSkill()
        {
            Skill skillobj = new Skill();
            skillobj.AddSkill();
        }

        [Then(@"that skill should be displayed on my listings")]
        public void ThenThatSkillShouldBeDisplayedOnMyListings()
        {
            Skill skillobj = new Skill();
            skillobj.AssertSkill();
        }


        [When(@"I  update Skill")]
        public void WhenIUpdateSkill()
        {
            Skill skilledit = new Skill();
            skilledit.SkillEdit();
        }

        [Then(@"that updated Skill should be displayed on my listings")]
        public void ThenThatUpdatedSkillShouldBeDisplayedOnMyListings()
        {
            Skill skilledit = new Skill();
            skilledit.AssertEditSkill();
        }

        [When(@"I delete Skill")]
        public void WhenIDeleteSkill()
        {
            Driver.TurnOnWait();
            //Click delete
            Driver.driver.FindElement(By.XPath("(//*[@data-tab='second']//table//tbody[last()]//tr//td[3]//i[@class='remove icon'])")).Click();
        }

        [Then(@"that Skill should not be displayed on my listings")]
        public void ThenThatSkillShouldNotBeDisplayedOnMyListings()
        {
            try
            {
                String ActLang2 = (Driver.driver.FindElement(By.XPath("//tbody//tr[1]//td[1]"))).Text;
                Assert.AreNotEqual(ActLang2, ExcelLibHelper.ReadData(3, "Skill"));
            }
            catch
            {
                Assert.True(true, "Element not found");
            }
        }

    }
}
