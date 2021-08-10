using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using Xunit.Abstractions;

namespace WebBasicTesting.Basics
{
    public class AlertsandPopUps
    {
        private readonly ITestOutputHelper _output;

        public AlertsandPopUps(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void AlertTest()
        {
            IWebDriver driver = new ChromeDriver
            {
                Url = "https://demoqa.com/alerts"
            };

            // click alert
            driver.FindElement(By.Id("alertButton")).Click();

            // trying to click another button while alert is present
            driver.FindElement(By.Id("confirmButton")).Click();
        }

        [Fact]
        public void AlertHandling()
        {
            IWebDriver driver = new ChromeDriver
            {
                Url = "https://demoqa.com/alerts"
            };

            driver.Manage().Window.Maximize();

            // click alert
            driver.FindElement(By.Id("alertButton")).Click();

            IAlert simpleAlert = driver.SwitchTo().Alert();

            _output.WriteLine($"Alert text is {simpleAlert.Text}");

            // accept , tip: use dismiss if present to dismiss
            simpleAlert.Accept();

            driver.Quit();
        }
    }
}
