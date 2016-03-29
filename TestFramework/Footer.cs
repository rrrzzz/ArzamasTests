using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public class Footer
    {
        [FindsBy(How = How.LinkText, Using = "Лекторы")]
        IWebElement _authorsLink;

        public void AuthorsClick()
        {
            _authorsLink.Click();
        }
    }
}