using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace PageObjectTest
{
    internal class Browser
    {
        private static ChromeDriver _driver; //zmienne mają sie nazywac od litery lub _

        internal static IWebElement FindElementById(string id)
        {
            return _driver.FindElement(By.Id(id));
        }

        static Browser()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromMilliseconds(500);
        }

        internal static void WaitForInvisible(By by)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        internal static ReadOnlyCollection<IWebElement> FindByXpath(string xpath)
        {
            return _driver.FindElements(By.XPath(xpath));
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