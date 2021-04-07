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

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAppDbContext db)
        {
            try
            {
                //db.Logs.Add(new Log
                //{
                //    Date = DateTime.Now,
                //    Data = JsonConvert.SerializeObject(context.Request),
                //    Type = "Request"
                //});
                //await db.SaveChangesAsync();

                await _next(context);

            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await response.WriteAsync("مشکلی در ارتباط با سرور رخ داده است");

            }
            db.Logs.Add(new Log
            {
                Date = DateTime.Now,
                Data = JsonConvert.SerializeObject(context.Response),
                Type = "Response"
            });
            await db.SaveChangesAsync();
        }
    }
}
