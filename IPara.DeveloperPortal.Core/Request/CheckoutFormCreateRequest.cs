using System.Collections.Generic;
using IPara.DeveloperPortal.Core.Entity;
using IPara.DeveloperPortal.Core.Response;
using Newtonsoft.Json;

namespace IPara.DeveloperPortal.Core.Request
{
 
    public class CheckoutFormCreateRequest : BaseRequest
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("threed")]
        public string Threed { get; set; }

        [JsonProperty("allowedInstallments")]
        public HashSet<string> AllowedInstallments { get; set; }

        [JsonProperty("callbackUrl")]
        public string CallbackUrl { get; set; }

        [JsonProperty("vendorId")]
        public string VendorId { get; set; }

        [JsonProperty("custField1")]
        public string CustField1 { get; set; }

        [JsonProperty("purchaserName")]
        public string PurchaserName { get; set; }

        [JsonProperty("purchaserSurname")]
        public string PurchaserSurname { get; set; }

        [JsonProperty("purchaserEmail")]
        public string PurchaserEmail { get; set; }

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

        public static CheckoutFormCreateResponse Execute(CheckoutFormCreateRequest request, Settings options)
        {
            options.TransactionDate = Helper.GetTransactionDateString();
            options.HashString = options.PrivateKey +
                request.Mode +
                request.Purchaser.Name +
                request.Purchaser.SurName +
                request.Purchaser.Email +
                options.TransactionDate;

            return RestHttpCaller.Create().PostJson<CheckoutFormCreateResponse>(options.BaseUrl + "rest/checkoutForm/create", Helper.GetHttpHeaders(options, Helper.application_json), request);
        }
    }
}

