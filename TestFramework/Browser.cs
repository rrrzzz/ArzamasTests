using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestFramework
{
    public static class Browser
    {
        public static IWebDriver Driver { get; private set; } 
        public static string Title => Driver.Title;

        public static void Start()
        {
            Driver = new ChromeDriver(@"C:\Libraries");
        }

        public static void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public static void Quit()
        {
            Driver.Quit();
        }
    }
}