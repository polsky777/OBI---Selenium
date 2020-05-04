using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
namespace SeleniumOBI.PageObject
{
    public class ResultPage
    {
        IWebDriver driver;
        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ("//*[@title = 'LUX Młotek ślusarski 200 g']"))]
        public IWebElement Image { get; set; }
        public ProductPage NavigateToProductPage()
        {
            Image.Click();

            return new ProductPage(driver);
        }
    }
}
