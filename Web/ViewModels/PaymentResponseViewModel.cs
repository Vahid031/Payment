using Newtonsoft.Json;

namespace Web.ViewModels
{
    public class PaymentResponseViewModel
    {
        public string BillingId { get; set; }

        public string PaymentCode { get; set; }

        public decimal Amount { get; set; }

        public string ReturnUrl { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }

        [JsonIgnore]
        public string Signature { get; set; }
    }
}
