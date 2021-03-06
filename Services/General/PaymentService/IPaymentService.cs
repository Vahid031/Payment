using DomainModels.Entities;
using System;

namespace Services.General.PaymentService
{
    public interface IPaymentService 
    {
        Payment GetByOriginalKey(int OriginalKey, Uri returnUrl);

        Payment Add(int OriginalKey, Uri returnUrl);
    }
}