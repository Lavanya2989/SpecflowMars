using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MarsQA_1.SpecflowPages.Pages
{
    class Skill
    {
        private IWebElement Addnewbutton => Driver.driver.FindElement(By.XPath("(//div[contains(text(),'Add New')])[2]"));
        private IWebElement AddnewSkill => Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        private IWebElement SkillLevel => Driver.driver.FindElement(By.XPath("//select"));
        private IWebElement SaveSkill => Driver.driver.FindElement(By.XPath("//div[@data-tab='second']//input[@value='Add']"));
        private IWebElement EditSkill => Driver.driver.FindElement(By.XPath("(//*[@data-tab='second']//table//tbody//tr//td[3]//i[@class='outline write icon'])"));
        private IWebElement UpdateSkill => Driver.driver.FindElement(By.XPath("//input[@value='Update']"));

    public void AddSkill()
        {
            //Click Add new skill
            Addnewbutton.Click();
            //Populate excl data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //Add Skill
            AddnewSkill.SendKeys(ExcelLibHelper.ReadData(2, "Skill"));
            //Add skill level
            SkillLevel.SendKeys(ExcelLibHelper.ReadData(2, "Skill Level"));
            //Click save
            SaveSkill.Click();
        }
        public void AssertSkill()
        {
            //Populate excel data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            String ActSkill = (Driver.driver.FindElement(By.XPath("//*[@data-tab='second']//tbody[last()]//td[1]"))).Text;
             //Assert skill
            Assert.AreEqual(ActSkill, ExcelLibHelper.ReadData(2, "Skill"));
            String ActSkill1 =(Driver.driver.FindElement(By.XPath("//*[@data-tab='second']//tbody[last()]//td[2]"))).Text;

            //Assert skill level
            Assert.AreEqual(ActSkill1, ExcelLibHelper.ReadData(2, "Skill Level"));
        }
    public void SkillEdit()
        {
            //Populate excel data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //Click edit button
            EditSkill.Click();
            //Update new skill
            AddnewSkill.Clear();
            AddnewSkill.SendKeys(ExcelLibHelper.ReadData(3, "Skill"));
            //Update skill level
            SkillLevel.SendKeys(ExcelLibHelper.ReadData(3, "Skill Level"));
            //Click update
            UpdateSkill.Click();
        }
        public void AssertEditSkill()
        {
            //Populate excel data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //String ActSkill = (Driver.driver.FindElement(By.XPath("//*[@data-tab='second']//tbody[last()]//td[1]"))).Text;
            //Assert skill
            //Assert.AreEqual(ActSkill, ExcelLibHelper.ReadData(3, "Skill"));
            String ActSkill1 = (Driver.driver.FindElement(By.XPath("//*[@data-tab='second']//tbody[last()]//td[2]"))).Text;

            //Assert skill level
            Assert.AreEqual(ActSkill1, ExcelLibHelper.ReadData(3, "Skill Level"));
        }
    }
}
