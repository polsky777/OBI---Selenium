using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumOBI.BaseClass
{

    public class BaseTest
    {
     
        public IWebDriver driver;

        [SetUp]
        public void Open()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.obi.pl/";
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}

