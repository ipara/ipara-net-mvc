namespace IPara.DeveloperPortal.Core.Entity
{
    public class RequiredAmountWithCCommDTO
    {
        public string RequiredAmount { get; set; }

        public string RequiredCommissionAmount { get; set; }

        public int Installment { get; set; }

        public string CommissionAmount { get; set; }

        public string MerchantCommissionRate { get; set; }

        public string CustomizedRequiredAmount { get; set; }

        public string CustomizedRequiredCommissionAmount { get; set; }

        public string CustomizedMerchantCommissionRate { get; set; }

        public double CommissionAmountTransient { get; set; }

        public double RequiredAmountTransient { get; set; }

        public double MerchantCommissionRateTransient { get; set; }

        public double RequiredCommissionAmountTransient { get; set; }

        public double CustomizedRequiredAmountTransient { get; set; }

        public double CustomizedRequiredCommissionAmountTransient { get; set; }

        public double CustomizedMerchantCommissionRateTransient { get; set; }
    }
}