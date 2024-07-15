using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lessSecond.pageObject
{
    public class WindowOpen
    {
        private IWebDriver driver;

        public WindowOpen(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
