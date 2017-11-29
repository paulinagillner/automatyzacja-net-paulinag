using System;
using System.Linq;

namespace PageObjectTest
{
    internal class MainPage
    {
        private const string url = "https://autotestdotnet.wordpress.com/";
        internal static void Open()//static zeby wywolac bez twozrenai nowego obiektu
        {
            // driver.Navigate).GoToUrl(Google);
            Browser.NavigateTo(url);
        }
        internal static void OpenFirstNote()
        {
           var elements = Browser.FindByXpath("//article/header");
            elements.First().Click();
        }
    }
}