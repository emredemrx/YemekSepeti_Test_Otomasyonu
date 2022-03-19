using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Y_SepetiTest.Controller;
using Y_SepetiTest.Model;
using NUnit.Framework;
using Y_SepetiTest.View;


namespace Y_SepetiTest
{
    class Program
    {
        public static WebDriver driver;
        public static string rastgele = Random();
        static void Main(string[] args)
        {
            Setup();
            LoginTest();
            Close_Browser();

            Setup();
            AdresVeUrunArama();
            Close_Browser();

            Setup();
            Filtreleme();
            Close_Browser();
            
            //Setup();
            //UrunSecimi();
            //Close_Browser();

            //Rapor rapor = new Rapor();
            //rapor.dosyayaYaz(rastgele);
        }

        [SetUp]
        public static void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications"); //Tarayıcı Alert Engelleme
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }
        [Test]
        public static void LoginTest()
        {
            Nesneler(out var locators, out var logger, out var elements, out var user, out var search, out var logAdd, out var message);
            BrowserStart(logger, locators);//------Browser başlatma
            LoginCaseTest(logger, user, elements, message, logAdd);//------Login Case
        }
        [Test]
        public static void AdresVeUrunArama()
        {
            Nesneler(out var locators, out var logger, out var elements, out var user, out var search, out var logAdd, out var message);
            BrowserStart(logger, locators);//------Browser başlatma
            Login(logger, user, elements);//------Login
            AdresSecimi(logger, elements, search);//------Adres Seçimi
            UrunArama(logger, search, elements, logAdd);//------Urun Araması
        }
        [Test]
        public static void Filtreleme()
        {
            Nesneler(out var locators, out var logger, out var elements, out var user, out var search, out var logAdd, out var message);
            BrowserStart(logger, locators);
            Login(logger, user, elements);
            AdresSecimi(logger, elements, search);
            UrunArama(logger, search, elements, logAdd);
            OdemeFiltre(logger, elements, logAdd);

        }
        [Test] 
        public static void UrunSecimi()
        {
            // ---- NOT : Ürün Seçimi için Sürekli OLarak Listeleme farklılaştırğı için Uygun elementler ayarlanması gerekir---//

            Nesneler(out var locators, out var logger, out var elements, out var user, out var search, out var logAdd, out var message);
            BrowserStart(logger, locators);//------Browser başlatma
            Login(logger, user, elements);//------Login
            AdresSecimi(logger, elements, search);//------Adres Seçimi
            UrunArama(logger, search, elements, logAdd);//------Urun Araması
            OdemeFiltre(logger, elements, logAdd); //------Ödeme Turu Filtreleme

            //------İşletme Seçimi ve Menüde Scroll işlemi - Urun Seçimi-------//
            //UrunSecimi(logger, elements, logAdd);
        }
        [TearDown]
        public static void Close_Browser()
        {
            Rapor rapor = new Rapor();
            rapor.dosyayaYaz(rastgele);
            driver.Quit();
        }

        private static void BrowserStart(Logger logger, Locators locators)
        {
            logger.BrowserStartLogger("Tarayıcı Başlatıldı",
                "Tarayıcı Başlatılamadı! İnternet Bağlantınızı veya URLi kontrol ediniz", driver, locators.Test_Site_URL + locators.Sehir, rastgele);
            wait(1000);
        }
        private static void LoginCaseTest(Logger logger, User user, Elements elements, Message message, LogAdd logAdd)
        {
            for (int i = 0; i < user.Email.Length; i++)
            {
                logger.sendKeysLogger(message.EmailMessage[i]+" : " + user.Email[i], "Email Yazılamadı", user.Email[i].ToString(), elements.LoginMailInput(), rastgele, user.Email[i].ToString());
                logger.sendKeysLogger(message.PassMessage[i] + " : " + user.Password[i], "Password Yazılamadı", user.Password[i].ToString(), elements.LoginPasswordInput(), rastgele, user.Password[i].ToString());
                logger.clickLogger("Giriş için Tıklandı", "Giriş için Tıklanamadı", elements.LoginButton(), rastgele, message.loginException[i]);
                wait(4000);
                if (i != 3)
                {
                    elements.LoginHataButton().Click();
                    wait(2000);
                    elements.LoginMailInput().Clear();
                    elements.LoginPasswordInput().Clear();
                }
            }
            wait(2000);
            logAdd.Add("YSepeti_" + rastgele + "", "SUCCESS", "Close", "Test Başarılı", "", "", "Login Testi Başarılı");
        }
        private static void Login(Logger logger, User user, Elements elements)
        {
            logger.sendKeysLogger("Email Yazıldı", "Email Yazılamadı", user.GecerliEmail, elements.LoginMailInput(), rastgele);
            logger.sendKeysLogger("Sifre Yazıldı", "Sifre Yazılamadı", user.GecerliSifre, elements.LoginPasswordInput(), rastgele);
            wait(1000);
            logger.clickLogger("Giriş için Tıklandı", "Giriş için Tıklanamadı", elements.LoginButton(), rastgele);
            wait(3000);
        }
        private static void AdresSecimi(Logger logger, Elements elements, Search search)
        {
            wait(2000);
            logger.clickLogger("Semt seçmek için İnputa tıklandı", "Semt seçmek için İnputa tıklanamadı",
                elements.SemtSecimiInputClick(), rastgele);
            wait(1000);
            logger.sendKeysLogger("Adres Yazıldı", "Adres Yazılmadı", search.Semt_Input_Text, elements.SemtSecimiInput(), rastgele);
            logger.clickLogger("Semt seçildi", "Semt Seçilemedi", elements.SemtSecimi(), rastgele);
        }
        private static void UrunArama(Logger logger, Search search, Elements elements, LogAdd logAdd)
        {
            wait(6000);
            logger.clickLogger("Popup Kapatıldı", "Popup Bulunamadı", elements.PopupKapamaButton(), rastgele);
            elements.AramaInputClick().Click();
            logger.sendKeysLogger("Ürün araması içi Metin Yazıldı", "Ürün araması Metin Yazılamadı", search.Urun_Input_Text, elements.AramaInput(), rastgele);
            wait(1000);
            logger.clickLogger("Ürün araması için Tıklandı", "Ürün araması için Tıklanamadı", elements.AramaButton(), rastgele);
            logAdd.Add("YSepeti_" + rastgele + "", "SUCCESS", "Close", "Test Başarılı", "", "", "Search Testi Başarılı");
        }
        private static void OdemeFiltre(Logger logger, Elements elements, LogAdd logAdd)
        {
            logger.clickLogger("Odeme Türü seçim alanına tıklandı ", "Odeme Türü seçim alanına tıklanamadı",
                elements.OdemeTuruSelectBoxClick(), rastgele);
            wait(1000);
            logger.clickLogger("Odeme Türü Secildi ", "Odeme Türü Seçilemedi", elements.OdemeTuruSelect(), rastgele);
            wait(3000);
            logAdd.Add("YSepeti_" + rastgele + "", "SUCCESS", "Close", "Test Başarılı", "", "", "Filtreleme Başarılı");
        }
        private static void UrunSecimi(Logger logger, Elements elements, LogAdd logAdd)
        {
            logger.clickLogger("Urun Seçimi İçin Tıklandı", "Urun Secimi Yapılamadı", elements.Urun_Sec(), rastgele);
            wait(3000);
            logger.clickLogger("Urun Sepete Eklendi", "Urun Sepete Eklenemedi", elements.Urun_Ekleme(), rastgele);
            wait(10000);
            logAdd.Add("YSepeti_" + rastgele + "", "SUCCESS", "Close", "Test Başarılı", "", "", "Urun Ekleme Başarılı");

        }
        private static void Nesneler(out Locators locators, out Logger logger, out Elements elements, out User user, out Search search,
            out LogAdd logAdd, out Message message)
        {
            locators = new Locators();
            logger = new Logger((WebDriver)driver);
            elements = new Elements((WebDriver)driver);
            user = new User();
            search = new Search();
            logAdd = new LogAdd();
            message = new Message();
        }
        public static void wait(int e)
        {
            Thread.Sleep(e);
        }
        private static string Random()
        {
            Random rastgele = new Random();
            return rastgele.Next(1, 100000).ToString();
        }
    }
}
