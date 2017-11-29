using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;

namespace PageObjectTest
{
    internal class NotePage
    {
        internal static void AddComment(Comment testData)
        {
            var commentBox = Browser.FindElementById("comment");
            commentBox.Click();
            commentBox.SendKeys(testData.Text);

            //label[@for="author"]

            var email = Browser.FindElementById("email");
            email.Click();
            email.SendKeys(testData.Mail);

            var nameLabel = Browser.FindByXpath("//label[@for='author']").First();
            nameLabel.Click();
            Thread.Sleep(2000);
            //Browser.WaitForInvisible(By.XPath("//label[@for='author']"));

            

            var name = Browser.FindElementById("author");
            name.Click();
            name.SendKeys(testData.User);

            var submit = Browser.FindElementById("comment-submit");
            submit.Click();
            submit.SendKeys(testData.Mail);
        }
    }
}