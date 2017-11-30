using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PageObjectTest
{
    
    public class AddingBlogContentsTest //:IDisposable
    {
        const string url1 = "https://autotestdotnet.wordpress.com/";
        const string url2 = "https://autotestdotnet.wordpress.com/wp-admin/";

        String guid = Guid.NewGuid().ToString();
        String guid2 = Guid.NewGuid().ToString();
        String guid3 = Guid.NewGuid().ToString();
        [Fact]
        public void CanAddCommentToTheBlogNote()
        
        {
            
            MainPage.Open(url1);
            MainPage.OpenFirstNote();
            NotePage.AddComment(new Comment
            {
                Text = guid+ "Moj komentarz",
                Mail = "aaaa@bbbbb.com",
                User = "Paulina"
            });
            //wejdz na strone bloga
            //otworz pierwszą notke
            //dodaj komentarz
            //sprawdz ze komentarz sie dodal
            Assert.Contains(guid, Browser.PageSource());
            
        }
        [Fact]
        public void CanAddCommentToTheComment()
        {

            MainPage.Open(url1);
            MainPage.OpenFirstNote();
            MainPage.OpenMyComment();// "Paulina");//, guid);
            
            NotePage.AddComment2(new Comment
            {
                Text = guid2 + "Moj komentarz do komentarza",
                Mail = "bbbb@bbbbb.com",
                User = "Paulina"
            });
            //wejdz na strone bloga
            //otworz pierwszą notke
            //dodaj komentarz do konentarza
            //sprawdz ze komentarz sie dodal
            Assert.Contains(guid2, Browser.PageSource());
        }
        [Fact]
        public void CanAddNewPost()
        {
            MainPage.Open(url2);
            MainPage.LogIn();
            AdminPage.AddNewPost(guid3);
            Dispose();
            Browser.BrowserInitialize();
            MainPage.Open(url1);
            Assert.Contains(guid3, Browser.PageSource());
        }
        [Fact]
        public void CanDeletePost()
        {
            //dodanie posta w admin
            MainPage.Open(url2);
            MainPage.LogIn();
            AdminPage.AddNewPost(guid3);
            Dispose();
            Browser.BrowserInitialize();
            MainPage.Open(url1);
            Assert.Contains(guid3, Browser.PageSource());
            //dodanie komentarza
            MainPage.Open(url1);
            MainPage.OpenFirstNote();
            NotePage.AddComment(new Comment
            {
                Text = guid + "Moj komentarz",
                Mail = "aaaa@bbbbb.com",
                User = "Paulina"
            });
            Assert.Contains(guid, Browser.PageSource());
            // dodanie komentarza do komentarza
            MainPage.Open(url1);
            MainPage.OpenFirstNote();
            MainPage.OpenMyComment();// "Paulina");//, guid);

            NotePage.AddComment2(new Comment
            {
                Text = guid2 + "Moj komentarz do komentarza",
                Mail = "bbbb@bbbbb.com",
                User = "Paulina"
            });
            Assert.Contains(guid2, Browser.PageSource());
            //usuniecie posta

            MainPage.Open(url2);
            MainPage.LogIn();
            AdminPage.DeletePost(guid3);
        }
        public void Dispose()
        {
            Browser.Close();
        }
    }
}
