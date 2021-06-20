using OpenQA.Selenium;

namespace GoogleCalculatorTests.Pages
{
    public class CalculatorPage
    {
        private IWebDriver _driver;

        public CalculatorPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Locators
        public IWebElement CalculatorContainer
        {
            get { return _driver.FindElement(By.ClassName("tyYmIf")); }
        }

        public IWebElement CalculatorScreenSummary
        {
            get { return _driver.FindElement(By.CssSelector("[jsname='ubtiRe']")); }
        }

        public IWebElement CalculatorScreenResult
        {
            get { return _driver.FindElement(By.CssSelector("[jsname='VssY5c']")); }
        }

        public IWebElement ACButton
        {
            get { return _driver.FindElement(By.XPath("//div[.='AC']")); }
        }

        public IWebElement SevenButton
        {
            get { return _driver.FindElement(By.XPath("//div[.='7']")); }
        }

        public IWebElement EightButton
        {
            get { return _driver.FindElement(By.XPath("//div[.='8']")); }
        }

        public IWebElement NineButton
        {
            get { return _driver.FindElement(By.XPath("//div[.='9']")); }
        }

        public IWebElement DivisionButton
        {
            get { return _driver.FindElement(By.XPath("//div[.='÷']")); }
        }

        public IWebElement FourButton
        {
            get { return _driver.FindElement(By.XPath("//div[.='4']")); }
        }

        public IWebElement FiveButton
        {
            get { return _driver.FindElement(By.XPath("//div[.='5']")); }
        }

        public IWebElement SixButton
        {
            get { return _driver.FindElement(By.XPath("//div[.='6']")); }
        }

        public IWebElement MultiplicationButton
        {
            get { return _driver.FindElement(By.CssSelector("[jsname='YovRWb']")); }
        }

        public IWebElement OneButton
        {
            get { return _driver.FindElement(By.XPath("//div[.='1']")); }
        }

        public IWebElement TwoButton
        {
            get { return _driver.FindElement(By.XPath("//div[.='2']")); }
        }

        public IWebElement ThreeButton
        {
            get { return _driver.FindElement(By.XPath("//div[.='3']")); }
        }

        public IWebElement SubstractionButton
        {
            get { return _driver.FindElement(By.CssSelector("[jsname='pPHzQc']")); }
        }

        public IWebElement ZeroButton
        {
            get { return _driver.FindElement(By.XPath("//div[.='0']")); }
        }

        public IWebElement DecimalButton
        {
            get { return _driver.FindElement(By.XPath("//div[.='.']")); }
        }

        public IWebElement EqualslButton
        {
            get { return _driver.FindElement(By.ClassName("UUhRt")); }
        }

        public IWebElement AddtionButton
        {
            get { return _driver.FindElement(By.XPath("//div[.='+']")); }
        }

        #endregion

    }
}
