using GoogleCalculatorTests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Firefox;

namespace GoogleCalculatorTests.Tests
{
    //Note: Usually tests should be in a separate project but for this test purpose all will be managed in one single project.
    public class CalculatorTests
    {
        private IWebDriver _driver;
        private readonly IConfiguration _configuration;

        public CalculatorTests(IConfiguration configuration)
        {
            _configuration = configuration;
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

            SetDriver();
            _driver.Navigate().GoToUrl(_configuration["URL"]);
            _driver.Manage().Window.Maximize();
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
