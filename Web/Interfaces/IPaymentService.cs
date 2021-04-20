using DataAccess.Entities;
using DataAccess.Enums;
using System;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Interfaces
{
    public interface IPaymentService 
    {
        Payment GetByBillingId(string BillingId);

        bool ControlRequest(PaymentRequestViewModel prvm);

        Task AddRequest(PaymentRequestViewModel prvm);

        Task ChangeStatus(int id, State state);

        string CreateSignature(PaymentResponseViewModel prvm);

        bool CheckTransaction(string BillingId);
    }
}