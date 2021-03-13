using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Web.ViewModels;
using System;
using Web.Interfaces;

namespace Web.Api.Controller
{
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Vahid");
        }

        [HttpPost]
        public IActionResult NewRequest(PaymentRequestViewModel paymentRequest)
        {
            var entity = paymentService.GetByOriginalKey(paymentRequest.OriginalKey, new Uri(paymentRequest.ReturnUrl));

            if (entity is null)
            {
                
            }

            return Ok();
        }

    }
}