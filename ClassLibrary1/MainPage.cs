using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PageObjectTest
{
    internal class MainPage
    {
      //  private const string url1 = "https://autotestdotnet.wordpress.com/";
        internal static void Open(string url)//static zeby wywolac bez twozrenai nowego obiektu
        {
            // driver.Navigate).GoToUrl(Google);
            Browser.NavigateTo(url);
        }
        internal static void OpenFirstNote()
        {
           var elements = Browser.FindByXpath("//article/header"); //"//*[text()='hello world']");//("//article/header");
            elements.First().Click();
        }
        internal static void OpenMyComment()//string user)//,string tekst)
        {
            var elements = Browser.FindByXpath("//a[@aria-label='Reply to Paulina']");
            elements.First().Click();
        }

        internal static void LogIn()
        {
            var elements = Browser.FindElementById("usernameOrEmail");
            elements.Click();
            elements.SendKeys("autotestdotnet@gmail.com");

            var elementsbutton = Browser.FindByXpath("//button [@type='submit']");
            elementsbutton.First().Click();

            elements = Browser.FindElementById("password");
            elements.Click();
            elements.SendKeys("P@ssw0rd1");

            elementsbutton = Browser.FindByXpath("//button [text()='Log In']");
            elementsbutton.First().Click();

        }

    }
}