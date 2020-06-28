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
    class Certification
    {
        private IWebElement ClickAddnew => Driver.driver.FindElement(By.XPath("(//div[contains(text(),'Add New')])[4]"));
        private IWebElement AddCert => Driver.driver.FindElement(By.XPath("//input[@name='certificationName']"));
        private IWebElement AddCertFrom => Driver.driver.FindElement(By.XPath("//input[@name='certificationFrom']"));
        private IWebElement AddYear => Driver.driver.FindElement(By.XPath("//select[@name='certificationYear']"));
        private IWebElement SaveCert => Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//input[@value='Add']"));
        private IWebElement EditCert => Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//table//tbody//tr//td[4]//i[@class='outline write icon']"));
        private IWebElement UpdateCert => Driver.driver.FindElement(By.XPath("//input[@value='Update']"));

        public void AddCertification()
        {
            //Populate excel data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //Click addnew
            ClickAddnew.Click();
            //Add certificate
            AddCert.SendKeys(ExcelLibHelper.ReadData(2, "Certificate"));
            //Add certfrom
            AddCertFrom.SendKeys(ExcelLibHelper.ReadData(2, "From"));
            //Add year
            AddYear.SendKeys(ExcelLibHelper.ReadData(2, "Year"));
            //click save
            SaveCert.Click();
        }
        public void AssertCert()
        {
            //Populate excel data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            String ActCer = (Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody//tr[1]//td[1]"))).Text;
            Assert.AreEqual(ActCer,ExcelLibHelper.ReadData(2, "Certificate"));

            //Assert From
            String ActCerF = (Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody//tr[1]//td[2]"))).Text;
            Assert.AreEqual(ActCerF,ExcelLibHelper.ReadData(2, "From"));

            //Assert year
            String ActCerY = (Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody//tr[1]//td[3]"))).Text;
            Assert.AreEqual(ActCerY,ExcelLibHelper.ReadData(2, "Year"));
        }
        public void EditCertfication()
        {
            //Populate excel data
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");
            //Click edit
            EditCert.Click();
            //Enter certificate
            AddCert.Clear();
            AddCert.SendKeys(ExcelLibHelper.ReadData(3, "Certificate"));
            //Enter from
            AddCertFrom.Clear();
            AddCertFrom.SendKeys(ExcelLibHelper.ReadData(3, "From"));
            //Enter year
            AddYear.SendKeys(ExcelLibHelper.ReadData(3, "Year"));
            //Update certificate
            UpdateCert.Click();
        }
        public void AssertEditCert()
        {
            ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "ProfilePage");

            //Assert
            //String ActCerC = (Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody//tr[1]//td[1]"))).Text;
            //Assert.AreEqual(ActCerC, ExcelLibHelper.ReadData(3, "Certificate"));
            Driver.TurnOnWait();

            //Assert Certification from
            String ActCerF = (Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody//tr[1]//td[2]"))).Text;
            Assert.AreEqual(ActCerF,ExcelLibHelper.ReadData(3, "From"));

            //Assert Certification year
            String ActCerY = (Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody//tr[1]//td[3]"))).Text;
            Assert.AreEqual(ActCerY,ExcelLibHelper.ReadData(3, "Year"));
        }
    }
}
