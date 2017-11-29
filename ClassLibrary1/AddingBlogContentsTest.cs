using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PageObjectTest
{
    public class AddingBlogContentsTest :IDisposable
    {
        [Fact]
        public void CanAddCommentToTheBlogNote()
        {
            MainPage.Open();
            MainPage.OpenFirstNote();
            NotePage.AddComment(new Comment
            {
                Text = "Lorem ipsum",
                Mail = "test@est.com",
                User = "białko"
            });
            //wejdz na strone bloga
            //otworz pierwszą notke
            //dodaj komentarz
            //sprawdz ze komentarz sie dodal
        }

        public void Dispose()
        {
            Browser.Close();
        }
    }
}
