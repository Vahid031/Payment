using Domain.Entities;
using Domain.Enums;
using System;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Interfaces
{
    public interface IPaymentService 
    {
        Payment GetByBilligId(string billigId, Uri returnUrl);

        bool ControlRequest(PaymentRequestViewModel prvm);

        Task AddRequest(PaymentRequestViewModel prvm);

        Task ChangeStatus(int id, State state);
    }
}