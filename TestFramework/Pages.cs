using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public static class Pages
    {
        private static HomePage _homePage;
        public static HomePage HomePage => _homePage ?? (_homePage = new HomePage());

        private static Footer _footer;
        public static Footer Footer
        {
            get
            {
                if (_footer == null)
                {
                    _footer= new Footer();
                }
                PageFactory.InitElements(Browser.Driver, _footer);
                return _footer;
            }

        }

        private static AuthorsPage _authorsPage;
        public static AuthorsPage AuthorsPage
        {
            get
            {
                if (_authorsPage == null)
                {
                    _authorsPage = new AuthorsPage();
                }
                PageFactory.InitElements(Browser.Driver, _authorsPage);
                return _authorsPage;
            }
        }

        private static AuthorPage _author;
        public static AuthorPage Author
        {
            get
            {
                _author = new AuthorPage();
                PageFactory.InitElements(Browser.Driver, _author);
                return _author;
            }
        }
    }
}
