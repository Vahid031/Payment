using Newtonsoft.Json;

namespace Web.ViewModels
{
    public class PaymentResponseViewModel
    {
        public string Id { get; set; }

        public decimal Amount { get; set; }

        public string ReturnUrl { get; set; }

        [JsonIgnore]
        public string Signature { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }
    }
}
