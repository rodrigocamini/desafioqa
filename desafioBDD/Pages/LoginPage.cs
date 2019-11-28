using OpenQA.Selenium;
using RodrigoDesafioCit.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodrigoDesafioCit.Pages
{
    public class LoginPage : BaseDriver
    {
        By signInLink = By.Link("Sign In");
        By emailField = By.Id("email");
        By passwordField = By.Id("password");
        By homeText = By.XPath("//*[@id='my-account']");
        By signButton = By.Name("//*[@id=SubmitLogin']");

        public void ClickSignIn()
        {
            Click(signInLink);
        }

        public void ClickSignButton()
        {
            Click(signButton);
        }

        public void FillEmail(string email)
        {
            SendKeys(emailField, email);
        }

        public void FillPassword(string password)
        {
            SendKeys(passwordField, password);
        }

        public string ValidateHome()
        {
            return GetText(homeText);
        }

    }
}
