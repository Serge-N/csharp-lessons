using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using WebBasicTesting.Basics.TestDataAccess;
using Xunit;

namespace WebBasicTesting.Basics.OnlineStore
{
    public class LoginPage
    {
        [Fact]
        public void Login()
        {
            IWebDriver driver = new ChromeDriver
            {
                Url = "https://www.demoqa.com/login"
            };

            // arrange
            driver.Manage().Window.Maximize();

            var dataAccess = new ExcelDataAccess();
            var user = dataAccess.CreateUser();

            // act
            var name = driver.FindElement(By.Id("userName"));
            name.SendKeys(user.UserName);

            var password = driver.FindElement(By.Id("password"));
            password.SendKeys(user.Password);

            driver.FindElement(By.Id("login")).Click();

            var expectedPage = "https://www.demoqa.com/profile";
            Thread.Sleep(2000);
            var currentPage = driver.Url;

            // assert
            Assert.Equal(expectedPage, currentPage);
            Thread.Sleep(5000);
            driver.Close();
        }

    }
}
