using IPara.DeveloperPortal.Core.Response;

namespace IPara.DeveloperPortal.Core.Request
{
    /// <summary>
    /// Cüzdana kart ekleme servisi içerisinde kullanılacak alanları temsil etmektedir.
    /// </summary>
    public class BankCardCreateRequest : BaseRequest
    {
        public string UserId { get; set; }

        public string CardOwnerName { get; set; }

        public string CardNumber { get; set; }

        public string CardAlias { get; set; }

        public string CardExpireMonth { get; set; }

        public string CardExpireYear { get; set; }

        public string ClientIp { get; set; }

        /// <summary>
        /// Cüzdana kart ekleme istek metodur. Bu metod çeşitli kart bilgilerini ve settings sınıfı içerisinde bize özel olarak oluşan alanları kullanarak
        /// cüzdana bir kartı kaydetmemizi sağlar.
        /// </summary>
        /// <param name="request">Cüzdana kart eklemek için gerekli olan girdilerin olduğu sınıfı temsil eder.</param>
        /// <param name="options">Kullanıcıya özel olarak belirlenen ayarları temsil eder.</param>
        /// <returns></returns>
        public static BankCardCreateResponse Execute(BankCardCreateRequest request, Settings options)
        {
            options.TransactionDate = Helper.GetTransactionDateString();
            options.HashString = options.PrivateKey + request.UserId + request.CardOwnerName + request.CardNumber +
                                 request.CardExpireMonth + request.CardExpireYear + request.ClientIp +
                                 options.TransactionDate;
            return RestHttpCaller.Create()
                .PostJson<BankCardCreateResponse>(options.BaseUrl + "/bankcard/create", Helper.GetHttpHeaders(options, Helper.application_json),
                    request);
        }
    }
}
