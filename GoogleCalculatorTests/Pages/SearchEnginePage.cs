using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
