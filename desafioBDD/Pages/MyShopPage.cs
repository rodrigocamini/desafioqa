using OpenQA.Selenium;
using RodrigoDesafioCit.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodrigoDesafioCit.Pages
{
    public class MyShopPage : BaseDriver
    {
        By homeButton = By.XPath("//*[@id='center_column']/ul/li/a/span");
        By taskField = By.Id("new_task");
        By itemCartButton = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='$30.51'])[2]/following::span[2]");
        
        By continueShop = Byte.XPath("(.//*[normalize-space(text()) and normalize-space(.)='$30.51'])[2]/following::span[2]");
        By myTaskPageTxt = By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]/a/span");
        By table = By.TagName("table");
        By tbody = By.TagName("tbody");

        By cartField = By.XPath("//*[@id='header']/div[3]/div/div/div[3]/div/a");

        public void ClickHomeButton()
        {
            Click(homeButton);
        }

        public void FillNameTask(string name)
        {
            SendKeys(taskField, name);
        }

        public void ClickItem()
        {
            Click(ItemCartButton);
        }        

        public void ClickContinueShop()
        {
            Click(continueShop);
        }

        public string ValidateMyShopPage()
        {
            return GetText(myTaskPageTxt);
        }
        public string ValidateMyCart()
        {
            return GetText(cartField);
        }

        public bool CheckValueInList(string task)
        {
            var tabela = WaitForElement(table);

            var subtabela = WaitForElement(tbody);

            foreach (var tr in subtabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                if (tds[0].Text.Equals(task))
                    return true;
            }
            return false;
        }

    }
}
