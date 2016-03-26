using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;


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
        static public Author ChosenAuthor { get; set; }
        
        public static void GoTo()
        {
            Browser.GoTo(_url);
        }

        public static void ClickAny()
        {
            var rand = new Random();
            IReadOnlyCollection<IWebElement> authors = GetAuthors();
            IWebElement selectedAuthor = authors.ElementAt(rand.Next(authors.Count));
            ChosenAuthor = new Author(selectedAuthor.FindElement(By.TagName("h5")).Text);
            selectedAuthor.Click();
        }

        private static IReadOnlyCollection<IWebElement> GetAuthors()
        {
            var pack = Browser.driver.FindElement(By.ClassName("b-authors"));
            return pack.FindElements(By.TagName("li"));            
        }
    }

    public class Author
    {
        public string Name { get; set; }

        public Author (string name)
        {
            Name = name;
        }

        public bool AtAuthorPage()
        {
            var title = Browser.driver.Title;
            title = title.Substring(0, title.IndexOf('|') - 1);            
            return Browser.driver.FindElement(By.ClassName("author-name")).Text == Name && title == Name;
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
