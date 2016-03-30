using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public class HowToPage : AboutPage
    {
        [FindsBy(How = How.XPath, Using = "//h4[1]")]
        private IWebElement _subTitle;

        public HowToPage()
        {
            FullUrl += "/how-to-use";
            Title = "Как устроен Arzamas";
        }
    }
}