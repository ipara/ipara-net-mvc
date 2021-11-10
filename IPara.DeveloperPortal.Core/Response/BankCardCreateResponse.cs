using System.Collections.Generic;

namespace IPara.DeveloperPortal.Core.Response
{
    /// <summary>
    /// Cüzdana kart ekleme servis çıktı parametre alanlarını temsil eder.
    /// </summary>
    public class BankCardCreateResponse : BaseResponse
    {
        public string CardId { get; set; }

        public string MaskNumber { get; set; }

        public string Alias { get; set; }

        public string BankId { get; set; }

        public string BankName { get; set; }

        public string CardFamilyName { get; set; }

        public string SupportsInstallment { get; set; }

        public List<string> SupportedInstallments { get; set; }

        public string Type { get; set; }

        public string ServiceProvider { get; set; }

        public string ThreeDSecureMandatory { get; set; }

        public string CvcMandatory { get; set; }
    }
}
