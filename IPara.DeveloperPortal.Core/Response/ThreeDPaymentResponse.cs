namespace IPara.DeveloperPortal.Core.Response
{
    /// <summary>
    ///  Tek Adımda 3D Secure ile ödeme sonucunda oluşan servis çıktı parametrelerini temsil etmektedir.
    /// </summary>
    /// 
    public class ThreeDPaymentResponse : BaseResponse
    {
        public string Amount { get; set; }

        public string OrderId { get; set; }

        public string PublicKey { get; set; }

        public string CommissionRate { get; set; }

        public string ThreeDSecureCode { get; set; }
    }
}
