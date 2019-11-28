using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodrigoDesafioCit.Helpers
{
    public class DriverFactory
    {
        public static IWebDriver INSTANCE { get; set; } = null;

        public static void CreateInstance()
        {
            string browser = Properties.Settings.Default.BROWSER;
            string execution = Properties.Settings.Default.EXECUTION;

            if (INSTANCE == null)
            {
                switch (browser)
                {
                    case "chrome":
                        if (execution.Equals("local"))
                        {
                            ChromeOptions chrome = new ChromeOptions();
                            chrome.AddArgument("start-maximized");
                            chrome.AddArgument("enable-automation");
                            INSTANCE = new ChromeDriver(chrome);
                        }                      
                        break;

                    case "firefox":
                        if (execution.Equals("local"))
                        {
                            INSTANCE = new FirefoxDriver();
                        }
                        break;

                    default:
                        throw new Exception("O browser informado não existe ou não é suportado pela automação");
                }
            }
        }

        public static void QuitInstance()
        {
            INSTANCE.Quit();
            INSTANCE = null;
        }

    }
}
