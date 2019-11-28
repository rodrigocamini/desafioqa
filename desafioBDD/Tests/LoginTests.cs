using NUnit.Framework;
using RodrigoDesafioCit.Flows;
using RodrigoDesafioCit.Pages;
using RodrigoDesafioCit.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodrigoDesafioCit.Tests
{
    public class LoginTests : InitClose
    {
        #region Page Objects
        [AutoInstance] LoginPage loginPage;
        [AutoInstance] BaseDriver baseDriver;
        [AutoInstance] LoginFlows loginflows;
        #endregion   

        [Test]
        public void loginSucess()
        {
            #region parameters
            string email = "rodrigo.camini@gmail.com";
            string password = "citcamini";
            #endregion

            loginflows.SiginInComplete(email, password);

            Assert.AreEqual("Signed in successfully.", loginPage.ValidateHomeToD());
        }
    }
}
