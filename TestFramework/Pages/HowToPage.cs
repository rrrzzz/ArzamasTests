using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public class HowToPage : AboutPage
    {
        public HowToPage()
        {
            FullUrl += "/how-to-use";
            Title = "Как устроен Arzamas";
            SubTitle = Browser.Driver.FindElement(By.XPath("//h4[1]"));
        }
    }
}