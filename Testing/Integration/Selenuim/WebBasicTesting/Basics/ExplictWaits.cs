using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;
using Xunit.Abstractions;

namespace WebBasicTesting.Basics
{
    public class ExplictWaits
    {

        private readonly ITestOutputHelper output;
        public ExplictWaits(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestDriverWait()
        {
            IWebDriver driver = new ChromeDriver
            {
                Url = "https://demoqa.com/automation-practice-form"
            };

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));


            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                output.WriteLine("Waiting for color to change");

                IWebElement element = Web.FindElement(By.Id("target"));

                if (element.GetAttribute("style").Contains("red"))
                {
                    return true;
                }
                return false;
            });

            wait.Until(waitForElement);
        }


        [Fact]
        public void TestDefaulttWait()
        {
            IWebDriver driver = new ChromeDriver
            {
                Url = "https://toolsqa.com/automation-practice-switch-windows/"
            };

            IWebElement element = driver.FindElement(By.Id("colorVar"));

            DefaultWait<IWebElement> wait = new(element)
            {
                Timeout = TimeSpan.FromMinutes(2),
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };

            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
            {
                var styleAttrib = element.GetAttribute("style");

                if (styleAttrib.Contains("red"))
                {
                    return true;
                }

                Console.WriteLine("Color is still " + styleAttrib);

                return false;
            });

            wait.Until(waiter);
        }

    }
}
