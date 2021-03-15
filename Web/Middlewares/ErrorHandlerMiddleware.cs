using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Domain.Context;
using Domain.Entities;
using Newtonsoft.Json;

namespace Web.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly IAppDbContext _db;

        public ErrorHandlerMiddleware(RequestDelegate next)//, IAppDbContext db)
        {
            _next = next;
            //_db = db;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                //_db.Logs.Add(new Log
                //{
                //    Date = DateTime.Now,
                //    Data = JsonConvert.SerializeObject(context.Request),
                //    Type = "Request"
                //});
                //await _db.SaveChangesAsync();

                await _next(context);

            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await response.WriteAsync("مشکلی در ارتباط با سرور رخ داده است");

            }
            //_db.Logs.Add(new Log
            //{
            //    Date = DateTime.Now,
            //    Data = JsonConvert.SerializeObject(context.Response),
            //    Type = "Response"
            //});
            //await _db.SaveChangesAsync();
        }
    }
}
