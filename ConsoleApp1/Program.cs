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

            

            if (String.Compare(driver.Title, "Dota News and Updates")==0){

                Console.WriteLine("Isti title");
            }
            else
            {
                Console.WriteLine("Razlicit title");
            }

           
            string comparisonTitle=string.Empty;
            bool notFirstIteration = false;
            try
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(15000);



                    IWebElement featuredTitle = driver.FindElement(By.XPath("/ html / body / div[2] / div / div / div[2] / div[1] / div[4] / div[3]"));
                    Console.WriteLine(featuredTitle.GetAttribute("class"));

                    featuredTitle.Click();


                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    //Comparing text from previous iteration with current one, if the iteration isn't the first

                    if (notFirstIteration)
                    {
                        if (String.Compare(comparisonTitle, featuredTitle.Text) != 0)
                        {
                            Console.WriteLine("New news!!" + featuredTitle.Text);
                            

                            {
                                Console.WriteLine("No new news.");
                            }
                        }
                        ReadOnlyCollection<string> rdOnly = driver.WindowHandles;
                        List<string> windowHandles = new List<string>(rdOnly);

                        foreach (string a in windowHandles)
                        {
                            Console.WriteLine(a);
                        }
                    }
                    comparisonTitle = featuredTitle.Text;

                    Console.WriteLine(featuredTitle.Text+"\n\n\n\n");
                    ReadOnlyCollection<string> windowHandlesCollection=driver.WindowHandles;
                    IWebElement link = driver.FindElement(By.ClassName("blogoverviewpage_FeaturedLink_SffNe"));
                    js.ExecuteScript("window.open(arguments[0])", link.GetAttribute("href"));


                  
                    //foreach (string a in array)
                    //{
                    //    Console.WriteLine(a);
                    //}

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
