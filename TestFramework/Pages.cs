using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public static class Pages
    {
        private static HomePage _homePage;
        public static HomePage HomePage => _homePage ?? (_homePage = new HomePage());

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
        private static string _url = "http://arzamas.academy";
        private static string _title = "Arzamas";

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
        private string _linkName;
        public string LinkName => _linkName;

        [FindsBySequence]
        [FindsBy(How = How.ClassName, Using = "b-authors", Priority = 0)]
        [FindsBy(How = How.TagName, Using = "li", Priority = 1)]
        private IList<IWebElement> _allAuthors;
                     
        public void GoTo()
        {
            Browser.GoTo(_url);
        }

        public void ClickAny()
        {
            var rand = new Random();
            _authorLink = _allAuthors[rand.Next(_allAuthors.Count)];
            _linkName = GetLinkName();
            ClickAuthorLink();
        }

        public bool CheckAllAuthors()
        {
            foreach (var author in _allAuthors)
            {
                _authorLink = author;
                _linkName = GetLinkName();
                ClickAuthorLink();
                if (!Pages.Author.AtAuthorPage())
                    throw new IncorrectAuthorException($"There is a mismatch on {Pages.Author.Name}'s page!");
                Browser.Driver.Navigate().Back();
            }
            return true;
        }

        private string GetLinkName()
        {
            return _authorLink.FindElement(By.TagName("h5")).Text;
        }

        private void ClickAuthorLink()
        {
            var builder = new Actions(Browser.Driver);
            builder.Click(_authorLink).Perform();
        }        

    }

    public class AuthorPage
    {
        [FindsBy(How = How.ClassName, Using = "author-name")]
        IWebElement _nameElement;       
        public string Name => _nameElement.Text;
        public string TitleName => Browser.Title.Substring(0, Browser.Title.IndexOf('|') - 1);

        public bool AtAuthorPage()
        {            
            return Name == Pages.AuthorsPage.LinkName && TitleName == Name;
        }
    }

    public class Header
    {
       
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
        public static IWebDriver Driver { get; } = new ChromeDriver(@"C:\Libraries");
        public static string Title => Driver.Title;

        public static void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public static void Close()
        {
            Driver.Close();
        }

    }
}
