﻿using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using System;
using Web.Interfaces;
using Domain.Context;
using Web.ViewModels;
using Domain.Enums;
using System.Security.Cryptography;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace Web.Concretes
{

    public class PaymentService : IPaymentService
    {
        private readonly IAppDbContext _db;

        public PaymentService(IAppDbContext db)
        {
            _db = db;
        }

        public Payment GetByOriginalKey(string originalKey, Uri returnUrl)
        {
            return _db.Payments.Where(m => m.OriginalKey.Equals(originalKey)).FirstOrDefault();
        }

        public bool ControlRequest(PaymentRequestViewModel prvm)
        {
            string json = JsonConvert.SerializeObject(prvm);

            byte[] data = Encoding.UTF8.GetBytes(json);
            byte[] result;
            using (SHA512 sha512 = new SHA512Managed())
            {
                result = sha512.ComputeHash(data);
            }
            return prvm.Signature.Equals(string.Join(".", result));
        }

        public async Task AddRequest(PaymentRequestViewModel prvm)
        {
            var payment = new Payment
            {
                Amount = prvm.Amount,
                OriginalKey = prvm.Id,
                Signature = prvm.Signature,
                ReturnUrl = prvm.ReturnUrl,
                OriginalUserId = prvm.UserId,
                OriginalUserName = prvm.UserName
            };


            payment.PaymentDetails.Add(new PaymentDetail
            {
                Date = DateTime.Now,
                State = State.NewRequest,
                PaymentId = payment.Id
            });
            _db.Payments.Add(payment);


            await _db.SaveChangesAsync();
        }

        public async Task ChangeStatus(int id, State state)
        {
            _db.PaymentDetails.Add(new PaymentDetail
            {
                PaymentId = id,
                State = state,
                Date = DateTime.Now
            });

            await _db.SaveChangesAsync();
        }
    }
}
