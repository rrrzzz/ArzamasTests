using System.Runtime.InteropServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public class LicensePage : PageBase
    {
        [FindsBy(How = How.TagName, Using = "h1")]
        private IWebElement _title;

        private const string Title =
            "Пользовательское соглашение и правила использования веб-сайта Arzamas.academy в сети интернет";

        public LicensePage() 
            : base(Constants.Host, "/license")
        {
        }

        public override bool IsAt()
        {
            return Title == _title.Text;
        }
    }
}