namespace IPara.DeveloperPortal.Core.Entity
{
    /// <summary>
    /// Bu sınıf tarihe göre ödeme sorgulama servisi isteği sonucunda döndürülen alanları temsil etmektedir. 
    /// </summary>
    public class Payment
    {
        public string result;

        public string responseMessage;

        public string orderId;

        public string amount;

        public string finalAmount;

        public string transactionDate;
    }
}