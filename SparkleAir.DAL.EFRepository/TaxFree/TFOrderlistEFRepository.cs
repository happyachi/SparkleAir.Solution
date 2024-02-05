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
    public class TFOrderlistEFRepository : ITFOrderRepository
    {
        int ITFOrderRepository.Create(TFOrderlistsEntity entity)
        {
            var db = new AppDbContext();
            var tfModel = new TFOrderlist();

            tfModel.Id = entity.Id;
            tfModel.MemberId = entity.MemberId;
            tfModel.TFItemsId = entity.TFItemsId;
            tfModel.Quantity = entity.Quantity;
            tfModel.UnitPrice = entity.UnitPrice;

            db.TFOrderlists.Add(tfModel);
            db.SaveChanges();
            return entity.Id;
        }

        void ITFOrderRepository.Delete(int id)
        {
            var db = new AppDbContext();
            var tfModel = db.TFOrderlists.Find(id);
            db.TFOrderlists.Remove(tfModel);
            db.SaveChanges();
        }

        List<TFOrderlistsEntity> ITFOrderRepository.Get()
        {
            var db = new AppDbContext();
            var getlist = db.TFOrderlists.AsNoTracking()
                                         .Include(x => x.TFItem)
                                         .Include(x => x.Member)
                                         .Select(x => new TFOrderlistsEntity
                                         {
                                             Id = x.Id,
                                             MemberId = x.MemberId,
                                             MemberChineseFirstName = x.Member.ChineseFirstName,
                                             MemberChineseLastName = x.Member.ChineseLastName,
                                             MemberEnglishFirstName = x.Member.EnglishFirstName,
                                             MemberEnglishLastName = x.Member.EnglishLastName,
                                             MemberPhone = x.Member.Phone,
                                             MemberEmail = x.Member.Email,
                                             MemberPassportNumber = x.Member.PassportNumber,
                                             TFItemsId = x.TFItemsId,
                                             TFItemsSerialNumber = x.TFItem.SerialNumber,
                                             TFItemsImage = x.TFItem.Image,
                                             TFItemsName = x.TFItem.Name,
                                             TFItemsQuantity = x.TFItem.Quantity,
                                             TFItemsUnitPrice = x.TFItem.UnitPrice,
                                             Quantity = x.Quantity,
                                             UnitPrice = x.UnitPrice

                                         })
                                         .ToList();
            return getlist;


        }

        TFOrderlistsEntity ITFOrderRepository.Getid(int id)
        {
            var db = new AppDbContext();
            var get = db.TFOrderlists.Find(id);
            TFOrderlistsEntity getlist = new TFOrderlistsEntity()
            {
                Id = get.Id,
                MemberId = get.MemberId,
                MemberChineseFirstName = get.Member.ChineseFirstName,
                MemberChineseLastName = get.Member.ChineseLastName,
                MemberEnglishFirstName = get.Member.EnglishFirstName,
                MemberEnglishLastName = get.Member.EnglishLastName,
                MemberPhone = get.Member.Phone,
                MemberEmail = get.Member.Email,
                MemberPassportNumber = get.Member.PassportNumber,
                TFItemsId = get.TFItemsId,
                TFItemsSerialNumber = get.TFItem.SerialNumber,
                TFItemsImage = get.TFItem.Image,
                TFItemsName = get.TFItem.Name,
                TFItemsQuantity = get.TFItem.Quantity,
                TFItemsUnitPrice = get.TFItem.UnitPrice,
                Quantity = get.Quantity,
                UnitPrice = get.UnitPrice
            };
            return getlist;
        }

        List<TFOrderlistsEntity> ITFOrderRepository.Search(TFOrderlistsEntity entity)
        {
            var db = new AppDbContext();
            List<TFOrderlistsEntity> getlist = db.TFOrderlists.AsNoTracking()
                                                 .Include(x => x.TFItem)
                                                 .Include(x => x.Member)
                                                 .Where(x => x.MemberId == entity.MemberId)
                                                 .Select(x => new TFOrderlistsEntity
                                                 {
                                                     Id = x.Id,
                                                     MemberId = x.MemberId,
                                                     MemberChineseFirstName = x.Member.ChineseFirstName,
                                                     MemberChineseLastName = x.Member.ChineseLastName,
                                                     MemberEnglishFirstName = x.Member.EnglishFirstName,
                                                     MemberEnglishLastName = x.Member.EnglishLastName,
                                                     MemberPhone = x.Member.Phone,
                                                     MemberEmail = x.Member.Email,
                                                     MemberPassportNumber = x.Member.PassportNumber,
                                                     TFItemsId = x.TFItemsId,
                                                     TFItemsSerialNumber = x.TFItem.SerialNumber,
                                                     TFItemsImage = x.TFItem.Image,
                                                     TFItemsName = x.TFItem.Name,
                                                     TFItemsQuantity = x.TFItem.Quantity,
                                                     TFItemsUnitPrice = x.TFItem.UnitPrice,
                                                     Quantity = x.Quantity,
                                                     UnitPrice = x.UnitPrice
                                                 })
                                                 .ToList();
            return getlist;
        }

        void ITFOrderRepository.Update(TFOrderlistsEntity entity)
        {
            var db = new AppDbContext();
            db.TFOrderlists.Find(entity.Id);

            var tfModel = db.TFOrderlists.Find(entity.Id);
            tfModel.Id = entity.Id;
            tfModel.MemberId = entity.MemberId;
            tfModel.TFItemsId = entity.TFItemsId;
            tfModel.Quantity = entity.Quantity;
            tfModel.UnitPrice = entity.UnitPrice;

            db.SaveChanges();
        }
    }
}
