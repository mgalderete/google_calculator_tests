using OpenQA.Selenium;

namespace GoogleCalculatorTests.Pages
{
    public class SearchEnginePage
    {
        private IWebDriver _driver;

        public SearchEnginePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement SearchBar
        {
            get { return _driver.FindElement(By.Name("q")); }
        }

        public CalculatorPage goToCalculatorPage()
        {
            SearchBar.SendKeys("Calculator");
            SearchBar.SendKeys(Keys.Enter);
            return new CalculatorPage(_driver);
        }
    }
}
