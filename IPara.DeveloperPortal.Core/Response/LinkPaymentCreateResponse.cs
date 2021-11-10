namespace IPara.DeveloperPortal.Core.Response
{
    /// <summary>
    /// Linkle Ödeme -> Link Gönderimi Servisi çıktı parametre alanları temsil eder.
    /// </summary> 
    public class LinkPaymentCreateResponse : BaseResponse
    {
        public string Link { get; set; }

        public string LinkPaymentId { get; set; }

        public string Amount { get; set; }
    }
}
