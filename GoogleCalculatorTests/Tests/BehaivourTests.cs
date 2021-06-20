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
    public class BehaivourTests: TestBase
    {
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

    }
}
