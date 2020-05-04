using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System;

namespace SeleniumOBI.PageObject
{
    public class ProductPage
    {
        IWebDriver driver;
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = ("//*[@class = 'h2 overview__heading']"))]
        public IWebElement ProductName { get; set; }
        [FindsBy(How = How.XPath, Using = ("//*[@data-ui-name = 'ads.price.strong']"))]
        public IWebElement ProductPrice { get; set; }
        public String getProductName()
        {
            return ProductName.Text;
        }
        public String getProductPrice()
        {
            return ProductPrice.Text;
        }
    }
}
