using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace SeleniumOBI.PageObject
{
    public class StartPage
    {
        IWebDriver driver;
        public StartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = ("//*[@class = 'search-input primary js-searchfield']"))]
        public IWebElement SearchTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = ("//*[@class = 'icon icon--square icon--arrow-right-white']"))]
        public IWebElement SearchButton { get; set; }

        public ResultPage NavigateToResultPage()
        {
            SearchTextBox.SendKeys("Młotek ślusarski 200 g");
            SearchButton.Click();
            return new ResultPage(driver);

        }
    }
}
