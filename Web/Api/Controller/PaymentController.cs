using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Web.Api.Controller
{
    [ApiController]
    //[ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    public class PaymentController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Vahid");
        }

        [HttpPost]
        public IActionResult Get(int key, string text)
        {
            return Ok(new { Key = key, Text = text});
        }

    }
}