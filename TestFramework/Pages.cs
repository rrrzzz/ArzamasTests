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
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public static class Pages
    {
        static HomePage _homePage;
        public static HomePage HomePage
        {
            get
            {
                if (_homePage == null)
                {
                    _homePage = new HomePage();
                }
                return _homePage;
            }
        }

        static Footer _footer;
        public static Footer Footer
        {
            get
            {
                if (_footer == null)
                {
                    _footer= new Footer();
                }
                PageFactory.InitElements(Browser.Driver, _footer);
                return _footer;
            }

        }

        static AuthorsPage _authorsPage;
        public static AuthorsPage AuthorsPage
        {
            get
            {
                if (_authorsPage == null)
                {
                    _authorsPage = new AuthorsPage();
                }
                PageFactory.InitElements(Browser.Driver, _authorsPage);
                return _authorsPage;
            }
        }

        static AuthorPage _author;
        public static AuthorPage Author
        {
            get
            {
                if (_author == null)
                {
                    _author = new AuthorPage();
                }
                PageFactory.InitElements(Browser.Driver, _author);
                return _author;
            }
        }

    }

    public class HomePage
    {
        static private string _url = "http://arzamas.academy";
        static private string _title = "Arzamas";

        public void GoTo()
        {
            Browser.GoTo(_url);
        }

        public bool IsAt()
        {
            return Browser.Title == _title;
        }
        
    }

    public class AuthorsPage
    {
        static string _url = "http://arzamas.academy/authors";
        IWebElement _authorLink;
        string _linkName;
        public string LinkName { get { return _linkName; } }

        [FindsBySequence]
        [FindsBy(How = How.ClassName, Using = "b-authors", Priority = 0)]
        [FindsBy(How = How.TagName, Using = "li", Priority = 1)]
        IList<IWebElement> _allAuthors;
                     
        public void GoTo()
        {
            Browser.GoTo(_url);
        }

        public void ClickAny()
        {
            var rand = new Random();
            //IReadOnlyCollection<IWebElement> authors = GetAuthors();
            _authorLink = _allAuthors[rand.Next(_allAuthors.Count)];
            _linkName = GetLinkName();
            ClickAuthorLink();
           
        }

        public bool CheckAllAuthors()
        {
            for (int i = 0; i < _allAuthors.Count; i++)
            {
                //IReadOnlyCollection<IWebElement> authors = GetAuthors();
                _authorLink = _allAuthors[i];
                _linkName = GetLinkName();
                ClickAuthorLink();
                if (!Pages.Author.AtAuthorPage())
                    throw new IncorrectAuthorException($"There is a mismatch on {Pages.Author.Name}'s page!");
                Browser.Driver.Navigate().Back();
            }
            return true;
        }

        //private static IReadOnlyCollection<IWebElement> GetAuthors()
        //{
        //    var pack = Browser.Driver.FindElement(By.ClassName("b-authors"));
        //    return pack.FindElements(By.TagName("li"));            
        //}            

        string GetLinkName()
        {
            return _authorLink.FindElement(By.TagName("h5")).Text;
        }

        void ClickAuthorLink()
        {
            Actions builder = new Actions(Browser.Driver);
            builder.Click(_authorLink).Perform();
        }        

    }

    public class AuthorPage
    {
        [FindsBy(How = How.ClassName, Using = "author-name")]
        IWebElement _nameElement;       
        public string Name { get { return _nameElement.Text; } }
        public string TitleName { get { return Browser.Title.Substring(0, Browser.Title.IndexOf('|') - 1); } }

        public bool AtAuthorPage()
        {            
            return Name == Pages.AuthorsPage.LinkName && TitleName == Name;
        }
    }

    public class Header
    {
        //
    }

    public class Footer
    {
        [FindsBy(How = How.LinkText, Using = "Лекторы")]
        IWebElement _authorsLink;

        public void AuthorsClick()
        {
            _authorsLink.Click();
        }
    }

    public static class Browser
    {
        static IWebDriver _driver = new ChromeDriver(@"C:\Libraries");
        public static IWebDriver Driver { get { return _driver; } }
        public static string Title { get { return _driver.Title; } }

        public static void GoTo(string Url)
        {
            _driver.Navigate().GoToUrl(Url);
        }

        public static void Close()
        {
            _driver.Close();
        }

    }
}
