using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace KursSelenium.Methods
{
    class TitleAndSource
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Position = new System.Drawing.Point(8, 30);
            driver.Manage().Window.Size = new System.Drawing.Size(1290, 730);

            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(5);
        }

        [Test]
        public void RetrieveTitleTest()
        {
            driver.Navigate().GoToUrl("https://pl.wikipedia.org/");
            Assert.AreEqual("Wikipedia, wolna encyklopedia", driver.Title, "Title is not correct");
        }

        [Test]
        public void GetUrl()
        {
            driver.Navigate().GoToUrl("https://pl.wikipedia.org/");
            Assert.AreEqual("https://pl.wikipedia.org/wiki/Wikipedia:Strona_g%C5%82%C3%B3wna", driver.Url, "Url is not correct");
        }

        [Test]
        public void GetSource()
        {
            string metaContent = "//upload.wikimedia.org/wikipedia/commons/thumb/8/81/Wikimedia-logo.svg/20px-Wikimedia-logo.svg.png";
            driver.Navigate().GoToUrl("https://pl.wikipedia.org/");
            Assert.IsTrue(driver.PageSource.Contains(metaContent), "PageSource is not correct");
        }

        [TearDown]
        public void QuitDriver()
        {
        driver.Quit();
        }
    }

}