using System.Collections.Generic;
using IPara.DeveloperPortal.Core.Entity;

namespace IPara.DeveloperPortal.Core.Response
{
    /// <summary>
    /// Bin Sorgulama servisi sonucunda oluşan servis çıktı parametre alanlarını temsil etmektedir. 
    /// </summary>
    public class BinNumberInquiryV4Response : BaseResponse
    {
        public int BankId { get; set; }

        public string BankName { get; set; }

        public int BankFamilyId { get; set; }

        public int CardFamilyId { get; set; }

        public string CardFamilyName { get; set; }

        public int SupportsInstallment { get; set; }

        public List<int> SupportedInstallments { get; set; }

        public int Type { get; set; }

        public int ServiceProvider { get; set; }

        public int CardThreeDSecureMandatory { get; set; }

        public int MerchantThreeDSecureMandatory { get; set; }

        public int CvcMandatory { get; set; }

        public int BusinessCard { get; set; }

        public List<RequiredAmountWithCCommDTO> InstallmentDetailWithCComm { get; set; }

        public int SupportsAgriculture { get; set; }
    }

}

