using NUnit.Framework;
using RodrigoDesafioCit.Flows;
using RodrigoDesafioCit.Pages;
using RodrigoDesafioCit.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodrigoDesafioCit.Tests
{
    public class MyShopTests : InitClose
    {
        #region Page Objects
        [AutoInstance] LoginPage loginPage;
        [AutoInstance] BaseDriver baseDriver;
        [AutoInstance] LoginFlows loginflows;
        [AutoInstance] MyShopPage myShopPage;
        [AutoInstance] MyTaskFlows myTaskFlows;
        #endregion   


        [Test]
        public void ValidatePageShop()
        {
            #region parameters
            string email = "rodrigo.camini@gmail.com";
            string password = "citcamini";
            #endregion

            loginflows.SiginInComplete(email, password);
            loginPage.ValidateHome();
            
            myShopPage.ClickHomeButton();
            Assert.IsTrue(myShopPage.ValidateMyShopPage().Contains("RODRIGO CAMINI"));
        }

        [Test]
        public void AddNewShop()
        {
            #region parameters
            string email = "rodrigo.camini@gmail.com";
            string password = "citcamini";
            #endregion

            loginflows.SiginInComplete(email, password);
            loginPage.ValidateHome();

            myShopPage.ClickItem();
            myShopPage.ClickContinueShop();

            Assert.IsTrue(myShopPage.ValidateMyCart().Contains("1"));


        }
    }
}
