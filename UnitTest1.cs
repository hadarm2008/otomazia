using lessSecond.pageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace lessSecond
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private AlertPage alertPage;
        private WindowOpen windowOpen;
        [SetUp]
        public void Setup()
        {
            string path = "C:\\Users\\HP\\Desktop\\otomazia\\lessSecond\\lessSecond\\driver";
            driver = new ChromeDriver(path);
            driver.Manage().Window.Maximize();
            alertPage = new AlertPage(driver);
            windowOpen = new WindowOpen(driver);
        }

        [Test]
        public void Test1()
        {
            //Assert.Pass();
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
            var alertButton = driver.FindElement(By.Id("confirmButton"));
            alertButton.Click();
            IAlert alert = WaitForAlert(driver, TimeSpan.FromSeconds(10));

            Assert.IsNotNull(alert, "alert was not displayed");
            alert.Accept();

            try
            {
                IWebElement element = driver.FindElement(By.Id("confirmResult"));
                Assert.IsNotNull(element, "Element with ID 'yourElementId' was not added.");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Element with ID 'yourElementId' was not found. Test failed.");
            }


        }

        private IAlert WaitForAlert(IWebDriver driver, TimeSpan timeout)
        {
            try
            {

                WebDriverWait wait = new WebDriverWait(driver, timeout);
                return wait.Until(ExpectedConditions.AlertIsPresent());
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }
        [Test]
        public void TestWindow()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var alertButton = driver.FindElement(By.Id("windowButton"));

             alertButton.Click();
             WaitForNewWindow(driver, 2);
           
            string mainWindowHandle = driver.CurrentWindowHandle;
            string newWindowHandle = driver.WindowHandles.Last();
            driver.SwitchTo().Window(newWindowHandle);

            Thread.Sleep(2000);
            // Close the new window
            driver.Close();
            driver.SwitchTo().Window(mainWindowHandle);
        }

        private void WaitForNewWindow(IWebDriver driver, int expectedWindowCount)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.WindowHandles.Count == expectedWindowCount);
        }

    }

    //[TearDown]
    //public void TearDown()
    //{
    //    driver.Dispose();
    //}

}
