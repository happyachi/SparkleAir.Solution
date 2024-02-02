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
    public class TFWishlistEFRepository : ITFWishlist
    {
        int ITFWishlist.Create(TFWishlistsEntity entity)
        {
            var db = new AppDbContext();
            var tfModel = new TFWishlist();
            tfModel.Id = entity.Id;
            tfModel.MemberId = entity.MemberId;
            tfModel.TFItemsId = entity.TFItemsId;

            return entity.Id;
        }

        void ITFWishlist.Delete(int id)
        {
            var db = new AppDbContext();
            var tfModel = db.TFWishlists.Find(id);
            db.TFWishlists.Remove(tfModel);
            db.SaveChanges();
        }

        List<TFWishlistsEntity> ITFWishlist.Get()
        {
            var db = new AppDbContext();
            var getlist = db.TFWishlists.AsNoTracking()
                                        .Include(x => x.TFItem)
                                        .Include(x => x.Member)
                                        .OrderBy(x => x.Id)
                                        .Select(x => new TFWishlistsEntity
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
                                            TFItemsName = x.TFItem.Name,
                                            TFItemsSerialNumber = x.TFItem.SerialNumber,
                                            TFItemsImage = x.TFItem.Image,
                                            TFItemsQuantity = x.TFItem.Quantity,
                                            TFItemsUnitPrice = x.TFItem.UnitPrice,
                                            TFItemsId = x.TFItemsId
                                        })
                                        .ToList();

            return getlist;
        }

        TFWishlistsEntity ITFWishlist.Getid(int id)
        {
            var db = new AppDbContext();
            var get = db.TFWishlists.Find(id);
            TFWishlistsEntity getlist = new TFWishlistsEntity()
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
                TFItemsName = get.TFItem.Name,
                TFItemsSerialNumber = get.TFItem.SerialNumber,
                TFItemsImage = get.TFItem.Image,
                TFItemsQuantity = get.TFItem.Quantity,
                TFItemsUnitPrice = get.TFItem.UnitPrice,
                TFItemsId = get.TFItemsId
            };
            return getlist;

        }

        List<TFWishlistsEntity> ITFWishlist.Search(TFWishlistsEntity entity)
        {
            var db = new AppDbContext();
            List<TFWishlistsEntity> getlist = db.TFWishlists.AsNoTracking()
                                                            .Include(x => x.TFItem)
                                                            .Include(x => x.Member)
                                                            .Where(x => x.MemberId == entity.MemberId)
                                                            .Select(x => new TFWishlistsEntity
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
                                                                TFItemsName = x.TFItem.Name,
                                                                TFItemsSerialNumber = x.TFItem.SerialNumber,
                                                                TFItemsImage = x.TFItem.Image,
                                                                TFItemsQuantity = x.TFItem.Quantity,
                                                                TFItemsUnitPrice = x.TFItem.UnitPrice,
                                                                TFItemsId = x.TFItemsId
                                                            })
                                                            .ToList();

            return getlist;
        }

        void ITFWishlist.Update(TFWishlistsEntity entity)
        {
            var db = new AppDbContext();
            db.TFWishlists.Find(entity.Id);

            var tfModel = db.TFWishlists.Find(entity.Id);
            tfModel.Id = entity.Id;
            tfModel.MemberId = entity.MemberId;
            tfModel.TFItemsId = entity.TFItemsId;


            db.SaveChanges();
        }
    }
}
