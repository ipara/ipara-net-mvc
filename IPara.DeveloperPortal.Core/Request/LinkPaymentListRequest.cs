using IPara.DeveloperPortal.Core.Response;

namespace IPara.DeveloperPortal.Core.Request
{
    /// <summary>
    /// Linkle Ödeme -> Link Sorgulama/Listeleme Servisi içerisinde kullanılacak alanları temsil eder.
    /// </summary>
    public class LinkPaymentListRequest : BaseRequest
    {
        public string Email { get; set; }

        public string Gsm { get; set; }

        public string LinkId { get; set; }

        public string LinkState { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string PageSize { get; set; }

        public string PageIndex { get; set; }

        public string ClientIp { get; set; }

        public static LinkPaymentListResponse Execute(LinkPaymentListRequest request, Settings options)
        {
            options.TransactionDate = Helper.GetTransactionDateString();
            options.HashString = options.PrivateKey + request.ClientIp + options.TransactionDate;
            return RestHttpCaller.Create()
                .PostJson<LinkPaymentListResponse>(options.BaseUrl + "corporate/merchant/linkpayment/list", Helper.GetHttpHeaders(options, Helper.application_json), request);
        }
    }
}

