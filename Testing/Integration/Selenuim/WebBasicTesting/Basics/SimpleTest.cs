using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using Xunit.Abstractions;

namespace WebBasicTesting.Basics
{
    public class SimpleTest
    {

        private readonly ITestOutputHelper output;
        public  SimpleTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void BasicTest()
        {

            IWebDriver driver = new ChromeDriver
            {
                Url = "https://www.demoqa.com"
            };

            string Title = driver.Title;

            int TitleLength = Title.Length;

            output.WriteLine($"The title of the page is : {Title}");
            output.WriteLine($"The Length of the page is : {TitleLength}");

            string PageUrl = driver.Url;
            int URLLength = PageUrl.Length;

            output.WriteLine($"The url of the page is : {PageUrl}");
            output.WriteLine($"The Length of url is : {URLLength}");

            string PageSource = driver.PageSource;
            int PageSourceLength = PageSource.Length;

            output.WriteLine($"The page source is as follows: \n {PageSource}");
            output.WriteLine($"The page source length is : {PageSourceLength}");

            driver.Quit();
        }

        [Fact]
        public void CloseTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://demoqa.com/browser-windows";
            driver.FindElement(By.Id("tabButton")).Click();
            driver.Close();

            // The point here is chrome will close only one window with Close and will close all with Quit
        }
    }
}
