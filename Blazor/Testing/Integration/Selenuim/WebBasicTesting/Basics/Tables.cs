using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace WebBasicTesting.Basics
{
    public partial class Tables
    {
        private readonly ITestOutputHelper output;

        public Tables(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void DynamicTableTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // WebPage which contains a WebTable
            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Programming_languages_used_in_most_popular_websites");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            // xpath of html table
            IWebElement elemTable = driver.FindElement(By.XPath("//div[@id='mw-content-text']//table[1]"));

            // Fetch all Row of the table
            List<IWebElement> lstTrElem = new(elemTable.FindElements(By.TagName("tr")));
            String strRowData = "";

            // Traverse each row
            foreach (var elemTr in lstTrElem)
            {
                // Fetch the columns from a particuler row
                List<IWebElement> lstTdElem = new(elemTr.FindElements(By.TagName("td")));

                if (lstTdElem.Count > 0)
                {
                    // Traverse each column
                    foreach (var elemTd in lstTdElem)
                    {
                        // "\t\t" is used for Tab Space between two Text
                        strRowData = strRowData + elemTd.Text + "\t\t";
                    }
                }
                else
                {
                    // To print the data into the output
                    output.WriteLine("This is Header Row");
                    output.WriteLine(lstTrElem[0].Text.Replace(" ", "\t\t"));
                }

                output.WriteLine(strRowData);
                strRowData = String.Empty;
            }

            output.WriteLine("");
            driver.Quit();
        }
    }

}
