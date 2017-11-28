using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;
using System.Linq;
using System.Threading;
//instalujemy selenium webdriver
// i xunit
//wklejam to co mi wygenerowalo selenium

namespace SeleniumTests
{
    public class Example : IDisposable
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        public Example()//ctor tab tab
        {
            driver = new ChromeDriver();  //nowy obiekt drivera
            driver.Manage().Window.Maximize();  //maxymaliacja okna
            driver.Manage().Timeouts()
                .ImplicitWait = TimeSpan.FromMilliseconds(100);
            baseURL = "https://www.google.pl/";  //bazowy url
            verificationErrors = new StringBuilder();  //
        }

        //test
        [Fact]
        public void TheExampleTest()
        {
            driver.Navigate().GoToUrl(baseURL);// od czego ma zaczac
            //findelement //sluzy do znalezienia jednego elementu na stronie->ZWRACA PIERWSZY ktry znajdzie
            driver.FindElement(By.Id("lst-ib")).Clear(); //czysci co zastal
            //FindElement zwraca jeden element, czeka przez jakis czas //Findelements nie czeka,zwraca kilka elementów 
            //korzystamy z klasy By ktora umozliwia rozne akcje na tronie
            //najszybciej dziala ID, potem css naj gorzej link tekst, string i xpath
            driver.FindElement(By.Id("lst-ib")).SendKeys("code sprinters");//symulacja zdarzenia wpisywania
            driver.FindElement(By.Id("lst-ib")).Submit();//mozna zrobic send key enter
            driver.FindElement(By.LinkText("Code Sprinters -")).Click();//szukamy codesprinters-i klikamy
            var element = driver.FindElement(By.LinkText("Poznaj nasze podejście"));//szukamy elementu z czyms takim
            Assert.NotNull(element);

            var elements = driver.FindElements(By.LinkText("Poznaj nasze podejście"));
            Assert.Single(elements);//jezeli znajdzie wiecej niz jeden to sie wywali
            //Thread.Sleep(2000);



            driver.FindElement(By.LinkText("Akceptuję")).Click();//mozna zrobic send key enter

            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));//jako argument podajemy max 5sec
            wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.LinkText("Akceptuję"), "Akceptuję"));//czeka az zniknie jesli szybciej to dalej

            //waitForElementPresent(By.LinkText(("Poznaj nasze podejście")), 5000);            // waitForElementPresent(By.LinkText("Poznaj nasze podejście"),2)

            // Thread.Sleep(2000); czeka 2sekundy zawsze
            driver.FindElement(By.LinkText("Poznaj nasze podejście")).Click();



            //ver1
            Assert.Contains("WIEDZA NA PIERWSZYM MIEJSCU", driver.PageSource);
            //ver2
            Assert.Single(driver.FindElements(By.TagName("h2"))
                .Where(tag => tag.Text == "WIEDZA NA PIERWSZYM MIEJSCU"));



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