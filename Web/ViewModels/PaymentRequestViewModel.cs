using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Web.ViewModels
{
    public class PaymentRequestViewModel
    {
        [DisplayName("شناسه قبض")]
        public string BillingId { get; set; }

        [DisplayName("شناسه پرداخت")]
        public string PaymentCode { get; set; }

        public decimal Amount { get; set; }

        public string ReturnUrl { get; set; }

        public string UserId { get; set; }

        [JsonIgnore]
        public string Signature { get; set; }
    }
}
