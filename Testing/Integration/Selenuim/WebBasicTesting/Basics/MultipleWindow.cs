using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace WebBasicTesting.Basics
{
    public class MultipleWindow
    {
        private readonly ITestOutputHelper _output;

        public MultipleWindow(ITestOutputHelper output) 
        { 
            _output = output;
        }


        [Fact]
        public void TestMultipleWindow()
        {
            IWebDriver driver = new ChromeDriver
            {
                Url = "https://demoqa.com/browser-windows"
            };

            // store the present widow.

            string parentWindowHandle = driver.CurrentWindowHandle;

            _output.WriteLine($"Parent window's handle => {parentWindowHandle}");

            IWebElement clickElement = driver.FindElement(By.Id("windowButton"));

            // multiple click to open multuiple window

            for(var i = 0; i < 3; i++)
            {
                clickElement.Click();
                Thread.Sleep(3000);
            }

            // store all the open windows print list

            var windows = driver.WindowHandles.ToList();

            foreach (var window in windows)
            {
                _output.WriteLine($"Switching to window : {window}");
                driver.SwitchTo().Window(window);

                _output.WriteLine("Going to Google.");
                driver.Navigate().GoToUrl("https://google.com");
            }

            driver.Quit();
        }
    }
}
