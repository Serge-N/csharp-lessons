using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace WebBasicTesting.Basics
{
    public class NavigationTest
    {
        [Fact]
        private void BasicNav()
        {
            //IWebDriver driver = new InternetExplorerDriver("./");

            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://www.demoqa.com";

            driver.FindElement(By.ClassName("banner-image")).Click();

            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().Refresh();

            driver.Close();
        }
    }
}
