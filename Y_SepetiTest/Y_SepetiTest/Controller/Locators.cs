using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y_SepetiTest.Controller
{
    public class Locators
    {
        public string Sehir = "istanbul";
        public string Test_Site_URL = "https://www.yemeksepeti.com/";
        public string Login_Mail_Input = "UserName";
        public string Login_Password_Input = "password";
        public string Login_Button = "ys-fastlogin-button";
        public string Login_Hata_Button = "//button[@class='btn confirmButton ys-btn ys-btn-primary']";

        public string Semt_Input_Click = "//body[1]/header[1]/div[1]/div[1]/div[1]/div[2]/span[1]/span[1]/span[1]/span[1]";
        public string Semt_Input = "select2-search__field";
        public string Semt_Secimi = "//body[1]/header[1]/div[1]/div[1]/div[1]/div[2]/div[1]/span[1]/span[1]/span[2]/ul[1]/li[1]/ul[1]/li[1]";
        
        public string Arama_Input_Click = "//input[@class='form-control search-box']";
        public string Arama_Input = "//input[@class='form-control search-box ys-ac-opened']";
        public string Arama_Button = "//button[@class='form-control ys-btn ys-btn-default search-button']";
        public string Popup_Kapama_Button = "//button[@class='modal-header-close']";
        
        public string Odeme_Filter_Click = "//body[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[9]/div[1]";
        public string Odeme_Filter_Secim = "//body[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[9]/div[1]/div[2]/ul[1]/li[4]";
        
        public string Isletme_Sec = "//body[1]/div[2]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/div[2]";
        public string Menu_Element = "";


        public string Secilecek_Urun =
            "/html/body/div[2]/div[@class='row']//div[@class='ys-result-items']/div[1]/div[@class='foodList']/div[1]/a[@href='javascript:void(0);']/i[@class='ys-icons ys-icons-plus']";

        public string Sepete_Ekle = "//button[@class='ys-btn ys-btn-primary ys-btn-lg pull-right add-to-basket']";


    }

    public class Search
    {
        public string Semt_Input_Text = "atasehir";
        public string Urun_Input_Text = "tatlı";
    }

    public class User
    {
        //LOGİN TESTİ DIŞINDA KULLANMAK İÇİN
        // ÖNEMLİ NOT: Doğru Mail ve Şifre verilerini Doğru sıra ile yazınız

        /*
         * MAİL VERİSİ:
         *      Geçersiz
         *      Geçerli
         *      Geçersiz
         *      Geçerli
         * ŞİFRE VERİSİ:
         *      Geçersiz
         *      Geçersiz
         *      Geçerli
         *      Geçerli
         */
        public string GecerliEmail = "Geçerli_Mail";
        public string GecerliSifre = "Geçerli_Şifre";

        public string[] Email = {
            "deneme@gmail.com",
            "Geçerli_Mail",
            "deneme@gmail.com",
            "Geçerli_Mail"
        };
        public string[] Password =
        {
            "denemesifre",
            "denemesifre",
            "Geçerli_Şifre",
            "Geçerli_Şifre"
        };
    }

    public class Message
    {
        public string[] EmailMessage = {
            "Geçersiz Mail Yazıldı",
            "Geçerli Mail Yazıldı",
            "Geçersiz Mail Yazıldı",
            "Geçerli Mail Yazıldı"
        };
        public string[] PassMessage = {
            "Geçersiz Şifre",
            "Geçersiz Şifre",
            "Geçerli Sifre",
            "Geçerli Sifre"
        };
        public string[] loginException = {
            "Hatalı giriş. Lütfen kullanıcı adı ve şifrenizi kontrol edip tekrar deneyiniz.",
            "Hatalı giriş. Lütfen kullanıcı adı ve şifrenizi kontrol edip tekrar deneyiniz.",
            "Hatalı giriş. Lütfen kullanıcı adı ve şifrenizi kontrol edip tekrar deneyiniz.",
            "Giriş Başarılı"
        };
    }
}
