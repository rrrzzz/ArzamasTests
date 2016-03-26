using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace TestFramework
{
    public static class Page
    {
        public static class Header
        {

        }
        
        public static class Footer
        {
            public static void AuthorsClick()
            {
                Browser.driver.FindElement(By.LinkText("Лекторы")).Click();
            }            

        }

    }

    public static class HomePage
    {
        static private string _url = "http://arzamas.academy";
        static private string _title = "Arzamas";

        public static void GoTo()
        {
            Browser.GoTo(_url);
        }

        public static bool IsAt()
        {
            return Browser.driver.Title == _title;
        }

        
    }

    public static class AuthorsPage
    {
        static private string _url = "http://arzamas.academy/authors";
                
        public static void GoTo()
        {
            Browser.GoTo(_url);
        }

        public static void ClickAny()
        {
            var rand = new Random();
            IReadOnlyCollection<IWebElement> authors = GetAuthors();
            Author.Current = authors.ElementAt(rand.Next(authors.Count));
            //Author.Current = authors.ElementAt(3);
            Author.Click();
        }

        public static bool CheckAllAuthors()
        {
            int size = GetAuthors().Count; 
            for (int i = 0; i < size; i++)
            {
                var authors = GetAuthors();
                Author.Current = authors.ElementAt(i);
                Author.Click();
                if (!Author.AtAuthorPage())
                    throw new IncorrectAuthorException($"There is a mismatch on {Author.Name}'s page!");
                Browser.driver.Navigate().Back();
            }
            return true;
        }

        private static IReadOnlyCollection<IWebElement> GetAuthors()
        {
            var pack = Browser.driver.FindElement(By.ClassName("b-authors"));
            return pack.FindElements(By.TagName("li"));            
        }            

    }

    public static class Author
    {
        public static IWebElement Current;
        public static string Name { get; set; }

        public static bool AtAuthorPage()
        {
            var title = Browser.driver.Title;
            title = title.Substring(0, title.IndexOf('|') - 1);            
            return Browser.driver.FindElement(By.ClassName("author-name")).Text == Name && title == Name;
        }

        public static void Click()
        {
            Name = Current.FindElement(By.TagName("h5")).Text;
            Actions builder = new Actions(Browser.driver);
            builder.Click(Current).Perform();            
        }
    }
    public static class Browser
    {
        public static IWebDriver driver = new ChromeDriver(@"C:\Libraries");
        
        public static void GoTo(string Url)
        {
            driver.Navigate().GoToUrl(Url);
        }

        public static void Close()
        {
            driver.Close();
        }
        
    }
}
