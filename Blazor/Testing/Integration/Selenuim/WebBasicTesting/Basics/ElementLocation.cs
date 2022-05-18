using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace WebBasicTesting.Basics
{
    public partial class ElementLocation
    {
        [Fact]
        private void FillFormTest()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://demoqa.com/text-box";

            // fill form
            driver.FindElement(By.Id("userName")).SendKeys("Serge");
            driver.FindElement(By.Id("userEmail")).SendKeys("nserge05@yahoo.com");
            driver.FindElement(By.Id("currentAddress")).SendKeys("Kitwe, Zambia");
            driver.FindElement(By.Id("permanentAddress")).SendKeys("Kafue, Zambia");
            driver.FindElement(By.Id("submit")).Click();

            // close
            driver.Close();
        }
    }
}
