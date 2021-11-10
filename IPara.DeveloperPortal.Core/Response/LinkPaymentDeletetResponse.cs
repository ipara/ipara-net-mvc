using IPara.DeveloperPortal.Core.Entity;
using System.Collections.Generic;

namespace IPara.DeveloperPortal.Core.Response
{
    /// <summary>
    /// Linkle Ödeme -> Link Silme Servisi çıktı parametre alanları temsil eder.
    /// </summary>
    public class LinkPaymentDeleteResponse : BaseResponse
    {
        public List<PaymentLink> LinkPaymentRecordList { get; set; }

        public string PageIndex { get; set; }

        public string PageSize { get; set; }

        public string PageCount { get; set; }
    }
}
