using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Browser.Close();
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
            Assert.IsTrue(Pages.Author.AtAuthorPage());
        }

        [Test]
        public void CheckAllAuthors()
        {
            Pages.AuthorsPage.GoTo();
            Assert.IsTrue(Pages.AuthorsPage.CheckAllAuthors());
        }
    }
}
