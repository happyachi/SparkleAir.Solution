using SparkleAir.IDAL.IRepository.TaxFree;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.TaxFree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                        .Select(x => new TFWishlistsEntity { Id = x.Id, MemberId = x.MemberId, TFItemsId = x.TFItemsId })   
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
                TFItemsId = get.TFItemsId
            };
            return getlist;

        }

        List<TFWishlistsEntity> ITFWishlist.Search(TFWishlistsEntity entity)
        {
            var db = new AppDbContext();
            List<TFWishlistsEntity> getlist = db.TFWishlists.AsNoTracking()
                                                            .Where(x => x.MemberId == entity.MemberId)
                                                            .Select(x => new TFWishlistsEntity { Id = x.Id, MemberId = x.MemberId, TFItemsId = x.TFItemsId })
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
