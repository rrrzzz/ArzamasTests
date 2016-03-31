using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

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

        [FindsBySequence]
        [FindsBy(How = How.ClassName, Using = "footer-page", Priority = 0)]
        [FindsBy(How = How.ClassName,Using = "input", Priority = 1)]
        private IWebElement _emailInputField;

        [FindsBySequence]
        [FindsBy(How = How.ClassName, Using = "footer-page", Priority = 0)]
        [FindsBy(How = How.CssSelector, Using = "input[type=submit]", Priority = 1)]
        private IWebElement _submitEmailBtn;

        [FindsBySequence]
        [FindsBy(How = How.ClassName, Using = "footer-page", Priority = 0)]
        [FindsBy(How = How.ClassName, Using = "error-message", Priority = 1)]
        private IWebElement _errorMessage;

        public void AuthorsClick() => _authorsLink.Click();
        public void AboutClick() => _aboutLink.Click();
        public void LicenseClick() => _licenseLink.Click();
        public void SubmitEmailForm() => _submitEmailBtn.Click();
        public void FillEmailForm(string email = "asdasd@asd") => _emailInputField.SendKeys(email);

        public bool IsEmailSubscriptionSuccessful()
        {
            var waiter = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(2));
            try
            {
                waiter.Until(d => !_emailInputField.Displayed);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool IsErrorMessageShown()
        {
            var waiter = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(2));
            try
            {
                waiter.Until(d => _errorMessage.Displayed);
                return _errorMessage.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        } 


    }
}