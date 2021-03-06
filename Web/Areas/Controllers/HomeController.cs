using System.Diagnostics;
using Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Interfaces;
using System;
using Newtonsoft.Json;

namespace Web.Areas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IPaymentService paymentService;

        public HomeController(ILogger<HomeController> logger, IPaymentService paymentService)
        {
            this.logger = logger;
            this.paymentService = paymentService;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
