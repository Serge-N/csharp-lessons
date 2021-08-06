using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;
using Xunit.Abstractions;

namespace WebBasicTesting.Basics
{
    public class DropDownAndMultipleSelect
    {
        private readonly ITestOutputHelper output;
        public DropDownAndMultipleSelect(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void DropDownTest()
        {
            IWebDriver driver = new ChromeDriver();
     
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Url = "https://demoqa.com/automation-practice-form";

            var element = driver.FindElement(By.CssSelector("css-1wa3eu0-placeholder"));

            output.WriteLine(element.TagName); // The css seletors where not found.

            driver.Close();
        }

    }
}
