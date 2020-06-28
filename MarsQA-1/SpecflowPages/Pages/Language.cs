using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_1.SpecflowPages.Pages
{
    class Language
    {
       
        private IWebElement Addnewlang => Driver.driver.FindElement(By.XPath("//div[contains(text(),'Add New')][1]"));
        private IWebElement AddLang => Driver.driver.FindElement(By.XPath("//input[@type='text'and@placeholder='Add Language']"));
        private IWebElement SelectLevel => Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']"));
        private IWebElement SaveLang => Driver.driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement EditLang => Driver.driver.FindElement(By.XPath("//div[@data-tab='first']//table//tbody//tr//td[3]//i[@class='outline write icon']"));
        private IWebElement UpdateLang => Driver.driver.FindElement(By.XPath("//input[@value='Update']"));
       // private IWebElement delLang => Driver.driver.FindElement(By.XPath("//div[@data-tab='first']//table//tbody//tr//td[3]//i[@class='remove icon']"));
      public void AddLanguage()
        {
            //Populate excel data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //click Add new
            Addnewlang.Click();
            //Enter Language
            AddLang.SendKeys(ExcelLibHelper.ReadData(2, "Language"));
            //Enter level
            SelectLevel.SendKeys(ExcelLibHelper.ReadData(2, "Level"));
            //Click save
            SaveLang.Click();
        }
        public void AssertAddLanguage()
        {
            //populate excel data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            Driver.TurnOnWait();

            //Assert language
            String Lang = Driver.driver.FindElement(By.XPath("(//div[@data-tab='first']//table//tbody//tr[1]//td[1])[1]")).Text;
            Assert.AreEqual(Lang, ExcelLibHelper.ReadData(2, "Language"));

            //Assert level
            String Langlevel = Driver.driver.FindElement(By.XPath("(//div[@data-tab='first']//table//tbody//tr[1]//td[2])[1]")).Text;
            Assert.AreEqual(Langlevel, ExcelLibHelper.ReadData(2, "Level"));
        }
        public void EditLanguage()
        {
            //Populate excel data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //click edit
            EditLang.Click();
            //Update language
            AddLang.Clear();
            AddLang.SendKeys(ExcelLibHelper.ReadData(3, "Language"));
            //update level
            SelectLevel.SendKeys(ExcelLibHelper.ReadData(3, "Level"));
            //click update 
            UpdateLang.Click();
        }
         public void AssertEditLanguage()
        {
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            Driver.TurnOnWait();
           //String Lang = Driver.driver.FindElement(By.XPath("(//div[@data-tab='first']//table//tbody//tr[1]//td[1])[1]")).Text;
            //Assert.AreEqual(Lang, ExcelLibHelper.ReadData(3, "Language"));

            String Langlevel = Driver.driver.FindElement(By.XPath("(//div[@data-tab='first']//table//tbody//tr[1]//td[2])[1]")).Text;
            Assert.AreEqual(Langlevel, ExcelLibHelper.ReadData(3, "Level"));
        }
    }

}
