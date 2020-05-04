using SeleniumOBI.BaseClass;
using SeleniumOBI.PageObject;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;

namespace SeleniumOBI.TestSuites
{
    [TestFixture]
    public class OBIProducts : BaseTest
    {
        ExtentReports extentReport = null;
        [SetUp]
        public void ExtentStart()
        {
            extentReport = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Tomek\Desktop\OBI\SeleniumOBI\SeleniumOBI\TestReport\Report.html");
            extentReport.AttachReporter(htmlReporter);
        }
        [TearDown]
        public void ExtentClose()
        {
            extentReport.Flush();
        }

        ExtentTest test = null;

        [Test]
        public void LuxMlotekSlusarski200()
        {
            try
            {
                test = extentReport.CreateTest("LuxMlotekSlusarski200").Info("Test Started");

                var searchPage = new StartPage(driver);
                test.Log(Status.Info, "Chrome Browser launched");
                var productImage = searchPage.NavigateToResultPage();
                test.Log(Status.Info, "List of Products launched");
                var productPage = productImage.NavigateToProductPage();
                test.Log(Status.Info, "Product Info launched");
                String actualProductName = productPage.getProductName();
                String expectedProductName = "LUX Młotek ślusarski 200 g";

                String actualProductPrice = productPage.getProductPrice();
                String expectedProductPrice = "8,99";

                Assert.AreEqual(expectedProductName, actualProductName, $"Name of {expectedProductName} is incorrect");
                test.Log(Status.Pass, "Test 1 : Product Name -  passed");
                Assert.AreEqual(expectedProductPrice, actualProductPrice, $"Amount {expectedProductPrice} is incorrect");
                test.Log(Status.Pass, "Test 2 : Product Price -  passed");
            }
            catch (Exception e)
            {
                ITakesScreenshot ts = driver as ITakesScreenshot;
                Screenshot screenshot = ts.GetScreenshot();
                screenshot.SaveAsFile("C:\\Users\\Tomek\\Desktop\\OBI\\SeleniumOBI\\SeleniumOBI\\TestReport\\s1.png", ScreenshotImageFormat.Png);
                test.Log(Status.Fail, e.ToString());

                throw;
            }

            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }

        }

    }
}
