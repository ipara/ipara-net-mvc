using System;
using System.Collections.Generic;
using IPara.DeveloperPortal.Core.Entity;
using IPara.DeveloperPortal.Core.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPara.DeveloperPortal.WebSamples.Controllers
{
    /// <summary>
    /// Bu controller sizler için hazırlamış olduğumuz örnek web projesini temsil etmektedir.
    /// Bu controller içerisinde iPara servislerine istek görderme ve gönderilen istekler sonucunda tarafınıza gelen cevapları
    /// görebilirsiniz.
    /// </summary>
    public class HomeController : BaseController
    {
        /// <summary>
        /// 3D ile ödeme 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Tek adımda 3D ile ödeme Post işlemi
        /// </summary>
        /// <param name="nameSurname"></param>
        /// <param name="cardNumber"></param>
        /// <param name="cvc"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="amount"></param>
        /// <param name="installment"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(string nameSurname, string cardNumber, string month, string year, string cvc, string amount, string installment)
        {
            ThreeDPaymentRequest request = new();
            request.OrderId = Guid.NewGuid().ToString();
            request.Version = settings.Version;
            request.Amount = amount;
            request.CardOwnerName = nameSurname;
            request.CardNumber = cardNumber;
            request.CardExpireMonth = month;
            request.CardExpireYear = year;
            request.Installment = installment;
            request.Cvc = cvc;

            request.Echo = "";
            request.Mode = settings.Mode;
            request.UserId = "";
            request.CardId = "";
            request.Language = "tr-TR";
            request.SuccessUrl = "https://apitest.ipara.com/rest/payment/threed/test/result";
            request.FailUrl = "https://apitest.ipara.com/rest/payment/threed/test/result";

            request.Purchaser = new();
            request.Purchaser.Name = "Murat";
            request.Purchaser.SurName = "Kaya";
            request.Purchaser.BirthDate = "1986-07-11";
            request.Purchaser.Email = "murat@kaya.com";
            request.Purchaser.GsmPhone = "5881231212";
            request.Purchaser.IdentityNumber = "12345678901";
            request.Purchaser.ClientIp = "127.0.0.1";

            request.Products = new List<Product>();
            Product p = new();
            p.Title = "Telefon";
            p.Code = "TLF0001";
            p.Price = "5000";
            p.Quantity = 1;
            request.Products.Add(p);

            p = new();
            p.Title = "Bilgisayar";
            p.Code = "BLG0001";
            p.Price = "5000";
            p.Quantity = 1;
            request.Products.Add(p);

            string threeDform = ThreeDPaymentRequest.Execute(request, settings);
            HttpResponseWritingExtensions.WriteAsync(this.Response, threeDform);

            return View();
        }

        /// <summary>
        /// Non-3D ödeme sayfasını temsil eder.
        /// </summary>
        /// <returns></returns>
        public ActionResult Non3dPayment()
        {
            return View();
        }

        /// <summary>
        /// Non-3D ödeme sayfasından post edilen değerlerle ilgili servise istek bilgisinin gönderildiği sonucunun ekrana yazdırıldığı sayfayı temsil eder.
        /// </summary>
        /// <param name="nameSurname"></param>
        /// <param name="cardNumber"></param>
        /// <param name="cvc"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="amount"></param>
        /// <param name="installment"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Non3dPayment(string nameSurname, string cardNumber, string cvc, string month, string year, string amount, string installment)
        {
            Non3DPaymentRequest request = new();
            request.OrderId = Guid.NewGuid().ToString();
            request.Amount = amount;
            request.CardOwnerName = nameSurname;
            request.CardNumber = cardNumber;
            request.CardExpireMonth = month;
            request.CardExpireYear = year;
            request.Installment = installment;
            request.Cvc = cvc;

            request.Echo = "Echo";
            request.Mode = settings.Mode;
            request.ThreeD = "false";
            request.CardId = "";
            request.UserId = "";

            request.Purchaser = new();
            request.Purchaser.Name = "Murat";
            request.Purchaser.SurName = "Kaya";
            request.Purchaser.BirthDate = "1986-07-11";
            request.Purchaser.Email = "murat@kaya.com";
            request.Purchaser.GsmPhone = "5881231212";
            request.Purchaser.IdentityNumber = "12345678901";
            request.Purchaser.ClientIp = "127.0.0.1";

            request.Purchaser.InvoiceAddress = new();
            request.Purchaser.InvoiceAddress.Name = "Murat";
            request.Purchaser.InvoiceAddress.SurName = "Kaya";
            request.Purchaser.InvoiceAddress.Address = "Mevlüt Pehlivan Mah. Multinet Plaza Şişli";
            request.Purchaser.InvoiceAddress.ZipCode = "34782";
            request.Purchaser.InvoiceAddress.CityCode = "34";
            request.Purchaser.InvoiceAddress.IdentityNumber = "12345678901";
            request.Purchaser.InvoiceAddress.CountryCode = "TR";
            request.Purchaser.InvoiceAddress.TaxNumber = "123456";
            request.Purchaser.InvoiceAddress.TaxOffice = "Kozyatağı";
            request.Purchaser.InvoiceAddress.CompanyName = "iPara";
            request.Purchaser.InvoiceAddress.PhoneNumber = "2122222222";

            request.Purchaser.ShippingAddress = new();
            request.Purchaser.ShippingAddress.Name = "Murat";
            request.Purchaser.ShippingAddress.SurName = "Kaya";
            request.Purchaser.ShippingAddress.Address = "Mevlüt Pehlivan Mah. Multinet Plaza Şişli";
            request.Purchaser.ShippingAddress.ZipCode = "34782";
            request.Purchaser.ShippingAddress.CityCode = "34";
            request.Purchaser.ShippingAddress.IdentityNumber = "12345678901";
            request.Purchaser.ShippingAddress.CountryCode = "TR";
            request.Purchaser.ShippingAddress.PhoneNumber = "2122222222";

            request.Products = new List<Product>();
            Product p = new();
            p.Title = "Telefon";
            p.Code = "TLF0001";
            p.Price = "5000"; //50.00 TL 
            p.Quantity = 1;
            request.Products.Add(p);

            p = new();
            p.Title = "Bilgisayar";
            p.Code = "BLG0001";
            p.Price = "5000"; //50.00 TL 
            p.Quantity = 1;
            request.Products.Add(p);

            return View(Non3DPaymentRequest.Execute(request, settings));
        }

        /// <summary>
        /// Ödeme sorgulama sayfasını temsil eder.
        /// </summary>
        /// <returns></returns>
        public ActionResult PaymentInquiry()
        {
            return View();
        }

        /// <summary>
        /// Ödeme sorgulama sonucu post edilen değerlerle ilgili servise istek bilgisinin gönderildiği sonucunun ekrana yazdırıldığı sayfayı temsil eder.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PaymentInquiry(string orderId)
        {
            PaymentInquiryRequest request = new();
            request.OrderId = orderId;
            request.Mode = settings.Mode;
            request.Echo = "Echo";

            return View(PaymentInquiryRequest.Execute(request, settings));
        }

        /// <summary>
        /// Tarihlere göre ödeme sorgulama sayfasını temsil eder.
        /// </summary>
        /// <returns></returns>
        public ActionResult PaymentInquiryWithTime()
        {
            ViewBag.momentStartDate = DateTime.Now.AddDays(-10);
            ViewBag.momentEndDate = DateTime.Now;
            return View();
        }

        /// <summary>
        /// Tarihlere göre ödeme sorgulama sonucu post edilen değerlerle ilgili servise istek bilgisinin gönderildiği sonucunun ekrana yazdırıldığı sayfayı temsil eder.
        /// </summary>
        /// <param name="startDay"></param>
        /// <param name="startMonth"></param>
        /// <param name="startYear"></param>
        /// <param name="endDay"></param>
        /// <param name="endMonth"></param>
        /// <param name="endYear"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PaymentInquiryWithTime(string startDay, string startMonth, string startYear, string endDay, string endMonth, string endYear)
        {
            PaymentInquiryWithTimeRequest request = new();
            request.StartDate = startYear + "-" + startMonth + "-" + startDay + " 00:00:00";
            request.EndDate = endYear + "-" + endMonth + "-" + endDay + " 00:00:00";
            request.Mode = settings.Mode;
            request.Echo = "Echo";

            ViewBag.momentStartDate = DateTime.Now.AddDays(-10);
            ViewBag.momentEndDate = DateTime.Now;

            return View(PaymentInquiryWithTimeRequest.Execute(request, settings));
        }

        /// <summary>
        /// Bin sorgulama sayfasını temsil eder.
        /// </summary>
        /// <returns></returns>
        public ActionResult BinInquiry()
        {
            return View();
        }

        /// <summary>
        /// Bin sorgulama sayfasından post edilen bin numarasının ilgili serviste işlenip sonucunun ekranda gösterildiği sayfayı temsil eder.
        /// </summary>
        /// <param name="binNumber"></param>
        /// <param name="amount"></param>
        /// <param name="threeD"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BinInquiry(string binNumber, string amount, bool threeD)
        {
            BinNumberInquiryRequest request = new();
            request.BinNumber = binNumber;
            request.Amount = amount;
            request.ThreeD = threeD;

            return View(BinNumberInquiryRequest.Execute(request, settings));
        }

        /// <summary>
        /// Cüzdana kart ekleme sayfasını temsil eder.
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCardToWallet()
        {
            return View();
        }

        /// <summary>
        /// Cüzdana kart ekleme sayfasından post edilen değerlerle ilgili servise istek bilgisinin gönderilip sonucunun ekrana yazdırıldığı sayfayı temsil eder.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="nameSurname"></param>
        /// <param name="cardNumber"></param>
        /// <param name="cardAlias"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCardToWallet(string userId, string nameSurname, string cardNumber, string cardAlias, string month, string year)
        {
            BankCardCreateRequest request = new();
            request.UserId = userId;
            request.CardOwnerName = nameSurname;
            request.CardNumber = cardNumber;
            request.CardAlias = cardAlias;
            request.CardExpireMonth = month;
            request.CardExpireYear = year;
            request.ClientIp = "127.0.0.1";

            return View(BankCardCreateRequest.Execute(request, settings));
        }

        /// <summary>
        /// Cüzdandaki Kartları Listeleme sayfasını temsil eder.
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCardFromWallet()
        {
            return View();
        }

        /// <summary>
        /// Cüzdandaki Kartları Listele sayfasından post edilen değerlerle ilgili servise istek bilgisinin gönderilip sonucunun ekrana yazdırıldığı sayfayı temsil eder.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cardId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetCardFromWallet(string userId, string cardId)
        {
            BankCardInquiryRequest request = new();
            request.UserId = userId;
            request.CardId = cardId;
            request.ClientIp = "127.0.0.1";

            return View(BankCardInquiryRequest.Execute(request, settings));
        }

        /// <summary>
        /// Cüzdandaki kartları silme sayfasını temsil eder.
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteCardFromWallet()
        {
            return View();
        }

        /// <summary>
        /// Cüzdandaki kartları silme sayfasından post edilen değerlerle ilgili servise istek bilgisinin gönderildiği sonucunun ekrana yazdırıldığı sayfayı temsil eder.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cardId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteCardFromWallet(string userId, string cardId)
        {
            BankCardDeleteRequest request = new();
            request.UserId = userId;
            request.CardId = cardId;
            request.ClientIp = "127.0.0.1";

            return View(BankCardDeleteRequest.Execute(request, settings));
        }

        /// <summary>
        /// Cüzdandaki kart ile ödeme sayfasını temsil eder.
        /// </summary>
        /// <returns></returns>
        public ActionResult Non3dPaymentWithWallet()
        {
            return View();
        }

        /// <summary>
        /// Cüzdandaki kart sayfasından post edilen değerlerle ilgili servise istek bilgisinin gönderildiği sonucunun ekrana yazdırıldığı sayfayı temsil eder.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cardId"></param>
        /// <param name="installment"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Non3dPaymentWithWallet(string userId, string cardId, string installment)
        {
            Non3DPaymentRequest request = new();
            request.OrderId = Guid.NewGuid().ToString();
            request.Echo = "Echo"; // Cevap anında geri gelecek işlemi ayırt etmeye yarayacak alan
            request.Mode = settings.Mode;
            request.Amount = "10000"; // 100.00 TL
            request.CardOwnerName = "";
            request.CardNumber = "";
            request.CardExpireMonth = "";
            request.CardExpireYear = "";
            request.Installment = installment;
            request.Cvc = "";
            request.ThreeD = "false";
            request.CardId = cardId;
            request.UserId = userId;

            request.Purchaser = new();
            request.Purchaser.Name = "Murat";
            request.Purchaser.SurName = "Kaya";
            request.Purchaser.BirthDate = "1986-07-11";
            request.Purchaser.Email = "murat@kaya.com";
            request.Purchaser.GsmPhone = "5881231212";
            request.Purchaser.IdentityNumber = "12345678901";
            request.Purchaser.ClientIp = "127.0.0.1";

            request.Purchaser.InvoiceAddress = new();
            request.Purchaser.InvoiceAddress.Name = "Murat";
            request.Purchaser.InvoiceAddress.SurName = "Kaya";
            request.Purchaser.InvoiceAddress.Address = "Mevlüt Pehlivan Mah. Multinet Plaza Şişli";
            request.Purchaser.InvoiceAddress.ZipCode = "34782";
            request.Purchaser.InvoiceAddress.CityCode = "34";
            request.Purchaser.InvoiceAddress.IdentityNumber = "12345678901";
            request.Purchaser.InvoiceAddress.CountryCode = "TR";
            request.Purchaser.InvoiceAddress.TaxNumber = "123456";
            request.Purchaser.InvoiceAddress.TaxOffice = "Kozyatağı";
            request.Purchaser.InvoiceAddress.CompanyName = "iPara";
            request.Purchaser.InvoiceAddress.PhoneNumber = "2122222222";

            request.Purchaser.ShippingAddress = new();
            request.Purchaser.ShippingAddress.Name = "Murat";
            request.Purchaser.ShippingAddress.SurName = "Kaya";
            request.Purchaser.ShippingAddress.Address = "Mevlüt Pehlivan Mah. Multinet Plaza Şişli";
            request.Purchaser.ShippingAddress.ZipCode = "34782";
            request.Purchaser.ShippingAddress.CityCode = "34";
            request.Purchaser.ShippingAddress.IdentityNumber = "12345678901";
            request.Purchaser.ShippingAddress.CountryCode = "TR";
            request.Purchaser.ShippingAddress.PhoneNumber = "2122222222";

            request.Products = new List<Product>();
            Product p = new();
            p.Title = "Telefon";
            p.Code = "TLF0001";
            p.Price = "5000"; //50.00 TL 
            p.Quantity = 1;
            request.Products.Add(p);

            p = new();
            p.Title = "Bilgisayar";
            p.Code = "BLG0001";
            p.Price = "5000"; //50.00 TL 
            p.Quantity = 1;
            request.Products.Add(p);

            return View(Non3DPaymentRequest.Execute(request, settings));
        }

        /// <summary>
        /// Link İle Ödeme (Link Gönderim) sayfasını temsil eder.
        /// </summary>
        /// <returns></returns>
        public ActionResult LinkPaymentCreate()
        {
            ViewBag.moment = DateTime.Now;
            return View();
        }

        /// <summary>
        /// Link İle Ödeme (Link Gönderim) sayfasından post edilen değerlerle ilgili servise istek bilgisinin gönderildiği sonucunun ekrana yazdırıldığı sayfayı temsil eder.
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="tcCertificate"></param>
        /// <param name="taxNumber"></param>
        /// <param name="email"></param>
        /// <param name="gsm"></param>
        /// <param name="amount"></param>
        /// <param name="threeD"></param>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="installmentList"></param>
        /// <param name="sendEmail"></param>
        /// <param name="commissionType"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LinkPaymentCreate(string name, string surname, string tcCertificate, string taxNumber, string email, string gsm,
            string amount, string threeD, string day, string month, string year, string sendEmail, string commissionType)
        {
            LinkPaymentCreateRequest request = new();
            request.Name = name;
            request.Surname = surname;
            request.TcCertificate = tcCertificate;
            request.TaxNumber = taxNumber;
            request.Email = email;
            request.Gsm = gsm;
            request.Amount = Convert.ToInt32(amount);
            request.ThreeD = threeD;
            request.ExpireDate = year + "-" + month + "-" + day + " 23:59:59"; // Link girilen günün sonuna kadar geçerli olacak.
            request.SendEmail = sendEmail;
            request.CommissionType = commissionType;
            request.ClientIp = "127.0.0.1";
            ViewBag.moment = DateTime.Now;

            return View(LinkPaymentCreateRequest.Execute(request, settings));
        }

        /// <summary>
        /// Link İle Ödeme (Link Sorgulama/Listeleme) sayfasını temsil eder.
        /// </summary>
        /// <returns></returns>
        public ActionResult LinkPaymentList()
        {
            ViewBag.moment = DateTime.Now;
            return View();
        }

        /// <summary>
        /// Link İle Ödeme (Link Sorgulama/Listeleme) sayfasından post edilen değerlerle ilgili servise istek bilgisinin gönderildiği sonucunun ekrana yazdırıldığı sayfayı temsil eder.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="gsm"></param>
        /// <param name="linkState"></param>
        /// <param name="startDay"></param>
        /// <param name="startMonth"></param>
        /// <param name="startYear"></param>
        /// <param name="endDay"></param>
        /// <param name="endMonth"></param>
        /// <param name="endYear"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LinkPaymentList(string email, string gsm, string linkState, string startDay, string startMonth,
            string startYear, string endDay, string endMonth, string endYear, string pageSize, string pageIndex)
        {
            LinkPaymentListRequest request = new();
            request.Email = email;
            request.Gsm = gsm;
            request.LinkState = linkState != "-1" ? linkState : null;
            if (!String.IsNullOrEmpty(startDay))
            { // Eğer başlangıç tarihi girildiyse, bitiş tarihi de girilmelidir.
                request.StartDate = startYear + "-" + startMonth + "-" + startDay + " 00:00:00";
                request.EndDate = endYear + "-" + endMonth + "-" + endDay + " 23:59:59";
            }
            else
            {
                request.StartDate = null;
                request.EndDate = null;
            }
            request.PageSize = pageSize;
            request.PageIndex = pageIndex;
            request.ClientIp = "127.0.0.1";
            ViewBag.moment = DateTime.Now;

            return View(LinkPaymentListRequest.Execute(request, settings));
        }

        /// <summary>
        /// Link İle Ödeme (Link Silme) sayfasını temsil eder.
        /// </summary>
        /// <returns></returns>
        public ActionResult LinkPaymentDelete()
        {
            return View();
        }

        /// <summary>
        /// Link İle Ödeme (Link Silme) sayfasından post edilen değerlerle ilgili servise istek bilgisinin gönderildiği sonucunun ekrana yazdırıldığı sayfayı temsil eder.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LinkPaymentDelete(string linkId)
        {
            LinkPaymentDeleteRequest request = new();
            request.LinkId = linkId;
            request.ClientIp = "127.0.0.1";

            return View(LinkPaymentDeleteRequest.Execute(request, settings));
        }

        /// <summary>
        /// Iade sayfasını temsil eder.
        /// </summary>
        /// <returns></returns>
        public ActionResult PaymentRefund()
        {
            return View();
        }

        /// <summary>
        /// Iade sayfasından post edilen değerlerle ilgili servise istek bilgisinin gönderildiği sonucunun ekrana yazdırıldığı sayfayı temsil eder.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PaymentRefund(string orderId, string refundHash, string amount)
        {
            PaymentRefundRequest request = new();
            request.orderId = orderId;
            request.refundHash = refundHash;
            request.amount = amount;
            request.clientIp = "127.0.0.1";

            return View(PaymentRefundRequest.Execute(request, settings));
        }

        /// <summary>
        /// Iade Sorgula sayfasını temsil eder.
        /// </summary>
        /// <returns></returns>
        public ActionResult PaymentRefundInquiry()
        {
            return View();
        }

        /// <summary>
        /// Iade Sorgula sayfasından post edilen değerlerle ilgili servise istek bilgisinin gönderildiği sonucunun ekrana yazdırıldığı sayfayı temsil eder.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PaymentRefundInquiry(string orderId, string amount)
        {
            PaymentRefundInquiryRequest request = new();
            request.OrderId = orderId;
            request.Amount = amount;
            request.ClientIp = "127.0.0.1";

            return View(PaymentRefundInquiryRequest.Execute(request, settings));
        }
    }
}

