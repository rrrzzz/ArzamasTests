using NUnit.Framework;
using TestFramework;



namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [TearDown]
        public void CloseBrowser()
        {
            Browser.Quit();
        }
        
        [Test]
        public void CheckHomePageLinkAndTitle()
        {
            Pages.HomePage.GoTo();
            Assert.IsTrue(Pages.HomePage.IsAt());
        }

        [Test]
        public void CheckAuthorPage()
        {
            Pages.HomePage.GoTo();
            Pages.Footer.AuthorsClick();
            Pages.AuthorsPage.ClickAny();
            Assert.IsTrue(Pages.Author.IsAt());
        }

        [Test]
        public void CheckAllAuthors()
        {
            Pages.AuthorsPage.GoTo();
            Assert.IsTrue(Pages.AuthorsPage.CheckAllAuthors());
        }
    }
}
