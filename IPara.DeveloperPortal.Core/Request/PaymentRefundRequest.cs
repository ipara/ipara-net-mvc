using IPara.DeveloperPortal.Core.Response;

namespace IPara.DeveloperPortal.Core.Request
{
    /// <summary>
    /// İade servisi için gerekli olan servis girdi parametrelerini temsil eder.
    /// </summary>
    public class PaymentRefundRequest : BaseRequest
    {
        public string orderId;

        public string refundHash;

        public string amount;

        public string clientIp;

        /// <summary>
        /// Bu servise iade edilmek istenen siparişin mağaza sipariş numarası, sipariş tutarı, iade sorgulama servisinden dönen refundHash ve clientIp değeri iletilerek, iade durumunun öğrenilebileceği servisi temsil eder.
        /// </summary>
        /// <param name="request">İade servisi için gerekli olan girdilerin olduğu sınıfı temsil eder.</param>
        /// <param name="options">Kullanıcıya özel olarak belirlenen ayarları temsil eder.</param>
        /// <returns></returns>
        public static PaymentRefundResponse Execute(PaymentRefundRequest request, Settings options)
        {
            options.TransactionDate = Helper.GetTransactionDateString();
            options.HashString = options.PrivateKey + request.orderId + request.clientIp + options.TransactionDate;
            return RestHttpCaller.Create()
                .PostJson<PaymentRefundResponse>(options.BaseUrl + "corporate/payment/refund", Helper.GetHttpHeaders(options, Helper.application_json), request);
        }
    }
}