using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities;
using Web.ViewModels;
using System;
using Web.Interfaces;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DataAccess.Enums;

namespace Web.Areas.Controllers.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult CheckTransaction(string billingId)
        {
            var prvm = paymentService.GetByBillingId(billingId);

            if (prvm is null)
                return BadRequest("اطلاعات صحیح نیست");

            var responseModel = new PaymentResponseViewModel
            {
                Amount = prvm.Amount.Value,
                BillingId = prvm.BillingId,
                PaymentCode = prvm.PaymentCode,
                ReturnUrl = prvm.ReturnUrl,
                Success = paymentService.CheckTransaction(prvm.BillingId)
            };
            if (responseModel.Success)
                responseModel.Message = "تراکنش ناموفق بود";
            else
                responseModel.Message = "تراکنش باموفقیت انجام شد";

            return Ok(responseModel);
        }
    }
}