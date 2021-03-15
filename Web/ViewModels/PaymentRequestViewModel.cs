﻿using System;
using Newtonsoft.Json;

namespace Web.ViewModels
{
    public class PaymentRequestViewModel
    {
        public string Id { get; set; }

        public decimal Amount { get; set; }

        public string ReturnUrl { get; set; }

        [JsonIgnore]
        public string Signature { get; set; }

        public string UserName { get; set; }

        public string UserId { get; set; }
    }
}
