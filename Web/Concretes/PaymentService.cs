using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Domain.Entities;
using System;
using Web.Interfaces;
using Domain.Context;

namespace Web.Concretes
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
