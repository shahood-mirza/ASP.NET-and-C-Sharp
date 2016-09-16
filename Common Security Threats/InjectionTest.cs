using System;
using System.Web;
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
    public class InjectionTest
    {
        List<float> list_GPA;

        public List<float> getGPA()
        {
            List<float> tempList = new List<float>();
            list_GPA = dataAccess.readGPAs();          

            for (int i = 0; i < list_GPA.Count; i++)
            {
                tempList[i] = 4;
            }

            return tempList;
        }

        [TestMethod]
        public void safePageTest()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Program Files (x86)\chromedriver_win32");

            driver.Navigate().GoToUrl("http://localhost:54220/Page_safe.aspx");

            IWebElement query_name = driver.FindElement(By.Name("name_create"));
            IWebElement query_gpa = driver.FindElement(By.Name("GPA_create"));

            query_name.SendKeys("Bart Simpson',4);delete from students where name='bart simpson';update students set gpa = 4;--");
            query_gpa.SendKeys("4.0");

            query_name.Submit();
            query_gpa.Submit();

            CollectionAssert.AreEqual(getGPA(), list_GPA);

            driver.Quit();
        }

        [TestMethod]
        public void unsafePageTest()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Program Files (x86)\chromedriver_win32");

            driver.Navigate().GoToUrl("http://localhost:54220/Page_unsafe.aspx");

            IWebElement query_name = driver.FindElement(By.Name("name_create"));
            IWebElement query_gpa = driver.FindElement(By.Name("GPA_create"));

            query_name.SendKeys("Bart Simpson',4);delete from students where name='bart simpson';update students set gpa = 4;--");
            query_gpa.SendKeys("4.0");

            query_name.Submit();
            query_gpa.Submit();

            CollectionAssert.AreEqual(getGPA(), list_GPA);

            driver.Quit();
        }
    }
}
