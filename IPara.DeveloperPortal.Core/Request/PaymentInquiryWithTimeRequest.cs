using IPara.DeveloperPortal.Core.Response;

namespace IPara.DeveloperPortal.Core.Request
{
    /// <summary>
    /// Girilen tarih aralığında bulunan ödemeleri sorgulama servisi için gerekli olan servis girdi parametrelerini temsil eder.
    /// </summary>
    public class PaymentInquiryWithTimeRequest : BaseRequest
    {
        public string StartDate { get; set; }

        public string EndDate { get; set; }

        /// <summary>
        /// Bu servise sorgulanmak istenen tarihler içindeki ödemelerin başlangıç ve bitiş tarihi değerleri iletilerek, ödemenin durumu ve ödemenin tutarı öğrenilebileceği servisi temsil eder.
        /// </summary>
        /// <param name="request">Ödeme sorgulama servisi için gerekli olan girdilerin olduğu sınıfı temsil eder.</param>
        /// <param name="options">Kullanıcıya özel olarak belirlenen ayarları temsil eder.</param>
        /// <returns></returns>
        public static PaymentInquiryWithTimeResponse Execute(PaymentInquiryWithTimeRequest request, Settings options)
        {
            options.TransactionDate = Helper.GetTransactionDateString();
            options.HashString = options.PrivateKey + options.Mode + options.TransactionDate;
            return RestHttpCaller.Create()
                .PostJson<PaymentInquiryWithTimeResponse>(options.BaseUrl + "rest/payment/search", Helper.GetHttpHeaders(options, Helper.application_json), request);
        }
    }
}
