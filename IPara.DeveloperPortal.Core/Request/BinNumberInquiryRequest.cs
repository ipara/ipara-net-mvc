using IPara.DeveloperPortal.Core.Response;

namespace IPara.DeveloperPortal.Core.Request
{
    public class BinNumberInquiryRequest : BaseRequest
    {
        /// <summary>
        /// Bin Sorgulama servisleri içerisinde kullanılacak olan bin numarasını temsil eder.
        /// </summary>
        public string BinNumber { get; set; }

        public string Amount { get; set; }

        public bool ThreeD { get; set; }

        /// <summary>
        /// Türkiye genelinde tanımlı olan tüm yerli kartlara ait BIN numaraları için sorgulama yapılmasına izin veren servisi temsil eder. 
        /// </summary>
        /// <param name="request">Istek olarak gelen bin numarasını temsil etmektedir.</param>
        /// <param name="options">Kullanıcıya özel olarak belirlenen ayarları temsil eder.</param>
        /// <returns></returns>
        public static BinNumberInquiryResponse Execute(BinNumberInquiryRequest request, Settings options)
        {
            options.TransactionDate = Helper.GetTransactionDateString();
            options.HashString = options.PrivateKey + request.BinNumber + options.TransactionDate;
            return RestHttpCaller.Create().PostJson<BinNumberInquiryResponse>(options.BaseUrl + "rest/payment/bin/lookup/v2", Helper.GetHttpHeaders(options, Helper.application_json), request);
        }
    }
}