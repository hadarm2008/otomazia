﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lessSecond.pageObject
{
    public class AlertPage
    {
        private IWebDriver driver;

        public AlertPage(IWebDriver driver)
        {
            this.driver = driver;

        }
    }
}
