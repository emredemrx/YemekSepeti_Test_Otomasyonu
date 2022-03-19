using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Y_SepetiTest.Model;

namespace Y_SepetiTest.Controller
{
    class Logger
    {
        public static WebDriver driver;

        public Logger(WebDriver webDriver) => driver = webDriver;
        StackFrame CallStack = new StackFrame(1, true);
        private string dosyayolu = "";
        private string hataSatiri = "";
        LogAdd logAdd = new LogAdd();
        public void BrowserStartLogger(string messageText, string errorMessageText, WebDriver driver, string elemets, string rastgele)
        {
            try
            {
                driver.Url = elemets;
                logAdd.Add("YSepeti_" + rastgele + "", "INFO", "Browser Start", messageText, driver.Url.ToString(), "", "");
            }
            catch (Exception hata)
            {

                dosyayolu = CallStack.GetFileName();
                hataSatiri = CallStack.GetFileLineNumber().ToString();
                logAdd.Add("YSepeti_" + rastgele + "", "ERROR", "Browser Start", errorMessageText, dosyayolu, "Satır : " + hataSatiri, "");
                driver.Close();
            }
        }
        public void clickLogger(string messageText, string errorMessageText, IWebElement clickElements, string rastgele, string exception = "")
        {
            try
            {
                clickElements.Click();
                logAdd.Add("YSepeti_" + rastgele + "", "INFO", "Click", messageText, "", "", exception);
            }
            catch (Exception hata)
            {

                dosyayolu = CallStack.GetFileName();
                hataSatiri = CallStack.GetFileLineNumber().ToString();
                logAdd.Add("YSepeti_" + rastgele + "", "ERROR", "Click", errorMessageText, dosyayolu, "Satır : " + hataSatiri, "");
                driver.Close();
            }
        } 
        public void sendKeysLogger(string messageText, string errorMessageText, string text, IWebElement sendKeysElements, string rastgele,string exception="")
        {
            try
            {
                sendKeysElements.SendKeys(text);
                logAdd.Add("YSepeti_" + rastgele + "", "INFO", "SendKeys", messageText, "", "", exception);
            }
            catch (Exception hata)
            {
                dosyayolu = CallStack.GetFileName();
                hataSatiri = CallStack.GetFileLineNumber().ToString();
                logAdd.Add("YSepeti_" + rastgele + "", "ERROR", "SendKeys", errorMessageText, dosyayolu, "Satır : " + hataSatiri, "");
                driver.Close();
            }
        }
    }
}
