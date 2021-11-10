using IPara.DeveloperPortal.Core.Response;

namespace IPara.DeveloperPortal.Core.Request
{
    /// <summary>
    /// Cüzdanda bulunan kartları getirmek için gerekli olan servis girdi parametrelerini temsil eder.
    /// </summary>
    public class BankCardInquiryRequest : BaseRequest
    {
        public string UserId { get; set; }

        public string ClientIp { get; set; }

        public string CardId { get; set; }

        /// <summary>
        /// Mağazanın, cüzdanda bulunan kartları getirmek için kullandığı servisi temsil eder.
        /// </summary>
        /// <param name="request">Cüzdanda bulunan kartları getirmek için gerekli olan girdilerin olduğu sınıfı temsil eder.</param>
        /// <param name="options">Kullanıcıya özel olarak belirlenen ayarları temsil eder.</param>
        /// <returns></returns>
        public static BankCardInquryResponse Execute(BankCardInquiryRequest request, Settings options)
        {
            options.TransactionDate = Helper.GetTransactionDateString();
            options.HashString = options.PrivateKey + request.UserId +
                request.CardId + request.ClientIp + options.TransactionDate;

            return RestHttpCaller.Create().PostJson<BankCardInquryResponse>(options.BaseUrl + "/bankcard/inquiry", Helper.GetHttpHeaders(options, Helper.application_json), request);
        }
    }
}
