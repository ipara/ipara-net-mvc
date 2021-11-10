using System.Xml.Serialization;

namespace IPara.DeveloperPortal.Core.Response
{
    /// <summary>
    /// 3D secure olmadan ödeme servis çıktı parametre alanlarını temsil etmektedir.
    /// </summary>
    [XmlRoot("authResponse")]
    public class Non3DPaymentResponse : BaseResponse
    {
        [XmlElement("amount")]
        public string Amount { get; set; }

        [XmlElement("orderId")]
        public string OrderId { get; set; }
    }
}
