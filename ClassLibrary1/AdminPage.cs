using System;
using System.Linq;
using System.Threading;

namespace PageObjectTest
{
    internal class AdminPage
    {
        internal static void AddNewPost(string guid)
        {
            Thread.Sleep(2000);

            var elements = Browser.FindByXpath("//div [@class='wp-menu-name' and text()='Posts']").Single();
            elements.Click();

            Thread.Sleep(2000);

            elements = Browser.FindByXpath("//a[@href='post-new.php' and text()='Add New']").Single();
            elements.Click();

            elements = Browser.FindByXpath("//*[@name='post_title']").Single();
            elements.SendKeys("Ble ble ble"+guid);

            elements = Browser.FindByXpath("//*[@name='content']").Single();
            elements.SendKeys("Ale Ale Ale"+guid);

            elements = Browser.FindByXpath("//*[@name='publish']").Single();
            elements.Click();

        }

        internal static void DeletePost(string guid)
        {
            Thread.Sleep(2000);

            var elements = Browser.FindByXpath("//div [@class='wp-menu-name' and text()='Posts']").Single();
            elements.Click();

            elements = Browser.FindByXpath("//a[@href='edit.php' and text()='All Posts']").Single();
            elements.Click();

            elements = Browser.FindByXpath("//*[@id='post-search-input']").Single();
            elements.Click();
            elements.SendKeys(guid);

            elements = Browser.FindByXpath("//*[@id='search-submit']").Single();
            elements.Click();

        }
    }
}