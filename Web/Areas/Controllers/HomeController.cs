﻿using System.Diagnostics;
using DomainModels.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.General.PaymentService;

namespace Web.Pages.General.Controllers
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

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}