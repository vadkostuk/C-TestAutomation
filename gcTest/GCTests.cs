﻿using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using System;

namespace NUnitSelenium
{
    class GCTest
    {
        IWebDriver driver;
        IWebElement ecoNewsButton;
        IWebElement singleNewsCard;
        IWebElement twitterButton;

        [SetUp]
        public void Initialize()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Url = "https://ita-social-projects.github.io/GreenCityClient/#/";
        }

        [Test]
        [Obsolete]
        public void LaunchApp()
        {
            WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            ecoNewsButton = driver.FindElement(By.CssSelector("li[role='navigation to news'] > a"));
            ecoNewsButton.Click();

            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("li:nth-of-type(1) > .ng-star-inserted > .list-gallery")));
            singleNewsCard = driver.FindElement(By.CssSelector("li:nth-of-type(1) > .ng-star-inserted > .list-gallery"));
            singleNewsCard.Click();

            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("img[alt='twitter']")));
            twitterButton = driver.FindElement(By.CssSelector("img[alt='twitter']"));
            twitterButton.Click();

            driver.SwitchTo().Window(driver.WindowHandles[1]);

            Assert.AreEqual("Твиттер", driver.Title);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        [TearDown]
        public void ShutDown()
        {
            driver.Close();
        }
    }
}