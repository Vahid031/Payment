﻿using System.Linq;
using System.Collections.Generic;
using DatabaseContext.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace Services.General.PaymentService
{

    public class PaymentService : IPaymentService
    {
        private readonly IAppDbContext db;

        public PaymentService(IAppDbContext db)
        {
            this.db = db;
        }

        //public IEnumerable<ListMemberViewModel> GetAll(ListMemberViewModel list, ref Paging pg)
        //{
        //    var query = uow.Get<Person>().Select(m => new { Person = m }).Paging(list, ref pg);

        //    return query.AsEnumerable().Select(Result => new ListMemberViewModel()
        //    {
        //        Person = Result.Person
        //    });
        //}

        //public CreateMemberViewModel Get(int Id)
        //{
        //    var a = Get(m => m.Id == Id).Include(m => m.Person);

        //    return a.AsEnumerable().Select(Result => new CreateMemberViewModel() { Member = Result }).FirstOrDefault();
        //}

        //public IEnumerable<Tree> Permission(int id, bool isDenied)
        //{
        //    var member = uow.Get<MemberPermission>()
        //                    .AsQueryable()
        //                    .Where(m => id == (m.MemberId.HasValue ? m.MemberId.Value : 0))
        //                    .Where(m => m.IsDenied == isDenied)
        //                    .ToList();

        //    return uow.Get<Permission>().AsEnumerable().Select(Result => new Tree()
        //    {
        //        id = Result.Id.Value,
        //        parentId = Result.ParentId,
        //        @checked = member.Any(m => m.PermissionId == Result.Id),
        //        disabled = false,
        //        icon = Result.Icon,
        //        order = Result.Order,
        //        title = Result.Title
        //    });
        //}

        //public async Task<Response> Save(CreateMemberViewModel model)
        //{
        //    Response result;

        //    try
        //    {
        //        if (model.Member.Id == null)
        //        {
        //            Update(model.Member);

        //            result = userService.Succeed(Alert.SuccessUpdate);
        //        }
        //        else
        //        {
        //            Insert(model.Member);
        //            result = userService.Succeed(Alert.SuccessInsert);
        //        }

        //        await uow.CommitAsync();
        //    }
        //    catch (Exception)
        //    {
        //        result = userService.Failed(Alert.ErrorInInsertOrUpdate);
        //    }

        //    return result;
        //}

        //public async Task<Response> Remove(int id)
        //{
        //    Response result;

        //    try
        //    {
        //        //uow.Entry<Permission>(Find(id)).Collection(m => m.RolePermissions).Load();

        //        uow.Set<Person>().Remove(
        //            uow.Get<Person>(m => m.Id == id).First()
        //            );
        //        result = userService.Succeed(Alert.SuccessDelete);

        //        await uow.CommitAsync();
        //    }
        //    catch (Exception)
        //    {
        //        result = userService.Failed(Alert.ErrorInDelete);
        //    }

        //    return result;
        //}
    }
}
