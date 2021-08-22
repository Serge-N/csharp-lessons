using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebBasicTesting.Basics.OnlineStore;
using Xunit;


namespace WebBasicTesting.Basics.TestCases
{
    public class LoginTest
    {
        [Fact]
        public void LoginPageTest()
        {
            IWebDriver driver = new ChromeDriver
            {
                Url = "https://demoqa.com/books"
            };

            var homePage = new HomePage();
            // PageFactory.InitElements(driver, homePage);

            // this technique is obsolute, shift to use any other page lazy loading technique
            // iSSue Link : https://github.com/SeleniumHQ/selenium/issues/4387
            // Also note that Extras package has not being updated since 2018.
            // https://github.com/DotNetSeleniumTools/DotNetSeleniumExtras
        }
    }
}
