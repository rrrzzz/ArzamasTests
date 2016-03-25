using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;


namespace TestFramework
{
    public static class Pages
    {
        public static class HomePage
        {
            static private string _url = "http://arzamas.academy";
            static private string _title = "Arzamas";

            public static void GoTo()
            {
                Browser.GoTo(_url);                
            }

            public static bool IsAt()
            {
                return Browser.driver.Title == _title;
            }
         

            
        }

    }

    public static class Browser
    {
        public static IWebDriver driver = new ChromeDriver(@"C:\Libraries");
        
        public static void GoTo(string Url)
        {
            driver.Navigate().GoToUrl(Url);
        }

        public static void Close()
        {
            Browser.driver.Close();
        }
        //as
    }
}
