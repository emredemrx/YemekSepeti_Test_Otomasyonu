using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Y_SepetiTest.Controller;


namespace Y_SepetiTest.Controller
{
    class Elements
    {
        public static WebDriver driver;
        Locators locators = new Locators();
        
        public Elements(WebDriver webDriver) => driver = webDriver;

        public WebElement LoginMailInput()
        {
           
            return (WebElement)driver.FindElement(By.Id(locators.Login_Mail_Input));
        }
        public WebElement LoginPasswordInput()
        {
            return (WebElement)driver.FindElement(By.Id(locators.Login_Password_Input));
        }
        public WebElement LoginButton()
        {
            return (WebElement)driver.FindElement(By.Id(locators.Login_Button));
        }
        public WebElement LoginHataButton()
        {
            return (WebElement)driver.FindElement(By.XPath(locators.Login_Hata_Button));
        }
        public WebElement SemtSecimiInputClick()
        {
            return (WebElement)driver.FindElement(By.XPath(locators.Semt_Input_Click));
        }
        public WebElement SemtSecimiInput()
        {
            return (WebElement)driver.FindElement(By.ClassName(locators.Semt_Input));
        }
        public WebElement SemtSecimi()
        {
            return (WebElement)driver.FindElement(By.XPath(locators.Semt_Secimi));
        }
        public WebElement AramaInputClick()
        {
            return (WebElement)driver.FindElement(By.XPath(locators.Arama_Input_Click));
        }
        public WebElement AramaInput()
        {
            return (WebElement)driver.FindElement(By.XPath(locators.Arama_Input));
        }
        public WebElement AramaButton()
        {
            return (WebElement)driver.FindElement(By.XPath(locators.Arama_Button));
        }
        public WebElement PopupKapamaButton()
        {
            return (WebElement)driver.FindElement(By.XPath(locators.Popup_Kapama_Button));
        }
        public WebElement OdemeTuruSelectBoxClick()
        {
            return (WebElement)driver.FindElement(By.XPath(locators.Odeme_Filter_Click));
        }
        public WebElement OdemeTuruSelect()
        {
            return (WebElement)driver.FindElement(By.XPath(locators.Odeme_Filter_Secim));
        }
        public WebElement İsletmeSec()
        {
            return (WebElement)driver.FindElement(By.XPath(locators.Isletme_Sec));
        }
        public WebElement ScrollDown()
        {
            return (WebElement)driver.FindElement(By.XPath(locators.Menu_Element));
        }
        public WebElement Urun_Sec()
        {
            return (WebElement)driver.FindElement(By.XPath(locators.Secilecek_Urun));
        }
        public WebElement Urun_Ekleme()
        {
            return (WebElement)driver.FindElement(By.XPath(locators.Sepete_Ekle));
        }
        
    }
}
