using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public class AboutPage : PageBase
    {
        protected string Title { get; set; } = "О проекте";

        [FindsBy(How = How.ClassName, Using = "header-tab")]
        protected IWebElement SubTitle;

        [FindsBy(How = How.ClassName, Using = "about-tabs")]
        private IWebElement _tabs;

        private IWebElement _howToLink, _teamLink, _contactLink, _aboutLink; 

        public AboutPage() 
            : base(Constants.Host, "/about")
        {
        }

        public override bool IsAt()
        {
            return SubTitle.Text == Title;
        }

        public void HowToClick()
        {
            _howToLink = _tabs.FindElement(By.LinkText("Как пользоваться"));
            _howToLink.Click();
        }

        public void ContactClick()
        {
            _contactLink = _tabs.FindElement(By.LinkText("Связь"));
            _contactLink.Click();
        }

        public void TeamClick()
        {
            _teamLink = _tabs.FindElement(By.LinkText("Команда"));
            _teamLink.Click();
        }

        public void AboutClick()
        {
            _aboutLink = _tabs.FindElement(By.LinkText("О проекте"));
            _aboutLink.Click();
        }
    }
}