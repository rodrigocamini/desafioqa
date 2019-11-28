using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RodrigoDesafioCit.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodrigoDesafioCit.Util
{
    public class BaseDriver
    {
        #region Objects and constructor
        protected OpenQA.Selenium.Support.UI.WebDriverWait wait { get; private set; }
        protected IWebDriver driver { get; private set; }

        public BaseDriver()
        {
            wait = new OpenQA.Selenium.Support.UI.WebDriverWait(DriverFactory.INSTANCE, TimeSpan.FromSeconds(Convert.ToDouble(10)));
            driver = DriverFactory.INSTANCE;          
        }
        #endregion

        #region Custom
        protected IWebElement WaitForElement(By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            return element;
        }

        protected void Click(By locator)
        {
            Stopwatch timeOut = new Stopwatch();
            timeOut.Start();

            while (timeOut.Elapsed.Seconds <= Convert.ToInt32(Properties.Settings.Default.DEFAULT_TIMEOUT_IN_SECONDS))
            {
                try
                {
                    WaitForElement(locator).Click();
                    timeOut.Stop();                   
                }               
                catch (WebDriverException e)
                {
                    if (e.Message.Contains("Other element would receive the click"))
                    {
                        continue;
                    }

                    if (e.Message.Contains("Element is not clickable at point"))
                    {
                        continue;
                    }
                    throw e;
                }
            }            
        }

        protected void SendKeys(By locator, string text)
        {
            Clear(locator);
            WaitForElement(locator).SendKeys(text);          
        }       

        protected string GetText(By locator)
        {
            string text = WaitForElement(locator).Text;           
            return text;
        }

        protected string GetValue(By locator)
        {
            string text = WaitForElement(locator).GetAttribute("value");           
            return text;
        }

        public void NavigateTo(string url)
        {
            DriverFactory.INSTANCE.Navigate().GoToUrl(url);            
        }       

        public string GetTitle()
        {
            string title = driver.Title;
            return title;
        }

        public string GetURL()
        {
            string url = driver.Url;        
            return url;
        }

        protected void Clear(By locator)
        {
            WaitForElement(locator).Clear();
        }

        public void NavegadorChrome()
        {
            DriverFactory.CreateInstance();

            DriverFactory.INSTANCE.Url = "http://automationpractice.com/index.php";
            DriverFactory.INSTANCE.Manage().Window.Maximize();

        }

        public static string ReturnStringWithRandomCharacters(int size)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, size)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        #endregion

    }
}
