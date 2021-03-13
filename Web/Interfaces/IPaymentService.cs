using Domain.Entities;
using System;

namespace Web.Interfaces
{
    public interface IPaymentService 
    {
        Payment GetByOriginalKey(int OriginalKey, Uri returnUrl);
    }
}