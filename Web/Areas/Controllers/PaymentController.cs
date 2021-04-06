using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Web.ViewModels;
using System;
using Web.Interfaces;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Domain.Enums;

namespace Web.Areas.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Content("Vahid");
        }

        [HttpPost]
        public async Task<IActionResult> NewRequest([FromForm] PaymentRequestViewModel prvm)
        {
            var h = HttpContext;

            var entity = paymentService.GetByBilligId(prvm.BilligId, new Uri(prvm.ReturnUrl));

            if (!paymentService.ControlRequest(prvm))
            {
                return BadRequest("صحت محتوای درخواست تایید نشد");
            }
            else if (entity is null)
            {
                await paymentService.AddRequest(prvm);
                entity = paymentService.GetByBilligId(prvm.BilligId, new Uri(prvm.ReturnUrl));

                return View(nameof(SendToMabnaCard), new MabnaCardRequest
                {
                    Amount = prvm.Amount,
                    CallbackURL = "https://localhost:44374/payment/ResponseFromMabnaCard",
                    InvoiceID = entity.Id.ToString(),
                    TerminalID = "69002892",
                    Payload = JsonConvert.SerializeObject(prvm)
                });
            }
            else
            {
                return BadRequest("این درخواست پیش از این ثبت شده است");
            }
        }

        public IActionResult SendToMabnaCard(MabnaCardRequest mcr)
        {
            return View(mcr);
        }

        public async Task<IActionResult> ResponseFromMabnaCard(MabnaCardResponse mcr)
        {
            if (mcr.respcode.Equals("0"))
            {
                mcr.Tid = mcr.terminalid;

                return View(mcr);
            }
            else if (mcr.respcode.Equals("1"))
            {
                var prvm = JsonConvert.DeserializeObject<PaymentRequestViewModel>(mcr.Payload);

                await paymentService.ChangeStatus(int.Parse(mcr.InvoiceID), State.RequestSucceed);

                Redirect(prvm.ReturnUrl);
            }
            else if (mcr.respcode.Equals("-1"))
            {
                var prvm = JsonConvert.DeserializeObject<PaymentRequestViewModel>(mcr.Payload);

                await paymentService.ChangeStatus(int.Parse(mcr.InvoiceID), State.RequestFailed);

                return Redirect(prvm.ReturnUrl);
            }

            return Content("");
        }
    }
}