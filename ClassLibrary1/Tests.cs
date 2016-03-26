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
            HomePage.GoTo();
            Assert.IsTrue(HomePage.IsAt());
        }

        [Test]
        public void CheckAuthorPage()
        {
            HomePage.GoTo();
            Page.Footer.AuthorsClick();
            AuthorsPage.ClickAny();
            Assert.IsTrue(AuthorsPage.ChosenAuthor.AtAuthorPage());
        }
    }
}
