using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public class AuthorsPage : PageBase
    {
        private const string Title = "Лекторы | Arzamas";
        private IWebElement _authorLink;
        public string NameInLink { get; private set; }
        public string Link { get; private set; }

        [FindsBySequence]
        [FindsBy(How = How.ClassName, Using = "b-authors", Priority = 0)]
        [FindsBy(How = How.TagName, Using = "li", Priority = 1)]
        private IList<IWebElement> _allAuthors;

        public AuthorsPage() 
            : base(Constants.Host, "/authors")
        {
        }

        public void ClickAnyAuthor()
        {
            var rand = new Random();
            _authorLink = _allAuthors[rand.Next(_allAuthors.Count)];
            ClickAuthorLink();
        }

        public bool CheckAllAuthors()
        {
            for (int i = 0; i < _allAuthors.Count; i++)
            {
                _authorLink = _allAuthors[i];
                ClickAuthorLink();
                if (!Pages.Author.IsAt())
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
            Link = _authorLink.GetAttribute("href");
            NameInLink = GetLinkName();
            var builder = new Actions(Browser.Driver);
            builder.Click(_authorLink).Perform();
        }

        public override bool IsAt()
        {
            return Browser.Title == Title;
        }
    }
}