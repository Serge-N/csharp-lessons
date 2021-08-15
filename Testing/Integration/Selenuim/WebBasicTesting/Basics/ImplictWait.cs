using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebBasicTesting.Basics
{
    public class ImplictWait
    {
        [Fact]
        public void TestImplictWait()
        {
            IWebDriver driver = new ChromeDriver
            {
                Url = "https://demoqa.com/alerts"
            };
            
             // this function was called ImplicitlyWait. Watch out for it old code.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(500);

            IWebElement element = driver.FindElement(By.Id("target"));
        }

    }
}
