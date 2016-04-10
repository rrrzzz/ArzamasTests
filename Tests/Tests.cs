using NUnit.Framework;
using TestFramework;



namespace Tests
{
    [TestFixture]
    public class TestMeasure
    {
        [Test]
        public static void MeasureTests()
        {
            Measurement.Measurement.RunAndGetTestStats();
        }
    }

    [TestFixture]
    public class BrowserTests
    {
        [SetUp]
        public void OpenBrowser()
        {
            Browser.Start();
        }

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
            Pages.AuthorsPage.ClickAnyAuthor();
            Assert.IsTrue(Pages.Author.IsAt());
        }

        [Test]
        public void CheckAllAuthors()
        {
            Pages.AuthorsPage.GoTo();
            Assert.IsTrue(Pages.AuthorsPage.CheckAllAuthors());
        }

        [Test]
        public void CheckAboutPage()
        {
            Pages.HomePage.GoTo();
            Pages.Footer.AboutClick();
            Assert.IsTrue(Pages.AboutPage.IsAt());
        }

        [Test]
        public void CheckLicensePage()
        {
            Pages.HomePage.GoTo();
            Pages.Footer.LicenseClick();
            Assert.IsTrue(Pages.LicensePage.IsAt());
        }

        [Test]
        public void CheckHowToPage()
        {
            Pages.AboutPage.GoTo();
            Pages.AboutPage.HowToClick();
            Assert.IsTrue(Pages.HowToPage.IsAt());
        }

        [Test]
        public void CheckTeamPage()
        {
            Pages.AboutPage.GoTo();
            Pages.AboutPage.TeamClick();
            Assert.IsTrue(Pages.TeamPage.IsAt());
        }

        [Test]
        public void CheckContactPage()
        {
            Pages.AboutPage.GoTo();
            Pages.AboutPage.ContactClick();
            Assert.IsTrue(Pages.ContactPage.IsAt());
        }

        [Test]
        public void CheckContactFormSubmit()
        {
            Pages.ContactPage.GoTo();
            Pages.ContactPage.FillForm();
            Pages.ContactPage.Submit();
            Assert.IsTrue(Pages.ContactPage.IsFormSubmitted());
        }

        [Test]
        public void SubscriptionInvalidEmail()
        {
            Pages.HomePage.GoTo();
            Pages.Footer.FillEmailForm();
            Pages.Footer.SubmitEmailForm();
            Assert.IsTrue(Pages.Footer.IsErrorMessageShown());
        }

        [Test]
        public void SubscriptionValidEmail()
        {
            Pages.HomePage.GoTo();
            Pages.Footer.FillEmailForm("kalandrill@yahoo.com");
            Pages.Footer.SubmitEmailForm();
            Assert.IsTrue(Pages.Footer.IsEmailSubscriptionSuccessful());
        }
    }

    [TestFixture]
    public class ApiTests
    {

        [Test]
        public void ApiValidEmailSubscription()
        {
            Assert.IsTrue(Api.IsEmailSubscriptionSuccessful());
        }

        [Test]
        public void ApiInvalidEmailSubscription()
        {
            Assert.IsFalse(Api.IsEmailSubscriptionSuccessful("asdasd@asd"));
        }

        [Test]
        public void ApiInvalidFeedback()
        {
            Assert.IsTrue(Api.IsFeedbackError());
        }
    }
}
