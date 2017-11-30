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
            var emailLabel = Browser.FindByXpath("//label[@for='email']").First();
            emailLabel.Click();
           
            var email = Browser.FindElementById("email");
            email.Click();
            email.SendKeys(testData.Mail);

            var nameLabel = Browser.FindByXpath("//label[@for='author']").First();
            nameLabel.Click();

            // Thread.Sleep(2000);
            //Browser.WaitForInvisible(By.XPath("//label[@for='author']"));

            

            var name = Browser.FindElementById("author");
            name.Click();
            name.Clear();
            name.SendKeys(testData.User);

            var submit = Browser.FindElementById("comment-submit");
            submit.Click();
            Thread.Sleep(2000);
        }

        internal static void AddComment2(Comment testData)
        {
          //  Browser.WaitUntilElementIsInvisible("Enter your comment",10);
            Thread.Sleep(5000);
            var commentBox2 = Browser.FindElementById("comment");
            commentBox2.Click();
            
            commentBox2.SendKeys(testData.Text);

            //label[@for="author"]
          //  var emailLabel = Browser.FindByXpath("//label[@for='email']").First();
          //  emailLabel.Click();

            var email = Browser.FindElementById("email");
            email.Click();
            email.SendKeys(testData.Mail);

         //   var nameLabel = Browser.FindByXpath("//label[@for='author']").First();
         //   nameLabel.Click();

            // Thread.Sleep(2000);
            //Browser.WaitForInvisible(By.XPath("//label[@for='author']"));



            var name = Browser.FindElementById("author");
            name.Click();
            name.Clear();
            name.SendKeys(testData.User);

            var submit = Browser.FindElementById("comment-submit");
            submit.Click();
            Thread.Sleep(2000);
        }
    }
}