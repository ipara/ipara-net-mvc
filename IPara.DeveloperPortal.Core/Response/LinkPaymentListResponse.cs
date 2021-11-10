using IPara.DeveloperPortal.Core.Entity;
using System.Collections.Generic;

namespace IPara.DeveloperPortal.Core.Response
{
    /// <summary>
    /// Linkle Ödeme -> Link Sorgulama/Listeleme Servisi çıktı parametre alanları temsil eder.
    /// </summary>
    public class LinkPaymentListResponse : BaseResponse
    {
        public List<PaymentLink> LinkPaymentRecordList { get; set; }

        public string PageIndex { get; set; }

        public string PageSize { get; set; }

        public string PageCount { get; set; }
    }
}
