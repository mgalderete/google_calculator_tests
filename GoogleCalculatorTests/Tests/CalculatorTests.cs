using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Firefox;
using GoogleCalculatorTests.Pages;
using System.IO;

namespace GoogleCalculatorTests.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        public IWebDriver _driver;
        protected IConfiguration _configuration;

        /// <summary>
        /// Loads settings file
        /// </summary>
        public void InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            _configuration = config;
        }

        /// <summary>
        /// Set the correct driver depending of the "Browser" app setting.
        /// </summary>
        private void SetDriver()
        {
            switch (_configuration["Browser"])
            {
                case "Firefox":
                    _driver = new FirefoxDriver(); ;
                    break;
                case "Chrome":
                    _driver = new ChromeDriver("C:\\drivers");
                    break;
                default:
                    throw new Exception("Invalid browser");
            }
        }

        /// <summary>
        /// Initializes browser driver and required settings before each test execution.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            InitConfiguration();
            SetDriver();
            _driver.Navigate().GoToUrl(_configuration["URL"]);
            _driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_001
        /// Test Scenario: Verify that calculator is displayed after search for "calculator" in search engine page.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_001()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            Assert.IsTrue(calculatorPage.CalculatorContainer.Displayed);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_002
        /// Test Scenario: Verify that calculator is displayed with all the required elements.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_002()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            Assert.IsTrue(calculatorPage.CalculatorScreenSummary.Displayed);
            Assert.IsTrue(calculatorPage.CalculatorScreenResult.Displayed);
            Assert.IsTrue(calculatorPage.ACButton.Displayed);
            Assert.IsTrue(calculatorPage.SevenButton.Displayed);
            Assert.IsTrue(calculatorPage.EightButton.Displayed);
            Assert.IsTrue(calculatorPage.NineButton.Displayed);
            Assert.IsTrue(calculatorPage.DivisionButton.Displayed);
            Assert.IsTrue(calculatorPage.FourButton.Displayed);
            Assert.IsTrue(calculatorPage.FiveButton.Displayed);
            Assert.IsTrue(calculatorPage.SixButton.Displayed);
            Assert.IsTrue(calculatorPage.MultiplicationButton.Displayed);
            Assert.IsTrue(calculatorPage.OneButton.Displayed);
            Assert.IsTrue(calculatorPage.TwoButton.Displayed);
            Assert.IsTrue(calculatorPage.ThreeButton.Displayed);
            Assert.IsTrue(calculatorPage.SubtractionButton.Displayed);
            Assert.IsTrue(calculatorPage.ZeroButton.Displayed);
            Assert.IsTrue(calculatorPage.DecimalButton.Displayed);
            Assert.IsTrue(calculatorPage.EqualslButton.Displayed);
            Assert.IsTrue(calculatorPage.AddtionButton.Displayed);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_003
        /// Test Scenario: Verify that clicked digit button is displayed in calculator virtual screen.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_003()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.OneButton.Click();


            Assert.AreEqual("1", calculatorPage.CalculatorScreenResult.Text);
        }

        /// <summary>
        /// Test Case ID: From TC_CALCULATOR_004 to TC_CALCULATOR_008
        /// Test Scenario: Verify that calculator is displayed after search for "calculator" in search engine page.
        /// </summary>
        [Test]
        [TestCase("2+3")]
        [TestCase("1+2+2")]
        [TestCase("5+9+7+8+9+3+4+1+6")]
        [TestCase("62+75+84")]
        [TestCase("2-3")]
        [TestCase("5-9-7-8-9-3-4-1-6")]
        [TestCase("234-569-261-458")]
        [TestCase("99537+3586-74")]
        [TestCase("819-652+4.9+8.3")]
        [TestCase("8x40x38")]
        [TestCase("7.86x5.41")]
        [TestCase("796÷125")]
        [TestCase("5÷0")]
        [TestCase("52x33+9.1÷6")]
        [TestCase("34-75÷6.294")]
        [TestCase("7-2.5+46x8÷2")]
        public void TC_CALCULATOR_ANY_ARITHMETIC_OPERATION(string operation)
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            decimal localCalculation = calculatorPage.Calculate(operation);
            decimal googleCalculation = calculatorPage.GoogleCalculation(operation);

            Assert.AreEqual(localCalculation, googleCalculation);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_019
        /// Test Scenario: Verify that summary of calculation is displayed above result in calculator virtual screen.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_019()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.SevenButton.Click();
            calculatorPage.SubtractionButton.Click();

            calculatorPage.TwoButton.Click();
            calculatorPage.DecimalButton.Click();
            calculatorPage.FiveButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.FourButton.Click();
            calculatorPage.SixButton.Click();
            calculatorPage.MultiplicationButton.Click();

            calculatorPage.EightButton.Click();
            calculatorPage.DivisionButton.Click();

            calculatorPage.TwoButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.AreEqual("7-2.5+((46x8/2))=", calculatorPage.CalculatorScreenSummary.Text);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_020
        /// Test Scenario: Verify that result is displayed in exponential notation if is made up of more than 12 digits.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_020()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.NineButton.Click();
            calculatorPage.NineButton.Click();
            calculatorPage.NineButton.Click();
            calculatorPage.NineButton.Click();
            calculatorPage.NineButton.Click();
            calculatorPage.NineButton.Click();
            calculatorPage.NineButton.Click();
            calculatorPage.NineButton.Click();
            calculatorPage.NineButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.NineButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.IsTrue(calculatorPage.CalculatorScreenSummary.Text.Contains("e+"));
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_021
        /// Test Scenario: Verify that "AC" button erase correctly the summary of the calculation by performing two different operations.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_021()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.TwoButton.Click();
            calculatorPage.AddtionButton.Click();
            calculatorPage.ThreeButton.Click();

            Assert.AreEqual("5", calculatorPage.CalculatorScreenResult.Text);

            calculatorPage.ACButton.Click();

            Assert.AreEqual("0", calculatorPage.CalculatorScreenResult.Text);

            calculatorPage.SixButton.Click();
            calculatorPage.DivisionButton.Click();
            calculatorPage.TwoButton.Click();
            calculatorPage.DecimalButton.Click();
            calculatorPage.FiveButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.AreEqual("2.4", calculatorPage.CalculatorScreenResult.Text);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_020
        /// Test Scenario: Verify that after perform an operation and click "AC" button the summary of the calculation is displayed in correct format.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_022()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.SevenButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.TwoButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.AreEqual("9", calculatorPage.CalculatorScreenResult.Text);

            calculatorPage.ACButton.Click();
            Assert.AreEqual("Ans=9", calculatorPage.CalculatorScreenSummary.Text);
        }

        /// <summary>
        /// Close driver instance after test execution.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}
