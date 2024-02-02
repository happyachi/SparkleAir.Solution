using SparkleAir.IDAL.IRepository.TaxFree;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.TaxFree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SparkleAir.DAL.EFRepository.TaxFree
{
    public class TFReseveEFRepository : ITFReserve
    {
        int ITFReserve.Create(TFReservesEntity entity)
        {
            var db = new AppDbContext();
            var tfModel = new TFReserve();

            tfModel.Id = entity.Id;
            tfModel.MemberId = entity.MemberId;
            tfModel.Discount = entity.Discount;
            tfModel.TotalPrice = entity.TotalPrice;
            tfModel.TransferPaymentId = entity.TransferPaymentId;

            db.TFReserves.Add(tfModel);
            db.SaveChanges();
            return entity.Id;
        }

        void ITFReserve.Delete(int id)
        {
            var db = new AppDbContext();
            var tfModel = db.TFReserves.Find(id);
            db.TFReserves.Remove(tfModel);
            db.SaveChanges();
        }

        List<TFReservesEntity> ITFReserve.Get()
        {
            var db = new AppDbContext();
            var getlist = db.TFReserves.AsNoTracking()
                                         .Include(x => x.Member) 
                                         .Select(x => new TFReservesEntity {
                                             Id = x.Id,
                                             MemberId = x.MemberId,
                                             MemberChineseFirstName = x.Member.ChineseFirstName,
                                             MemberChineseLastName = x.Member.ChineseLastName,
                                             MemberEnglishFirstName = x.Member.EnglishFirstName,
                                             MemberEnglishLastName = x.Member.EnglishLastName,
                                             MemberPhone = x.Member.Phone,
                                             MemberEmail = x.Member.Email,
                                             MemberPassportNumber = x.Member.PassportNumber,
                                             Discount = x.Discount,
                                             TotalPrice = x.TotalPrice,
                                             TransferPaymentId = x.TransferPaymentId
                                         })
                                         .ToList();
            return getlist;
        }

        TFReservesEntity ITFReserve.Getid(int id)
        {
            var db = new AppDbContext();
            var get = db.TFReserves.Find(id);
            TFReservesEntity getlist = new TFReservesEntity()
            {
                Id = get.Id,
                MemberId = get.MemberId,
                Discount = get.Discount,
                TotalPrice = get.TotalPrice,
                TransferPaymentId = get.TransferPaymentId
            };
            return getlist;
        }

        List<TFReservesEntity> ITFReserve.Search(TFReservesEntity entity)
        {
            var db = new AppDbContext();
            List<TFReservesEntity> getlist = db.TFReserves.AsNoTracking()
                                                 .Include(x => x.Member)
                                                 .Where(x => x.MemberId == entity.MemberId)
                                                 .Select(x => new TFReservesEntity {
                                                     Id = x.Id,
                                                     MemberId = x.MemberId,
                                                     MemberChineseFirstName = x.Member.ChineseFirstName,
                                                     MemberChineseLastName = x.Member.ChineseLastName,
                                                     MemberEnglishFirstName = x.Member.EnglishFirstName,
                                                     MemberEnglishLastName = x.Member.EnglishLastName,
                                                     MemberPhone = x.Member.Phone,
                                                     MemberEmail = x.Member.Email,
                                                     MemberPassportNumber = x.Member.PassportNumber,
                                                     Discount = x.Discount,
                                                     TotalPrice = x.TotalPrice,
                                                     TransferPaymentId = x.TransferPaymentId
                                                 })
                                                 .ToList();
            return getlist;
        }

        void ITFReserve.Update(TFReservesEntity entity)
        {
            var db = new AppDbContext();
            db.TFReserves.Find(entity.Id);

            var tfModel = db.TFReserves.Find(entity.Id);
            tfModel.Id = entity.Id;
            tfModel.MemberId = entity.MemberId;
            tfModel.Discount = entity.Discount;
            tfModel.TotalPrice = entity.TotalPrice;
            tfModel.TransferPaymentId = entity.TransferPaymentId;

            db.SaveChanges();
        }
    }
}
