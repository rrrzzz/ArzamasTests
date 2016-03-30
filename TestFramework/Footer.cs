using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public class Footer
    {
        [FindsBy(How = How.LinkText, Using = "Лекторы")]
        private IWebElement _authorsLink;

        [FindsBy(How = How.LinkText, Using = "О проекте")]
        private IWebElement _aboutLink;

        [FindsBy(How = How.LinkText, Using = "Лицензия")]
        private IWebElement _licenseLink;

        public void AuthorsClick() => _authorsLink.Click();
        public void AboutClick() => _aboutLink.Click();
        public void LicenseClick() => _licenseLink.Click();

    }
}