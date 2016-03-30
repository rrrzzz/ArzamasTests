using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public class ContactPage : AboutPage
    {
        [FindsBy(How = How.Id, Using = "feedback_name")]
        private IWebElement _formName;

        [FindsBy(How = How.Id, Using = "feedback_email")]
        private IWebElement _formEmail;

        [FindsBy(How = How.Id, Using = "feedback_theme")]
        private IWebElement _formTheme;

        [FindsBy(How = How.Id, Using = "feedback_message")]
        private IWebElement _formMessage;

        [FindsBy(How = How.ClassName, Using = "btn-submit")]
        private IWebElement _submitBtn;

        public ContactPage()
        {
            Title = "Связь";
            FullUrl += "/contact";
        }

        public void Submit()
        {
            _submitBtn.Click();
        }

        public void EnterName(string name = "asd") => _formName.SendKeys(name);
        public void EnterEmail(string email = "asdasd@asd") => _formEmail.SendKeys(email);
        public void EnterTheme(string theme = "asdasd") => _formTheme.SendKeys(theme);
        public void EnterMessage(string message = "asdasd") => _formMessage.SendKeys(message);

        public void FillForm(string name = "asd", string email = "asdasd@asd",
            string theme = "asdasd", string message = "asdasd")
        {
            EnterName(name);
            EnterEmail(email);
            EnterTheme(theme);
            EnterMessage(message);
        }

        public bool IsFormSubmitted() => "Отправляю..." == _submitBtn.GetAttribute("value");
    }

    
}
