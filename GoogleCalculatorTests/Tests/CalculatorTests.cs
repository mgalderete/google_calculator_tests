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
        /// Test Case ID: TC_CALCULATOR_004
        /// Test Scenario: Verify that the result of the addition of two 1-digit numbers is correct.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_004()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.TwoButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.ThreeButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.AreEqual("5", calculatorPage.CalculatorScreenResult.Text);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_005
        /// Test Scenario: Verify that the result of the addition of three 1-digit numbers is correct.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_005()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.OneButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.TwoButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.TwoButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.AreEqual("5", calculatorPage.CalculatorScreenResult.Text);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_006
        /// Test Scenario: Verify that the result of the addition of nine 1-digit numbers is correct.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_006()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.FiveButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.NineButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.SevenButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.EightButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.NineButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.ThreeButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.FourButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.OneButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.SixButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.AreEqual("52", calculatorPage.CalculatorScreenResult.Text);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_007
        /// Test Scenario: Verify that the result of the addition of three 2-digit numbers  is correct.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_007()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.SixButton.Click();
            calculatorPage.TwoButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.SevenButton.Click();
            calculatorPage.FiveButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.EightButton.Click();
            calculatorPage.FourButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.AreEqual("221", calculatorPage.CalculatorScreenResult.Text);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_008
        /// Test Scenario: Verify that the result of the subtraction of two 1-digit numbers is correct.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_008()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.TwoButton.Click();
            calculatorPage.SubtractionButton.Click();

            calculatorPage.ThreeButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.AreEqual("-1", calculatorPage.CalculatorScreenResult.Text);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_009
        /// Test Scenario: Verify that the result of the subtraction of nine 1-digit numbers is correct.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_009()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.FiveButton.Click();
            calculatorPage.SubtractionButton.Click();

            calculatorPage.NineButton.Click();
            calculatorPage.SubtractionButton.Click();

            calculatorPage.SevenButton.Click();
            calculatorPage.SubtractionButton.Click();

            calculatorPage.EightButton.Click();
            calculatorPage.SubtractionButton.Click();

            calculatorPage.NineButton.Click();
            calculatorPage.SubtractionButton.Click();

            calculatorPage.ThreeButton.Click();
            calculatorPage.SubtractionButton.Click();

            calculatorPage.FourButton.Click();
            calculatorPage.SubtractionButton.Click();

            calculatorPage.OneButton.Click();
            calculatorPage.SubtractionButton.Click();

            calculatorPage.SixButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.AreEqual("-42", calculatorPage.CalculatorScreenResult.Text);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_010
        /// Test Scenario: Verify that the result subtraction of four 3-digit numbers  is correct.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_010()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.TwoButton.Click();
            calculatorPage.ThreeButton.Click();
            calculatorPage.FourButton.Click();
            calculatorPage.SubtractionButton.Click();

            calculatorPage.FiveButton.Click();
            calculatorPage.SixButton.Click();
            calculatorPage.NineButton.Click();
            calculatorPage.SubtractionButton.Click();

            calculatorPage.TwoButton.Click();
            calculatorPage.SixButton.Click();
            calculatorPage.OneButton.Click();
            calculatorPage.SubtractionButton.Click();

            calculatorPage.FourButton.Click();
            calculatorPage.FiveButton.Click();
            calculatorPage.EightButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.AreEqual("-1414", calculatorPage.CalculatorScreenResult.Text);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_011
        /// Test Scenario: Verify that the result of the sum of a 5-digit number plus a 4-digit number minus a 2-digit number is correct.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_011()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.NineButton.Click();
            calculatorPage.NineButton.Click();
            calculatorPage.FiveButton.Click();
            calculatorPage.ThreeButton.Click();
            calculatorPage.SevenButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.ThreeButton.Click();
            calculatorPage.FiveButton.Click();
            calculatorPage.EightButton.Click();
            calculatorPage.SixButton.Click();
            calculatorPage.SubtractionButton.Click();

            calculatorPage.SevenButton.Click();
            calculatorPage.FourButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.AreEqual("103197", calculatorPage.CalculatorScreenResult.Text);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_012
        /// Test Scenario: Verify that the result of the subtraction of 3-digit number minus 2-digit number plus the sum of two 2-digit decimal numbers is correct.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_012()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.EightButton.Click();
            calculatorPage.OneButton.Click();
            calculatorPage.NineButton.Click();
            calculatorPage.SubtractionButton.Click();

            calculatorPage.SixButton.Click();
            calculatorPage.FiveButton.Click();
            calculatorPage.TwoButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.FourButton.Click();
            calculatorPage.DecimalButton.Click();
            calculatorPage.NineButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.EightButton.Click();
            calculatorPage.DecimalButton.Click();
            calculatorPage.ThreeButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.AreEqual("180.2", calculatorPage.CalculatorScreenResult.Text);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_013
        /// Test Scenario: Verify that the result of the multiplication of a 1-digit number by two 2-digit  numbers is correct.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_013()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.EightButton.Click();
            calculatorPage.MultiplicationButton.Click();

            calculatorPage.FourButton.Click();
            calculatorPage.ZeroButton.Click();
            calculatorPage.MultiplicationButton.Click();

            calculatorPage.ThreeButton.Click();
            calculatorPage.EightButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.AreEqual("12160", calculatorPage.CalculatorScreenResult.Text);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_014
        /// Test Scenario: Verify that the result of the multiplication of two  1-digit number with 2 decimals each is correct.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_014()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.SevenButton.Click();
            calculatorPage.DecimalButton.Click();
            calculatorPage.EightButton.Click();
            calculatorPage.SixButton.Click();
            calculatorPage.MultiplicationButton.Click();

            calculatorPage.FiveButton.Click();
            calculatorPage.DecimalButton.Click();
            calculatorPage.FourButton.Click();
            calculatorPage.OneButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.AreEqual("42.5226", calculatorPage.CalculatorScreenResult.Text);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_015
        /// Test Scenario: Verify that the result of the division of two 3-digit numbers is correct.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_015()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.SevenButton.Click();
            calculatorPage.NineButton.Click();
            calculatorPage.SixButton.Click();
            calculatorPage.DivisionButton.Click();

            calculatorPage.OneButton.Click();
            calculatorPage.TwoButton.Click();
            calculatorPage.FiveButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.AreEqual("6.368", calculatorPage.CalculatorScreenResult.Text);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_016
        /// Test Scenario: Verify that division by 0  returns "Infinity "as result.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_016()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.FiveButton.Click();
            calculatorPage.DivisionButton.Click();
            calculatorPage.ZeroButton.Click();

            Assert.AreEqual("Infinity", calculatorPage.CalculatorScreenResult.Text);
        }


        /// <summary>
        /// Test Case ID: TC_CALCULATOR_017
        /// Test Scenario: Verify that the multiplication of two 2-digit numbers plus the sum of one 1-digit number with one decimal divided by a 1-digit number is correct.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_017()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.FiveButton.Click();
            calculatorPage.TwoButton.Click();
            calculatorPage.MultiplicationButton.Click();

            calculatorPage.ThreeButton.Click();
            calculatorPage.ThreeButton.Click();
            calculatorPage.AddtionButton.Click();

            calculatorPage.NineButton.Click();
            calculatorPage.DecimalButton.Click();
            calculatorPage.OneButton.Click();
            calculatorPage.DivisionButton.Click();

            calculatorPage.SixButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.AreEqual("1717.51666667", calculatorPage.CalculatorScreenResult.Text);
        }

        /// <summary>
        /// Test Case ID: TC_CALCULATOR_018
        /// Test Scenario: Verify that the result of the subtraction of two 2-digit numbers divided by a 1-digit number with three decimals is correct.
        /// </summary>
        [Test]
        public void TC_CALCULATOR_018()
        {
            SearchEnginePage searchEnginePage = new SearchEnginePage(_driver);
            CalculatorPage calculatorPage = searchEnginePage.goToCalculatorPage();

            calculatorPage.ThreeButton.Click();
            calculatorPage.FourButton.Click();
            calculatorPage.SubtractionButton.Click();

            calculatorPage.SevenButton.Click();
            calculatorPage.FiveButton.Click();
            calculatorPage.DivisionButton.Click();

            calculatorPage.SixButton.Click();
            calculatorPage.DecimalButton.Click();
            calculatorPage.TwoButton.Click();
            calculatorPage.NineButton.Click();
            calculatorPage.FourButton.Click();
            calculatorPage.EqualslButton.Click();

            Assert.AreEqual("22.0838894185", calculatorPage.CalculatorScreenResult.Text);
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
