using System.Linq;
using System.Collections.Generic;
using DatabaseContext.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DomainModels.Entities;
using DomainModels.Enums;
using System;

namespace Services.General.PaymentService
{

    public class PaymentService : IPaymentService
    {
        private readonly IAppDbContext db;

        public PaymentService(IAppDbContext db)
        {
            this.db = db;
        }

        public Payment GetByOriginalKey(int OriginalKey, Uri returnUrl)
        {
            return db.Payments.SingleOrDefault(m => m.OriginalKey == OriginalKey && new Uri( m.ReturnUrl ).Equals(returnUrl));
        }
    }
}
