using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Chrome;

namespace ConsoleApp1
{
    public class LinkHandler
    {
        
        private ChromeDriver driver;
        private IJavaScriptExecutor js;
        public LinkHandler(ChromeDriver driver)
        {
            this.driver = driver;
            this.js=(IJavaScriptExecutor)driver;
        }





        public bool checkIfExternalLink(string linkText)
        {
            bool check = true;

            if (linkText.Contains("www.dota2.com") || 
                linkText.Contains("https://store.steampowered.com/") || 
                linkText.Contains("https://steamcommunity.com/") || 
                linkText.Contains("https://www.valvesoftware.com/"))
            {
                check = false;
            }

                return check;
        }

        public void openNewEntry(IWebElement link)
        {
            //Opening the link in a new tab with JavaScript
            js.ExecuteScript("window.open(arguments[0])", link.GetAttribute("href"));


            //Finding the new tab that was opened and switching to it
            ReadOnlyCollection<string> rdOnly = driver.WindowHandles;
            List<string> windowHandles = new List<string>(rdOnly);
            string lastWindow = windowHandles.ElementAt(windowHandles.Count-1);
            driver.SwitchTo().Window(lastWindow);

        }
        private List<IWebElement> fetchAllLinks()
        {
            try
            {
                System.Threading.Thread.Sleep(4000);
                ReadOnlyCollection<IWebElement> rdOnly = driver.FindElements(By.TagName("a"));
                List<IWebElement> retVal = new List<IWebElement>(rdOnly);
                return retVal;

            }
            catch (Exception)
            {
                return null;
            }
        }
        public void openLinks()
        {

            List<IWebElement> list = fetchAllLinks();
            foreach (IWebElement element in list)
            {
                if (checkIfExternalLink(element.GetAttribute("href")))
                {
                    js.ExecuteScript("window.open(arguments[0])", element.GetAttribute("href"));
                }

            }

        }
    }
}
