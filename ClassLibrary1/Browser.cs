﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace PageObjectTest
{
    internal class Browser
    {
        private static FirefoxDriver _driver; //zmienne mają sie nazywac od litery lub _

        internal static IWebElement FindElementById(string id)
        {
            return _driver.FindElement(By.Id(id));
        }

        static Browser()
        {
            BrowserInitialize();
        }

        internal static void BrowserInitialize()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromMilliseconds(500);
        }

        internal static void WaitUntilElementIsInvisible(string textToFind, int sec)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(sec));
            wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.LinkText(textToFind), textToFind));
        }
        internal static void WaitForInvisible(By by)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        internal static string PageSource()
        {
            return _driver.PageSource;
        }

        internal static ReadOnlyCollection<IWebElement> FindByXpath(string xpath)
        {
            return _driver.FindElements(By.XPath(xpath));
        }

        internal static ReadOnlyCollection<IWebElement> TextToFind(string textToFind)
        {
            return _driver.FindElements(By.LinkText(textToFind));
        }

        internal static void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
       

        internal static void Close()
        {
            _driver.Quit();
        }
    }
}