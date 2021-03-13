using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Web.ViewModels
{
    public class PaymentRequestViewModel
    {
        public int OriginalKey { get; set; }

        public decimal Amount { get; set; }

        public string Data { get; set; }

        public string ReturnUrl { get; set; }

        public string Signature { get; set; }
    }
}
