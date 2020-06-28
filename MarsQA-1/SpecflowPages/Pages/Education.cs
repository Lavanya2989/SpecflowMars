using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarsQA_1.SpecflowPages.Pages
{
    class Education
    {
        private IWebElement ClickAddnewE => Driver.driver.FindElement(By.XPath("(//div[contains(text(),'Add New')])[3]"));
        private IWebElement University => Driver.driver.FindElement(By.XPath("//input[@placeholder='College/University Name']"));
        private IWebElement Country => Driver.driver.FindElement(By.XPath("//select[@name='country']"));
        private IWebElement Title => Driver.driver.FindElement(By.XPath("//select[@name='title']"));
        private IWebElement Degree => Driver.driver.FindElement(By.XPath("//input[@name='degree']"));
        private IWebElement Year => Driver.driver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));
        private IWebElement SaveEdu => Driver.driver.FindElement(By.XPath("//div[@data-tab='third']//input[@value='Add']"));
        private IWebElement EditEdu => Driver.driver.FindElement(By.XPath("//div[@data-tab='third']//table//tbody//tr//td[6]//i[@class='outline write icon']"));
        private IWebElement UpdateEdu => Driver.driver.FindElement(By.XPath("//input[@value='Update']"));

        public void AddEducation()
        {
            //Populate excel data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //Click Add new
            ClickAddnewE.Click();
            //Enter University
            University.SendKeys(ExcelLibHelper.ReadData(2, "University"));
            //Enter country
            Country.SendKeys(ExcelLibHelper.ReadData(2, "Country"));
            //Enter title
            Title.SendKeys(ExcelLibHelper.ReadData(2, "Title"));
            //Enter Degree
            Degree.SendKeys(ExcelLibHelper.ReadData(2, "Degree"));
            //Enter year
            Year.SendKeys(ExcelLibHelper.ReadData(2, "YearOfGraduation"));
            //Click save
            SaveEdu.Click();
        }
        public void AssertEducation()
        {
            //Populate excel data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //Assert Country 
            String ActEdu = (Driver.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[1]"))).Text;
            Assert.AreEqual(ActEdu,ExcelLibHelper.ReadData(2, "Country"));

            //Assert University
            String ActEdu1 = (Driver.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[2]"))).Text;
            Assert.AreEqual(ActEdu1, ExcelLibHelper.ReadData(2, "University"));

            //Assert Title
            String ActEdu2 = (Driver.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[3]"))).Text;
            Assert.AreEqual(ActEdu2, ExcelLibHelper.ReadData(2, "Title"));

            //Assert Degree
            String ActEdu3 = (Driver.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[4]"))).Text;
            Assert.AreEqual(ActEdu3,ExcelLibHelper.ReadData(2, "Degree"));

            //Assert year of graduation
            String ActEdu4 = (Driver.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[5]"))).Text;
            Assert.AreEqual(ActEdu4,ExcelLibHelper.ReadData(2, "YearOfGraduation"));
        }
        public void EditEducation()
        {
            //Populate excel data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //Click edit button
            EditEdu.Click();
            //Update university
            University.Clear();
            University.SendKeys(ExcelLibHelper.ReadData(3, "University"));
            //Update country
            SelectElement Edit = new SelectElement(Country);
            Edit.SelectByText(ExcelLibHelper.ReadData(3, "Country"));
            //Update title
            Title.SendKeys(ExcelLibHelper.ReadData(3, "Title"));
            //Update degree
            Degree.Clear();
            Degree.SendKeys(ExcelLibHelper.ReadData(3, "Degree"));
            //Update year
            Year.SendKeys(ExcelLibHelper.ReadData(3, "YearOfGraduation"));
            //Click Update
            UpdateEdu.Click();
        }
        public void AssertEditEducation()
        {
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //Assert University
            String ActEdu1 = (Driver.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[2]"))).Text;
            Assert.AreEqual(ActEdu1,ExcelLibHelper.ReadData(3, "University"));

            //Assert Title
            String ActEdu2 = (Driver.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[3]"))).Text;
            Assert.AreEqual(ActEdu2,ExcelLibHelper.ReadData(3, "Title"));

            //Assert Degree
            String ActEdu3 = (Driver.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[4]"))).Text;
            Assert.AreEqual(ActEdu3,ExcelLibHelper.ReadData(3, "Degree"));

            //Assert year
            String ActEdu4 = (Driver.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[5]"))).Text;
            Assert.AreEqual(ActEdu4,ExcelLibHelper.ReadData(3, "YearOfGraduation"));
        }
    }
}
