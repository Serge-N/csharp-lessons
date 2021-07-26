using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RealQA
{
    public class FirstTestCase
    {
        public static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
        }
    }
}
