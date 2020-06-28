using MarsQA_1.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_1.SpecflowPages.Helpers
{
    class CommonMethods
    {

       public static string TakeScreenshot(IWebDriver driver, string ScreenShotFileName)
        {
            string path1 = @"D:\Specflow-Mars\MarsQA-1\TestReports";
            string path = path1 + ".png";
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            //Append image
            var fileName = new StringBuilder(path1);
            fileName.Append(ScreenShotFileName);
            fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
            fileName.Append(".jpeg");

            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }


    }
}

