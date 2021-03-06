﻿using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;
using System.Linq;
using System.Threading;
using System.Collections.ObjectModel;
//instalujemy selenium webdriver
// i xunit
//wklejam to co mi wygenerowalo selenium

namespace SeleniumTests
{
    public class Example : IDisposable
    {
        private const string SearchTextBoxId = "lst-ib";                                 
        private const string Google = "https://www.google.pl/";             // private string baseURL;
        private const string CodeSprintersPageTitle = "Code Sprinters -";
        private const string TextToSearch = "code sprinters";
        private const string LinkTextToFind1 = "Poznaj nasze podejście";
        private const string LinkTextToFind2 = "Akceptuję";
        private const string Text001 = "WIEDZA NA PIERWSZYM MIEJSCU";
        private const string TagNameToFind = "h2";
        private IWebDriver driver;
        private StringBuilder verificationErrors;
                                                                            // private bool acceptNextAlert = true;
        
        public Example()
        {
            driver = new ChromeDriver();  
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts()
                 .ImplicitWait = TimeSpan.FromMilliseconds(100);
                                                                         // baseURL = "https://www.google.pl/";
            verificationErrors = new StringBuilder();  //
        }

        //test
        [Fact]
        public void NavigatingToCodeSprintersSite() //TheExampleTest()
        {
            GoToGoogle();                                               //driver.Navigate().GoToUrl(Google);

            Search(TextToSearch);

            ClickOnLinkWithText(CodeSprintersPageTitle);

            Assert.Single(GetElementsByLinkText(LinkTextToFind1));

            AcceptPoliticsAndGoToTargetPageByLinkWithText(LinkTextToFind1);

            //ver1
            Assert.Contains(Text001, driver.PageSource);
            //ver2
            Assert.Single(GetElementByTagName(TagNameToFind)
                .Where(tag => tag.Text == Text001));
        }

        private void AcceptPoliticsAndGoToTargetPageByLinkWithText(string linkTextToTargetPage)
        {
            ClickOnLinkWithText(LinkTextToFind2); //driver.FindElement(By.LinkText(LinkTextToFind2)).Click();

            WaitUntilElementIsInvisible(LinkTextToFind2, 11);

            ClickOnLinkWithText(linkTextToTargetPage); //driver.FindElement(By.LinkText("Poznaj nasze podejście")).Click();
        }


        private void WaitUntilElementIsInvisible(string textToFind, int sec)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));
            wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.LinkText(textToFind), textToFind));
        }

        private ReadOnlyCollection<IWebElement> GetElementByTagName(string tagName)
        {
            return driver.FindElements(By.TagName(tagName));
        }

        private ReadOnlyCollection<IWebElement> GetElementsByLinkText(string linkTextToFind)
        {
            return driver.FindElements(By.LinkText(linkTextToFind));
        }

        private void Search(string query)
        {
            var searchBox = GetSearchBox();
            searchBox.Clear();                                          //driver.FindElement(By.Id(SearchTextBoxId)).Clear();
            searchBox.SendKeys(query);                       // driver.FindElement(By.Id(SearchTextBoxId)).SendKeys("code sprinters");
            searchBox.Submit();                                         //driver.FindElement(By.Id(SearchTextBoxId)).Submit();
        }

        private void ClickOnLinkWithText(string resultName)
        {
            driver.FindElement(By.LinkText(resultName)).Click();
        }

        private void GoToGoogle()//dodana
        {
            driver.Navigate().GoToUrl(Google);
        }


        private IWebElement GetSearchBox()//dodana
        {
            return driver.FindElement(By.Id(SearchTextBoxId));
        }

        protected void waitForElementPresent(By by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

       protected void waitForElementPresent(IWebElement by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
        //na googla codesprinters wyszukuje agile szkolenia i chce znaleźć element poznaj nasze podejscie 
        //kliknac i sprawdzic ze jest artykół z tekstem "WIEDZA NA PIERWSZYM MIEJSCU



        //private bool IsElementPresent(By by)
        //{
        //    try
        //    {
        //        driver.FindElement(by);
        //        return true;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        return false;
        //    }
        //}

        //private bool IsAlertPresent()
        //{
        //    try
        //    {
        //        driver.SwitchTo().Alert();
        //        return true;
        //    }
        //    catch (NoAlertPresentException)
        //    {
        //        return false;
        //    }
        //}

        //private string CloseAlertAndGetItsText()
        //{
        //    try
        //    {
        //        IAlert alert = driver.SwitchTo().Alert();
        //        string alertText = alert.Text;
        //        if (acceptNextAlert)
        //        {
        //            alert.Accept();
        //        }
        //        else
        //        {
        //            alert.Dismiss();
        //        }
        //        return alertText;
        //    }
        //    finally
        //    {
        //        acceptNextAlert = true;
        //    }
        //}

        public void Dispose()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.Equal("", verificationErrors.ToString());
        }
    }
}