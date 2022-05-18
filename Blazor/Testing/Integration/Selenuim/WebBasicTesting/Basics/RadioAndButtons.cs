using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace WebBasicTesting.Basics
{
    public class RadioAndButtons
    {

        private readonly ITestOutputHelper output;
        public RadioAndButtons(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void WithSelectedTest()
        {
            IWebDriver driver = new ChromeDriver
            {
                Url = "https://demoqa.com/automation-practice-form"
            };

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // goal : - selected the button 
            IList<IWebElement> oRadioBtns = driver.FindElements(By.Name("gender"));

            // needs solution
            
            var fValue = oRadioBtns.ElementAt(0).Selected;

            if (fValue)
            {
                oRadioBtns.ElementAt(1).Click(); // female radio
            }
            else
            {
                oRadioBtns.ElementAt(0).Click(); // male radio
            }
            
            driver.Quit();
        }
    }
}
