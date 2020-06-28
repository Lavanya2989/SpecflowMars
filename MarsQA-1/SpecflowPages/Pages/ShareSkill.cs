using MarsQA_1.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoItX3Lib;
using NUnit.Framework;

namespace MarsQA_1.SpecflowPages.Pages
{
    class ShareSkill
    {
        private IWebElement Title => Driver.driver.FindElement(By.XPath("//input[@name='title']"));
        private IWebElement Description => Driver.driver.FindElement(By.XPath("//textarea"));
        private IWebElement CategoryDropdown => Driver.driver.FindElement(By.XPath("//select"));
        private IWebElement SubcategoryDropdown => Driver.driver.FindElement(By.XPath("//select[@name='subcategoryId']"));
        private IWebElement Tags => Driver.driver.FindElement(By.XPath("(//input[@placeholder='Add new tag'])[1]"));
        private IWebElement Hourly => Driver.driver.FindElement(By.XPath("(//input[@value='0'])[1]"));
        private IWebElement Oneoff => Driver.driver.FindElement(By.XPath("(//input[@name='serviceType'])[2]"));
        private IWebElement Onsite => Driver.driver.FindElement(By.XPath("(//input[@value='0'])[2]"));
        private IWebElement Online => Driver.driver.FindElement(By.XPath("(//input[@value='1'])[2]"));
        private IWebElement StartdateDropdown => Driver.driver.FindElement(By.XPath("//input[@name='startDate']"));
        private IWebElement EnddateDropdown => Driver.driver.FindElement(By.XPath("//input[@name='endDate']"));
        private IWebElement Days => Driver.driver.FindElement(By.XPath("(//input[@index='1'])[1]"));
        private IWebElement StartTime => Driver.driver.FindElement(By.XPath("//input[@name='StartTime' and @index='1' and @value]"));
        private IWebElement EndTimeDropdown => Driver.driver.FindElement(By.XPath("//input[@name='EndTime' and @index='1' and @value]"));
        private IWebElement SkillTradeOption => Driver.driver.FindElement(By.XPath("//input[@name='skillTrades' and @value='true']"));
        private IWebElement SkillExchange => Driver.driver.FindElement(By.XPath("(//input[@placeholder='Add new tag'])[2]"));
        private IWebElement Credit => Driver.driver.FindElement(By.XPath("(//input[@value='false'])[1]"));
        private IWebElement CreditValue => Driver.driver.FindElement(By.XPath("//input[@name='charge']"));
        private IWebElement Worksample => Driver.driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));
        private IWebElement StatusActive => Driver.driver.FindElement(By.XPath("(//input[@value='true'])[2]"));
        private IWebElement StatusHidden => Driver.driver.FindElement(By.XPath("//input[@name='isActive' and @value='false']"));
        private IWebElement Save => Driver.driver.FindElement(By.XPath("//input[@value='Save']"));
        private IWebElement Cancel => Driver.driver.FindElement(By.XPath("//input[@value='Cancel']"));
        private IWebElement MCategory => Driver.driver.FindElement(By.XPath("(//tr[1]//td[@class='one wide'])[2]"));
        private IWebElement MTitle => Driver.driver.FindElement(By.XPath("(//tr[1]//td[@class='four wide'])[1]"));
        private IWebElement MDescription => Driver.driver.FindElement(By.XPath("(//tr[1]//td[@class='four wide'])[2]"));
        private IWebElement MServiceType => Driver.driver.FindElement(By.XPath("(//tr[1]//td[@class='one wide'])[3]"));
        private IWebElement blueicon => Driver.driver.FindElement(By.XPath("//i[@class='blue check circle outline large icon']"));
        private IWebElement greyicon => Driver.driver.FindElement(By.XPath("(//i[@class='grey remove circle large icon'])[1]"));
       
        private IWebElement ClickActionbutton => Driver.driver.FindElement(By.XPath("//i[@class='checkmark icon']"));
        private IWebElement Editbutton => Driver.driver.FindElement(By.XPath("(//i[@class='outline write icon'])[1]"));
        
        public void AddShareSkill()
        {
            //Populate Excel data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ShareSkill");
            
            //Enter title
            Title.SendKeys(ExcelLibHelper.ReadData(2, "Title"));

            //Enter Description
            Description.SendKeys(ExcelLibHelper.ReadData(2, "Description"));

            // Select on Category Dropdown
            SelectElement catg = new SelectElement(Driver.driver.FindElement(By.XPath("//select")));
            catg.SelectByText(ExcelLibHelper.ReadData(2, "Category"));

            //Select on SubCategory Dropdown
            SelectElement subcatg = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='subcategoryId']")));
            subcatg.SelectByText(ExcelLibHelper.ReadData(2, "SubCategory"));

            //Enter Tag names in textbox
            Tags.SendKeys(ExcelLibHelper.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Return);

            //Select the Service type
            if (ExcelLibHelper.ReadData(2, "ServiceType") == "Hourly basis")
            {
                Hourly.Click();
            }
            else if (ExcelLibHelper.ReadData(2, "ServiceType") == "One-off")
            {
                Oneoff.Click();
            }

            //Select the Location type
            if (ExcelLibHelper.ReadData(2, "LocationType") == "On-site")
            {
                Onsite.Click();
            }
            else if (ExcelLibHelper.ReadData(2, "LocationType") == "Online")
            {
                Online.Click();
            }

            //Click on Start Date dropdown
            Driver.driver.FindElement(By.XPath("//input[@name='startDate']")).SendKeys(ExcelLibHelper.ReadData(2, "Startdate"));

            //Click on End Date dropdown
            Driver.driver.FindElement(By.XPath("//input[@name='endDate']")).SendKeys(ExcelLibHelper.ReadData(2, "Enddate"));

            //Select available days
            Days.Click();

            //Select startTime
            StartTime.SendKeys(ExcelLibHelper.ReadData(2, "Starttime"));

            //select endtime
            EndTimeDropdown.SendKeys(ExcelLibHelper.ReadData(2, "Endtime"));

            if (ExcelLibHelper.ReadData(2, "SkillTrade") == "Skill-Exchange")
            {

                //select SkillTradeOption
                SkillTradeOption.Click();
                //Enter SkillExchange
                SkillExchange.SendKeys(ExcelLibHelper.ReadData(2, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Return);

            }
            else if (ExcelLibHelper.ReadData(2, "SkillTrade") == "Credit")
            {

                Credit.Click();
                CreditValue.SendKeys(ExcelLibHelper.ReadData(2, "Credit"));
                CreditValue.SendKeys(Keys.Enter);
            }
            //Click worksample
            Worksample.Click();
            //Worksample.SendKeys("path");

            //upload file using AutoIT
            AutoItX3 autoit = new AutoItX3();
            //Activate so that next action happens on this window
            autoit.WinActivate("Open");
            //autoit.Send(@"D:\Shareskillmars\FileUploadScript.exe");
            autoit.Send(@"D:\Specflow-Mars\MarsQA-1\sample.txt");
            autoit.Send("{ENTER}");
            Thread.Sleep(10000);

            //Select user option
            if (ExcelLibHelper.ReadData(2, "UserStatus") == "Active")
            {
                StatusActive.Click();
            }
            else if (ExcelLibHelper.ReadData(2, "UserStatus") == "Hidden")
            {
                StatusHidden.Click();
            }

            //click save or cancel
            if (ExcelLibHelper.ReadData(2, "SaveOrCancel") == "Save")
            {
                Save.Click();
            }
            else if (ExcelLibHelper.ReadData(2, "SaveOrCancel") == "Cancel")
            {
                Cancel.Click();
            }
        }
        public void AssertAddShareSkill()
        {
            //Validate the service details saved by title
            Assert.AreEqual(MTitle.Text, ExcelLibHelper.ReadData(2, "Title"));

            //validate Category
            Assert.AreEqual(MCategory.Text, ExcelLibHelper.ReadData(2, "Category"));

            //validate Description
            Assert.AreEqual(MDescription.Text, ExcelLibHelper.ReadData(2, "Description"));

            //validate Servicetype
            Assert.AreEqual(MServiceType.Text, ExcelLibHelper.ReadData(2, "ServiceType"));
            
            //validate image of blue icon in skill trade
            var img = blueicon.Displayed;
            Assert.IsTrue(img);
        }
        public void EditShareSkill()
        {
            //Populate Excel data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ShareSkill");
           
            Editbutton.Click();
            //Enter title
            Title.SendKeys(ExcelLibHelper.ReadData(3, "Title"));

            //Enter Description
            Description.SendKeys(ExcelLibHelper.ReadData(3, "Description"));

            // Select on Category Dropdown
            SelectElement catg = new SelectElement(Driver.driver.FindElement(By.XPath("//select")));
            catg.SelectByText(ExcelLibHelper.ReadData(3, "Category"));

            //Select on SubCategory Dropdown
            SelectElement subcatg = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='subcategoryId']")));
            subcatg.SelectByText(ExcelLibHelper.ReadData(3, "SubCategory"));

            //Enter Tag names in textbox
            Tags.SendKeys(ExcelLibHelper.ReadData(3, "Tags"));
            Tags.SendKeys(Keys.Return);

            //Select the Service type
            if (ExcelLibHelper.ReadData(3, "ServiceType") == "Hourly basis")
            {
                Hourly.Click();
            }
            else if (ExcelLibHelper.ReadData(3, "ServiceType") == "One-off")
            {
                Oneoff.Click();
            }

            //Select the Location type
            if (ExcelLibHelper.ReadData(3, "LocationType") == "On-site")
            {
                Onsite.Click();
            }
            else if (ExcelLibHelper.ReadData(3, "LocationType") == "Online")
            {
                Online.Click();
            }

            //Click on Start Date dropdown
            StartdateDropdown.SendKeys(ExcelLibHelper.ReadData(3, "Startdate"));

            //Click on End Date dropdown
            EnddateDropdown.SendKeys(ExcelLibHelper.ReadData(3, "Enddate"));

            //Select available days
            Days.Click();

            //Select startTime
            StartTime.SendKeys(ExcelLibHelper.ReadData(3, "Starttime"));

            //select endtime
            EndTimeDropdown.SendKeys(ExcelLibHelper.ReadData(3, "Endtime"));

            if (ExcelLibHelper.ReadData(3, "SkillTrade") == "Skill-Exchange")
            {

                //select SkillTradeOption
                SkillTradeOption.Click();
                //Enter SkillExchange
                SkillExchange.SendKeys(ExcelLibHelper.ReadData(3, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Return);

            }
            else if (ExcelLibHelper.ReadData(3, "SkillTrade") == "Credit")
            {

                Credit.Click();
                CreditValue.SendKeys(ExcelLibHelper.ReadData(2, "Credit"));
                CreditValue.SendKeys(Keys.Enter);
            }
            //Click worksample
            Worksample.Click();
            //Worksample.SendKeys("path");

            //upload file using AutoIT
            AutoItX3 autoit = new AutoItX3();
            //Activate so that next action happens on this window
            autoit.WinActivate("Open");
            //autoit.Send(@"D:\Shareskillmars\FileUploadScript.exe");
            autoit.Send(@"D:\Specflow-Mars\MarsQA-1\sample.txt");
            autoit.Send("{ENTER}");
            Thread.Sleep(10000);

            //Select user option
            if (ExcelLibHelper.ReadData(3, "UserStatus") == "Active")
            {
                StatusActive.Click();
            }
            else if (ExcelLibHelper.ReadData(3, "UserStatus") == "Hidden")
            {
                StatusHidden.Click();
            }

            //click save or cancel
            if (ExcelLibHelper.ReadData(3, "SaveOrCancel") == "Save")
            {
                Save.Click();
            }
            else if (ExcelLibHelper.ReadData(3, "SaveOrCancel") == "Cancel")
            {
                Cancel.Click();
            }
        }
        public void AssertEditShareSkill()
        {
            //Validate the service details saved by title
            Assert.AreEqual(MTitle.Text,ExcelLibHelper.ReadData(3, "Title"));

            //validate Category
            Assert.AreEqual(MCategory.Text,ExcelLibHelper.ReadData(3, "Category"));

            //validate Description
            Assert.AreEqual(MDescription.Text,ExcelLibHelper.ReadData(3, "Description"));

            //validate Servicetype
            Assert.AreEqual(MServiceType.Text,ExcelLibHelper.ReadData(3, "ServiceType"));

            //validate image of blue icon in skill trade
            var img = greyicon.Displayed;
            Assert.IsTrue(img);
        }
       
    }
}
