using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RodrigoDesafioCit.Helpers;
using RodrigoDesafioCit.Util;
using System;
using TechTalk.SpecFlow;

namespace RodrigoDesafioCit.BDD
{
    [Binding]
    public class CreateTaskSteps 
    {
       // private DriverFactory _driverFactory;

        IWebDriver Browser;
        private string uri = "http://automationpractice.com/index.php";

        public void Init()
        {
            this.Browser = new ChromeDriver();
        }

        public void Close()
        {
            this.Browser.Close();
            this.Browser.Dispose();
        }
        [Given(@"A valid user access the home page Shop")]
        public void GivenAValidUserAccessTheHomePageShop()
        {
            this.Browser.Navigate().GoToUrl(uri);
        }
        
        [Given(@"Click the SigIn link")]
        public void GivenClickTheSigInLink()
        {
            var btnSign = this.Browser.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign out'])[1]/following::div[1]"));
            btnSign.Click();
        }
        
        [When(@"Fill Username and Password")]
        public void WhenFillUsernameAndPassword()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"User logged in sucessfull")]
        public void ThenUserLoggedInSucessfull()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
