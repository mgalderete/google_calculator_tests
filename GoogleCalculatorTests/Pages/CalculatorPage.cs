using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCalculatorTests.Pages
{
    public class CalculatorPage
    {
        private IWebDriver _driver;

        public CalculatorPage(IWebDriver driver)
        {
            _driver = driver;
        }


    }
}
