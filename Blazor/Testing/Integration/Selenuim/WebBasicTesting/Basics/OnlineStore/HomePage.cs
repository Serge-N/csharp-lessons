using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebBasicTesting.Basics.OnlineStore
{
    public  class HomePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using ="account")]
        public IWebElement MyAccount { get; set; }
    }
}
