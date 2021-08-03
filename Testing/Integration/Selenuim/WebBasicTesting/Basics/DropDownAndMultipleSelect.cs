using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            output.WriteLine(element.TagName);

            driver.Close();
        }

    }
}
