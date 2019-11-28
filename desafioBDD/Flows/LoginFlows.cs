using RodrigoDesafioCit.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodrigoDesafioCit.Flows
{
    public class LoginFlows
    {
        LoginPage loginPage;

        public LoginFlows()
        {
            loginPage = new LoginPage();
        }

        public void SiginInComplete(string email, string password)
        {
            loginPage.ClickSignIn();
            loginPage.FillEmail(email);
            loginPage.FillPassword(password);
            loginPage.ClickSignButton();
        }
    }
}
