using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities;
using Web.ViewModels;
using System;
using Web.Interfaces;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DataAccess.Enums;

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
            return View();
        }

        [HttpPost]
        public IActionResult Index(PaymentRequestViewModel model)
        {
            var entity = paymentService.GetByBillingId(model.BillingId);

            if (entity is null)
            {
                ModelState.AddModelError(nameof(model.BillingId), "شناسه قبض مورد نظر یافت نشد");
            }
            else if (entity.PaymentCode != model.PaymentCode)
            {
                ModelState.AddModelError(nameof(model.BillingId), "شناسه پرداخت اشتباه است");
            }

            if (!ModelState.IsValid)
                return View(model);


            return View(nameof(SendToMabnaCard), new MabnaCardRequest
            {
                Amount = Convert.ToInt64(entity.Amount.Value),
                CallbackURL = "https://localhost:44374/payment/ResponseFromMabnaCard",
                InvoiceID = model.BillingId,
                TerminalID = "69002892",
                Payload = JsonConvert.SerializeObject(model)
            });
        }

        [HttpPost]
        public async Task<IActionResult> NewRequest([FromForm] PaymentRequestViewModel prvm)
        {
            var h = HttpContext;

            var entity = paymentService.GetByBillingId(prvm.BillingId);

            if (!paymentService.ControlRequest(prvm))
            {
                return BadRequest("صحت محتوای درخواست تایید نشد");
            }
            else if (entity is null)
            {
                await paymentService.AddRequest(prvm);
                entity = paymentService.GetByBillingId(prvm.BillingId);

                return View(nameof(SendToMabnaCard), new MabnaCardRequest
                {
                    Amount = Convert.ToInt64(entity.Amount.Value),
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

                var responseModel = new PaymentResponseViewModel
                {
                    Amount = prvm.Amount,
                    BillingId = prvm.BillingId,
                    PaymentCode = prvm.PaymentCode,
                    ReturnUrl = prvm.ReturnUrl,
                    Success = false,
                    Message = "تراکنش با موفقیت انجام شد",
                };

                await paymentService.ChangeStatus(int.Parse(mcr.InvoiceID), State.RequestSucceed);

                return View(nameof(ResponseToClient), responseModel);
            }
            else if (mcr.respcode.Equals("-1"))
            {
                var prvm = JsonConvert.DeserializeObject<PaymentRequestViewModel>(mcr.Payload);


                var responseModel = new PaymentResponseViewModel
                {
                    Amount = prvm.Amount,
                    BillingId = prvm.BillingId,
                    PaymentCode = prvm.PaymentCode,
                    ReturnUrl = prvm.ReturnUrl,
                    Success = false,
                    Message = "تراکنش ناموفق بود",
                };

                responseModel.Signature = paymentService.CreateSignature(responseModel);

                await paymentService.ChangeStatus(int.Parse(mcr.InvoiceID), State.RequestFailed);

                return View(nameof(ResponseToClient), responseModel);
            }

            return Content("");
        }

        public IActionResult ResponseToClient(PaymentResponseViewModel prvm)
        {
            return View(prvm);
        }
    }
}