using IPara.DeveloperPortal.Core.Response;

namespace IPara.DeveloperPortal.Core.Request
{
    /// <summary>
    /// Linkle Ödeme -> Link Silme Servisi içerisinde kullanılacak alanları temsil eder.
    /// </summary>
    public class LinkPaymentDeleteRequest : BaseRequest
    {
        public string LinkId { get; set; }

        public string ClientIp { get; set; }

        public static LinkPaymentDeleteResponse Execute(LinkPaymentDeleteRequest request, Settings options)
        {
            options.TransactionDate = Helper.GetTransactionDateString();
            options.HashString = options.PrivateKey + request.ClientIp + options.TransactionDate;
            return RestHttpCaller.Create()
                .PostJson<LinkPaymentDeleteResponse>(options.BaseUrl + "corporate/merchant/linkpayment/delete", Helper.GetHttpHeaders(options, Helper.application_json), request);
        }
    }
}

