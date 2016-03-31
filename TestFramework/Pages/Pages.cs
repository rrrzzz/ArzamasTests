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

        private static AboutPage _aboutPage;
        public static AboutPage AboutPage
        {
            get
            {
                if (_aboutPage == null)
                {
                    _aboutPage = new AboutPage();
                }
                PageFactory.InitElements(Browser.Driver, _aboutPage);
                return _aboutPage;
            }
        }

        private static LicensePage _licensePage;
        public static LicensePage LicensePage
        {
            get
            {
                if (_licensePage == null)
                {
                    _licensePage = new LicensePage();
                }
                PageFactory.InitElements(Browser.Driver, _licensePage);
                return _licensePage;
            }
        }

        private static HowToPage _howToPage;
        public static HowToPage HowToPage
        {
            get
            {
                if (_howToPage == null)
                {
                    _howToPage = new HowToPage();
                }
                
                return _howToPage;
            } 
            
        }

        private static TeamPage _teamPage;
        public static TeamPage TeamPage
        {
            get
            {
                if (_teamPage == null)
                {
                    _teamPage = new TeamPage();
                }
                PageFactory.InitElements(Browser.Driver, _teamPage);
                return _teamPage;
            }
        }

        private static ContactPage _contactPage;
        public static ContactPage ContactPage
        {
            get
            {
                if (_contactPage == null)
                {
                    _contactPage = new ContactPage();
                }
                PageFactory.InitElements(Browser.Driver, _contactPage);
                return _contactPage;
            }
        }
    }
}
