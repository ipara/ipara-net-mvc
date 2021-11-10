using IPara.DeveloperPortal.Core.Response;

namespace IPara.DeveloperPortal.Core.Request
{
    /// <summary>
    /// Linkle Ödeme -> Link Gönderimi Servisi içerisinde kullanılacak alanları temsil eder.
    /// </summary>
    public class LinkPaymentCreateRequest : BaseRequest
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string TcCertificate { get; set; }

        public string TaxNumber { get; set; }

        public string Email { get; set; }

        public string Gsm { get; set; }

        public int Amount { get; set; }

        public string ThreeD { get; set; }

        public string ExpireDate { get; set; }

        public string SendEmail { get; set; }

        public string CommissionType { get; set; }

        public string ClientIp { get; set; }

        public static LinkPaymentCreateResponse Execute(LinkPaymentCreateRequest request, Settings options)
        {
            options.TransactionDate = Helper.GetTransactionDateString();
            options.HashString = options.PrivateKey + request.Name +
                request.Surname + request.Email + request.Amount +
                request.ClientIp + options.TransactionDate;

            return RestHttpCaller.Create()
                .PostJson<LinkPaymentCreateResponse>(options.BaseUrl + "corporate/merchant/linkpayment/create", Helper.GetHttpHeaders(options, Helper.application_json), request);
        }
    }
}

