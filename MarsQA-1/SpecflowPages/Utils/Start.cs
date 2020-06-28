using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

using AventStack.ExtentReports.Gherkin.Model;
using NUnit.Framework.Internal;
using MarsQA_1.SpecflowPages.Helpers;
using OpenQA.Selenium;

namespace MarsQA_1.Utils
{
    [Binding]
    public class Start : Driver
    {
        
        private static ScenarioContext _scenarioContext;
        //private static FeatureContext _featureContext;
        private static ExtentReports _extentReports;
        private static ExtentHtmlReporter _extentHtmlReporter;
        private static ExtentTest feature;
        private static ExtentTest _scenario;
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _extentHtmlReporter = new ExtentHtmlReporter(@"D:\Specflow-Mars\MarsQA-1\TestReports");
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(_extentHtmlReporter);

        }
        [BeforeFeature]
        public static void BeforeFeatureStart(FeatureContext featureContext)
        {
            if(null!=featureContext)
            {
               
                feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title,featureContext.FeatureInfo.Description);
            }
        }
       
        [BeforeScenario]
        public static void BeforScenarioStart (ScenarioContext scenarioContext)
        {
            
                //launch the browser
                Initialize();
                ExcelLibHelper.PopulateInCollection(@"D:\Specflow-Mars\MarsQA-1\Excel data\TestDataMars.xlsx", "SignIn");
                //call the SignIn class
                SignIn.GivenLoginToTheWebsite();
                SignIn.WhenIEnterValidUsernameAndPassword();
                SignIn.ThenIShouldBeAtTheHomepage();
            
            if (null!=scenarioContext)
            {
                _scenarioContext = scenarioContext;
                _scenario= feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
            }
        }
        [AfterStep]
        public void AfterEachStep()
        {
            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;
            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    CreateNode<Given>();
                    break;
                   
                case ScenarioBlock.When:
                    CreateNode<When>();
                    break;

                case ScenarioBlock.Then:
                    CreateNode<Then>();
                    break;

                default:
          
                    CreateNode<And>();
                    break;
            }
        }
        public void CreateNode<T>()where T:IGherkinFormatterModel
        {
            if (_scenarioContext.TestError != null)
            {
                string name = @"D:\Specflow-Mars\MarsQA-1\TestReports" + _scenarioContext.ScenarioInfo.Title.Replace(" ", "") + ".jpeg";
                CommonMethods.TakeScreenshot(driver, name);
                _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Fail
                    (_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace).AddScreenCaptureFromPath(name);
            }
            else
            {
                string name = @"D:\Specflow-Mars\MarsQA-1\TestReports" + _scenarioContext.ScenarioInfo.Title.Replace(" ", "") + ".jpeg";
                CommonMethods.TakeScreenshot(driver, name);
                _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Pass("").AddScreenCaptureFromPath(name);
            }
        }
            

        [AfterTestRun]
        public static void AfterTestRun()
        {
            //Flush report once test completes
            _extentReports.Flush();
        }
       
        [AfterScenario]
        public void TearDown()
        {
                        
            Driver.driver.Quit();
           
        }
       
    }
}
