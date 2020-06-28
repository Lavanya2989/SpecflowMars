using MarsQA_1.Helpers;
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
    class SearchSkillTest
    {
        [Given(@"I clicked searchskill button")]
        public void GivenIClickedSearchskillButton()
        {
            //Click searchskill
            Driver.driver.FindElement(By.XPath("//i[@class='search link icon']")).Click();
        }

        [When(@"Select the skill by clicking Category and subcategory")]
        public void WhenSelectTheSkillByClickingCategoryAndSubcategory()
        {
            //Click category
            Driver.driver.FindElement(By.XPath("(//a[@role='listitem'])[9]")).Click();
            //Click subcategory
            Driver.driver.FindElement(By.XPath("(//a[@class='item subcategory'])[1]")).Click();
            //Click Skill
            Driver.driver.FindElement(By.XPath("(//a[@class='seller-info'])[3]")).Click();
        }

        [Then(@"I should see the Skill details page")]
        public void ThenIShouldSeeTheSkillDetailsPage()
        {
            String URL = Driver.driver.Url;
            Assert.AreEqual(URL, "http://192.168.99.100:5000/Account/Profile?id=5eb0901d4d2814000663501a");
        }

       
        [When(@"Select the skill by using Filter")]
        public void WhenSelectTheSkillByUsingFilter()
        {
            //Click online
            Driver.driver.FindElement(By.XPath("(//button[@class='ui button'])[1]")).Click();
            Driver.TurnOnWait();
            //Click skill
            Driver.driver.FindElement(By.XPath("(//a[@class='seller-info'])[1]")).Click();
        }

        [Then(@"I should see the skill list")]
        public void ThenIShouldSeeTheSkillList()
        {
            //Assert skill
            var img = (Driver.driver.FindElement(By.XPath("//img"))).Displayed;
            Assert.IsTrue(img);
        }


    }
}
