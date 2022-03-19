using System.Collections.Generic;
using System.IO;
using Y_SepetiTest.Entities;
using Y_SepetiTest.Model;

namespace Y_SepetiTest.View
{
    public class Rapor
    {
        public void dosyayaYaz(string rastgele)
        {
                string CreateTestId = "YSepeti_" + rastgele;
                GetData getData = new GetData();
                getData.Data(CreateTestId, out var Liste);


                string dosya_yolu = @"C:\Users\emred\source\repos\Y_SepetiTest\LogFile\" + CreateTestId+".html";
                FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs);

                // head oluştur
                HtmlUst(writer);
                // body oluştur
                BodyTableUst(writer);
                TableTopCreate(writer);
                TableDataWrite(writer, Liste);
                BodyKapanis(writer);
                writer.Flush();
                writer.Close();
                fs.Close();
                Liste.RemoveAll(i => i.TestId == CreateTestId);
        }

        

        private static string SatirRengi(string deger)
        {
            var renk = "white";
            switch (deger)
            {
                case "SUCCESS":
                    renk = "#96fc88";
                    break;
               
                case "ERROR":
                    renk = "#fcb4b4";
                    break;
                
            }

            return renk;
        }
        private static string ProcessColor(string deger)
        {
            var renk = "white";
            switch (deger)
            {
                case "SUCCESS":
                    renk = "#96fc88";
                    break;

                case "ERROR":
                    renk = "#fcb4b4";
                    break;
                case "INFO":
                    renk = "#95c3fd";
                    break;
            }

            return renk;
        }
        private static void HtmlUst(StreamWriter writer)
        {
            writer.WriteLine("<!DOCTYPE html>" +
                             "<head>" +
                             "<meta charset='UTF-8'>" +
                             "<meta http-equiv='X-UA-Compatible' content='IE=edge'>" +
                             "<meta name='viewport' content='width=device-width, initial-scale=1.0'>" +
                             "<title>Document</title>" +
                             "<script src='../Bootstrap/bootstrap.min.js' ></script>" +
                             "<link rel='stylesheet' href='../Bootstrap/bootstrap.min.css' />" +
                             "</head>");
        }
        private static void BodyTableUst(StreamWriter writer)
        {
            writer.WriteLine("<body>" +
                             "<div class='mt-5'>" +
                             "<div>" +
                             "<table class='table'>" +
                             "<thead class='thead-dark' style='background-color:#424242;color:white'>" +
                             "<tr>" +
                             "<th scope='col'>#</th>"
            );
        }
        private static void TableTopCreate(StreamWriter writer)
        {
            TableData tableData = new TableData();
            foreach (var data in tableData.tableData)
            {
                writer.WriteLine("<th scope='col'>" + data + "</th>");
            }

            writer.WriteLine("</tr></thead>");
        }
        private static void TableDataWrite(StreamWriter writer, List<TestLog> Liste)
        {
            writer.WriteLine("<tbody>");
            foreach (var lists in Liste)
            {

                string processColor = ProcessColor(lists.Level.ToString());
                string deger = SatirRengi(lists.Level.ToString());
                writer.WriteLine($"<tr style='background-color:" + deger + "'>" +
                                 $"<th style='max-width:100px' scope='row'>{lists.Id}</th>" +
                                 $"<td >{lists.TestId}</td>" +
                                 $"<td style='max-width:100px'>{lists.Data}</td>" +
                                 $"<td style='background-color:" + processColor + "'>" +
                                 $"{lists.Level}</td>" +
                                 $"<td>{lists.Process}</td>" +
                                 $"<td >{lists.Message}</td>" +
                                 $"<td>{lists.URLRequest}</td>" +
                                 $"<td>{lists.RequestLine}</td>" +
                                 $"<td>{lists.Exception}</td> " +
                                 $"</tr>");
            }


            writer.WriteLine("</tbody>");
        }
        private static void BodyKapanis(StreamWriter writer)
        {
            writer.WriteLine("</table>" +
                             "</div>" +
                             "</div>" +
                             "</body>" +
                             "</html>");
            
        }

    }
}
