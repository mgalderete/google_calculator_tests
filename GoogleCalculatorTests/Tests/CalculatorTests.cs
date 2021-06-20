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
    //Note: Usually tests should be in a separate project but for this test purpose all will be managed in one single project.
    [TestFixture]
    public class CalculatorTests
    {
        private IWebDriver _driver;
        private IConfiguration _configuration;

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
            Assert.IsTrue(calculatorPage.SubstractionButton.Displayed);
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
        /// Close driver instance after test execution.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}
