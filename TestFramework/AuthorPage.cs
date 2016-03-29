using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public class AuthorPage : PageBase
    {
        [FindsBy(How = How.ClassName, Using = "author-name")]
        IWebElement _nameElement;       
        public string Name => _nameElement.Text;
        public string TitleName => Browser.Title.Substring(0, Browser.Title.IndexOf('|') - 1);

        public AuthorPage()
            : base(Constants.Host, Pages.AuthorsPage.Link)
        {
        }

        public override bool IsAt()
        {
            return Name == Pages.AuthorsPage.NameInLink && TitleName == Name;
        }
    }
}