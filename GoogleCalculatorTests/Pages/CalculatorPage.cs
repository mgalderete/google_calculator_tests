using OpenQA.Selenium;
using System;
using System.Data;

namespace GoogleCalculatorTests.Pages
{
    public class CalculatorPage : SearchEnginePage
    {
        private IWebDriver _driver;

        public CalculatorPage(IWebDriver driver) : base(driver)
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

        public IWebElement SubtractionButton
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

        /// <summary>
        /// Description: This method performs any arithmetic operation contained in a string, useful to have a comparative value.
        /// </summary>

        public decimal Calculate(string operation)
        {
            operation = operation.Replace("x", "*").Replace("÷", "/");
            DataTable dt = new DataTable();

            decimal result = Convert.ToDecimal(dt.Compute(operation, ""));
            return Math.Round(result, 1);
        }

        /// <summary>
        /// Description: This method performs any arithmetic operation contained in a string in Goolge's calculator.
        /// </summary>
        public decimal GoogleCalculation(string operation)
        {
            try
            {
                operation = operation.Replace("*", "x").Replace("/", "÷");

                foreach (char digit in operation)
                {
                    switch (digit)
                    {
                        case 'x':
                            CalculatorContainer.FindElement(By.CssSelector("[jsname='YovRWb']")).Click();
                            break;
                        case '-':
                            CalculatorContainer.FindElement(By.CssSelector("[jsname='pPHzQc']")).Click();
                            break;
                        default:
                            CalculatorContainer.FindElement(By.XPath($"//div[.='{digit}']")).Click();
                            break;

                    }
                }

                EqualslButton.Click();

                decimal result = Convert.ToDecimal(CalculatorScreenResult.Text);
                return Math.Round(result, 1);
            }
            catch(InvalidCastException ex)
            {
                return 0;
            }            
        }


    }
}
