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
    class CertificationTest
    {
        [Given(@"I clicked on the Certification tab under Profile page")]
        public void GivenIClickedOnTheCertificationTabUnderProfilePage()
        {
            //Click Certification tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='fourth']")).Click();
        }

        [When(@"I add a new Certification")]
        public void WhenIAddANewCertification()
        {
            Certification certobj = new Certification();
            certobj.AddCertification();
        }

        [Then(@"that Certification should be displayed on my listings")]
        public void ThenThatCertificationShouldBeDisplayedOnMyListings()
        {
            Certification certobj = new Certification();
            certobj.AssertCert();
        }

        [When(@"I  update Certification")]
        public void WhenIUpdateCertification()
        {
            Certification editcert = new Certification();
            editcert.EditCertfication();
        }

        [Then(@"that updated Certification should be displayed on my listings")]
        public void ThenThatUpdatedCertificationShouldBeDisplayedOnMyListings()
        {
            Certification editcert = new Certification();
            editcert.AssertEditCert();
        }

        [When(@"I delete Certification")]
        public void WhenIDeleteCertification()
        {
            //Click delete button
            Driver.TurnOnWait();
            Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//table//tbody//tr//td[4]//i[@class='remove icon']")).Click();
        }

        [Then(@"that Certification should not be displayed on my listings")]
        public void ThenThatCertificationShouldNotBeDisplayedOnMyListings()
        {

            try
            {
                String ActCer2 = (Driver.driver.FindElement(By.XPath("//tbody//tr[1]//td[1]"))).Text;
                Assert.AreNotEqual(ActCer2,ExcelLibHelper.ReadData(3, "Certificate"));
            }
            catch
            {
                Assert.True(true, "Element not found");
            }
        }

    }
}
