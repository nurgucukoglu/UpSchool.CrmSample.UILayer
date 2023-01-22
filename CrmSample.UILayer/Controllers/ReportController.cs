using ClosedXML.Excel;
using CrmSample.DataAccessLayer.Concrete;
using CrmSample.UILayer.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace CrmSample.UILayer.Controllers
{
    [AllowAnonymous]


    public class ReportController : Controller
    {

        public IActionResult ReportList() //önce bu sayfaya gidelim, burası üzerinden istek atıcaz indirmeye.
        {
            ViewBag.isUserAdmin = User.Claims.Any(x => x.Value == "admin");


            return View();

        }

        //static excel listesi yapıcaz önce, controller.a veri göndericez yani sonra dinamiğe çeviricez.
        public IActionResult ExcelStatic()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var workSheet = excelPackage.Workbook.Worksheets.Add("Sayfa1"); //bir worksheet açtık. kalanı hücre yazımı

            workSheet.Cells[1, 1].Value = "Personel ID";  //başlıklar
            workSheet.Cells[1, 2].Value = "Personel Adı";
            workSheet.Cells[1, 3].Value = "Personel Soyadı";


            workSheet.Cells[2, 1].Value = "001"; //veriler
            workSheet.Cells[2, 2].Value = "Tuba";
            workSheet.Cells[2, 3].Value = "Zorlu";

            workSheet.Cells[3, 1].Value = "002";
            workSheet.Cells[3, 2].Value = "Serap";
            workSheet.Cells[3, 3].Value = "Beran";

            var bytes = excelPackage.GetAsByteArray(); //bytes.a dönüştürecek
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "personeller.xlsx"); //excel context type, mime type
        }


        public List<CustomerViewModel> CustomerList() //önce model üzerinden listeye erişmemiz lazım.
        {
            List<CustomerViewModel> customerViewModels = new List<CustomerViewModel>();

            using (var context = new Context()) //customer entitye erişmemiz gerek çünkü onun üzerinden atamalarımızı yapıcaz.
            {
                customerViewModels = context.Customers.Select(x => new CustomerViewModel //customerviewmodelse atama yapıcaz. select ile çekicez.
                {

                    Mail = x.CustomerMail,
                    Name = x.CustomerName,
                    Surname = x.CustomerSurname,
                    Phone = x.CustomerPhone

                }).ToList();

                return customerViewModels;

            }

        }

        public IActionResult DynamicExcel()
        {
            using (var workbook =new  XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Müşteri Listesi");//bir çalışma sayfası oluşturucaz.
                worksheet.Cell(1,1).Value = "Mail adresi";
                worksheet.Cell(1,2).Value = "m adı";
                worksheet.Cell(1,3).Value = "M soyadı";
                worksheet.Cell(1,4).Value = "M telefon";


                int rowCount = 2; //count ile listeden
                foreach (var item in CustomerList())
                {
                    worksheet.Cell(rowCount, 1).Value = item.Mail;
                    worksheet.Cell(rowCount, 2).Value = item.Name;
                    worksheet.Cell(rowCount, 3).Value = item.Surname;
                    worksheet.Cell(rowCount, 4).Value = item.Phone;
                    rowCount++;
                }

                using(var stream= new MemoryStream())//stream:dosya işlemlerinde kullanılır. //BU SEFER YUKARIDAKİNDEN FARKLI YAPTIK.
                {
                    workbook.SaveAs(stream); //akışın içine workbboktan gelen değeri dahil ettik.
                    var content=stream.ToArray(); //direkt diziye çevirdik bu sefer 
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Musteri_Listesi.xlsx"); 
                }    
            }
               
        }


        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReport/" + "Musteri.pdf"); //combine metodu ilk p:bulunduğum dizine git,2.:pathi yazdık + isim verdik.
            var stream = new FileStream(path, FileMode.Create); //create modunda kullandık.

            Document document = new Document(PageSize.A4); 
            PdfWriter.GetInstance(document, stream); //itextsharp(namespace)
            document.Open();
            Paragraph paragraph = new Paragraph(
                "1.SÖZLEŞMENİN KONUSU\r\n\r\n1.1. İş bu sözleşmenin konusu sitede belirtilen hizmetler ile ilgili karşılıklı hakların korunması ve yükümlülüklerin belirlenmesidir.\r\n1.2. Taraflar iş bu sözleşmede yazılı bilgilerin doğruluğunu beyan, kabul ve taahhüt ederler." +
                "3.TARAFLARIN HAK VE YÜKÜMLÜLÜKLERİ\r\n\r\n3.1.1. Müşteri, kendisine tahsis edilen disk bölümlerinde ve/veya veritabanlarında barındırdıkları veri ve içeriklerden kendisi sorumludur.\r\n3.1.2. PrestaTürk Bilişim Teknolojileri, Türkiye Cumhuriyeti yasaları ile Türkiye Cumhuriyeti tarafından tanınmış olan uluslararası sözleşmelere ve ulusal ve uluslararası fikir, sanat eseri, patent ve marka haklarına muhalefet eden müzik notası, kitap, e-kitap, mp3 ve çeşitli video formatları gibi her tür formattaki yazı, ses, kısmi kod içeren ya da tam sürüm olarak her tür program ve görüntü verilerinin eser sahibinin izni olmaksızın kamuya dağıtılmasına ve Müşteriye ayrılan disk alanında bulundurulmasına müsaade etmez.");
            document.Add(paragraph);
            document.Close();
            return File("/PdfReport/Musteri.Pdf", "application/pdf", "Musteri.pdf");
        }
    }
}
