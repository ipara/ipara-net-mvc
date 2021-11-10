using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using IPara.DeveloperPortal.Core.Entity;
using Newtonsoft.Json;

namespace IPara.DeveloperPortal.Core.Request
{
    /// <summary>
    /// 3D Ödeme için gerekli olan servis girdi parametrelerini temsil eder. 
    /// </summary>
    public class ThreeDPaymentRequest : BaseRequest
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("cardOwnerName")]
        public string CardOwnerName { get; set; }

        [JsonProperty("cardNumber")]
        public string CardNumber { get; set; }

        [JsonProperty("cardExpireMonth")]
        public string CardExpireMonth { get; set; }

        [JsonProperty("cardExpireYear")]
        public string CardExpireYear { get; set; }

        [JsonProperty("cardCvc")]
        public string Cvc { get; set; }

        [JsonProperty("installment")]
        public string Installment { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("cardId")]
        public string CardId { get; set; }

        [JsonProperty("purchaserName")]
        public string PurchaserName { get; set; }

        [JsonProperty("purchaserSurname")]
        public string PurchaserSurname { get; set; }

        [JsonProperty("purchaserEmail")]
        public string PurchaserEmail { get; set; }

        [JsonProperty("successUrl")]
        public string SuccessUrl { get; set; }

        [JsonProperty("failureUrl")]
        public string FailUrl { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("transactionDate")]
        public string TransactionDate { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("products")]
        public List<Product> Products { get; set; }

        [JsonProperty("purchaser")]
        public Purchaser Purchaser { get; set; }

        public static string CreateThreeDPaymentForm(String parameters, Settings options)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
            builder.Append("<html>");
            builder.Append("<body>");
            builder.Append("<form //action=\"" + options.BaseUrl + "rest/payment/threed" + "\" method=\"post\" id=\"three_d_form\" >");
            builder.Append("<input type=\"hidden\" name=\"parameters\" value=\"" + HttpUtility.HtmlEncode(parameters) + "\"/>");
            builder.Append("<input type=\"submit\" value=\"Öde\" style=\"display:none;\"/>");
            builder.Append("<noscript>");
            builder.Append("<br/>");
            builder.Append("<br/>");
            builder.Append("<center>");
            builder.Append("<h1>3D Secure Yönlendirme İşlemi</h1>");
            builder.Append("<h2>Javascript internet tarayıcınızda kapatılmış veya desteklenmiyor.<br/></h2>");
            builder.Append("<h3>Lütfen banka 3D Secure sayfasına yönlenmek için tıklayınız.</h3>");
            builder.Append("<input type=\"submit\" value=\"3D Secure Sayfasına Yönlen\">");
            builder.Append("</center>");
            builder.Append("</noscript>");
            builder.Append("</form>");
            builder.Append("</body>");
            builder.Append("<script>document.getElementById(\"three_d_form\").submit();</script>");
            builder.Append("</html>");
            return builder.ToString();
        }

        public static string Execute(ThreeDPaymentRequest request, Settings options)
        {
            request.TransactionDate = Helper.GetTransactionDateString();
            options.HashString = options.PrivateKey + request.OrderId + request.Amount +
                request.Mode + request.CardOwnerName + request.CardNumber +
                request.CardExpireMonth + request.CardExpireYear + request.Cvc +
                request.UserId + request.CardId + request.Purchaser.Name +
                request.Purchaser.SurName + request.Purchaser.Email + request.TransactionDate;

            request.Token = Helper.CreateToken(options.PublicKey, options.HashString);
            var parameters = JsonBuilder.SerializeToJsonString(request);
            return CreateThreeDPaymentForm(parameters, options);
        }
    }
}

