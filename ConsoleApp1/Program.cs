using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class Program
    {

      
        static void Main(string[] args)
        {

            //Creating driver and opening tab
            IWebDriver driver = new ChromeDriver();
                driver.Url = "https://www.dota2.com/news";

            //Creating js executor
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

       
            string comparisonTitle=string.Empty;
            bool notFirstIteration = false;

            LinkHandler lh = new LinkHandler((ChromeDriver)driver);

            try
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(10000);



                    IWebElement featuredTitle = driver.FindElement(By.XPath("/ html / body / div[2] / div / div / div[2] / div[1] / div[4] / div[3]"));


                    //Comparing text from previous iteration with current one, if the iteration isn't the first

                    if (notFirstIteration)
                    {
                        if (String.Compare(comparisonTitle, featuredTitle.Text) != 0)
                        {
                            //Finding the new link and opening it in a new tab with JavaScript
                            //IWebElement link = driver.FindElement(By.ClassName("blogoverviewpage_FeaturedLink_SffNe"));
                            //lh.openNewEntry(link);
                            //lh.openLinks();

                            Console.WriteLine("New news!!" + featuredTitle.Text);

                        }
                        else
                        {
                            Console.WriteLine("No new news.");
                        }


                    }

                    //Finding the new link and opening it in a new tab with JavaScript, here for testing purposes
                    IWebElement link = driver.FindElement(By.ClassName("blogoverviewpage_FeaturedLink_SffNe"));
                    lh.openNewEntry(link);
                    lh.openLinks();

                    comparisonTitle = featuredTitle.Text;
                    Console.WriteLine(featuredTitle.Text+"\n\n\n\n");
                   

                    notFirstIteration = true;
                    System.Threading.Thread.Sleep(10000);
                    driver.Navigate().Refresh();
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Error while fetching element.");
            }
            catch (StaleElementReferenceException)
            {
                Console.WriteLine("Page was changed, element isn't in the current document");
            }
        }
    }
}
