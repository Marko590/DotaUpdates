using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ConsoleApp1
{
    class LinkHandler
    {
        public int numLinks;
        public LinkHandler()
        {
            this.numLinks = 0;
            
        }

        public void openLinks(IReadOnlyCollection<IWebElement> list)
        {
            foreach(IWebElement element in list)
            {


            }

        }
    }
}
