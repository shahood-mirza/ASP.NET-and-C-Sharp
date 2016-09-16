using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Testing;
using System.Collections.Generic;
using Npgsql;
using NpgsqlTypes;

namespace Testing
{
    [TestClass]
    public class XSSTest
    {
        [TestMethod]
        public void escapePageTest()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Program Files (x86)\chromedriver_win32");

            driver.Navigate().GoToUrl("http://localhost:54220/Page_safe.aspx");

            IWebElement query_name = driver.FindElement(By.Name("name_create"));
            IWebElement query_gpa = driver.FindElement(By.Name("GPA_create"));

            query_name.SendKeys("<img id= \"myImage\" src= \"orange.jpg\"/><script>document.getElementById(\"myImage\").src = \"orange.jpg\";</script>");
            query_gpa.SendKeys("4.0");

            driver.FindElement(By.Id("btn")).Click();

            //query_name.Submit();
            //query_gpa.Submit();

            //driver.Quit();
        }
    }
}
