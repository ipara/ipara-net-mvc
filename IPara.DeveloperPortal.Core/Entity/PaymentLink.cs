namespace IPara.DeveloperPortal.Core.Entity
{
    /// <summary>
    /// Linkle Ödeme (Link Sorgulama) servisi sonucu dönen PaymentLink bilgisini tutar.
    /// </summary>
    public class PaymentLink
    {
        public string Amount { set; get; }

        public string CreationDate { set; get; }

        public string Description { set; get; }

        public string Email { set; get; }

        public string Gsm { set; get; }

        public string LinkId { set; get; }

        public string LinkState { set; get; }

        public string Name { set; get; }

        public string Surname { set; get; }

        public string TaxNumber { set; get; }

        public string TcCertificate { set; get; }
    }
}