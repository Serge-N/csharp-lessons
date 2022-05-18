using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RealQA
{
    public class FirstTestCase
    {
        public static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver
            {
                Url = "https://www.google.com"
            };
        }
    }
}
