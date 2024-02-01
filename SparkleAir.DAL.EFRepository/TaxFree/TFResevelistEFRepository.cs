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
    public class TFResevelistEFRepository : ITFReservelist

    {
        int ITFReservelist.Create(TFReservelistsEntity entity)
        {
            var db = new AppDbContext();
            var tfModel = new TFReservelist();
            tfModel.Id = entity.Id;
            tfModel.TFItemsId = entity.TFItemsId;
            tfModel.Quantity = entity.Quantity;
            tfModel.UnitPrice = entity.UnitPrice;
            tfModel.TotalPrice = entity.TotalPrice;
            tfModel.TFReserveId = entity.TFReserveId;

            return entity.Id;

        }

        void ITFReservelist.Delete(int id)
        {
            var db = new AppDbContext();
            var tfModel = db.TFReservelists.Find(id);
            db.TFReservelists.Remove(tfModel);
            db.SaveChanges();
        }

        List<TFReservelistsEntity> ITFReservelist.Get()
        {
            var db = new AppDbContext();
            var getlist = db.TFReservelists.AsNoTracking()
                                            .Select(x => new TFReservelistsEntity { Id = x.Id, TFItemsId = x.TFItemsId, Quantity = x.Quantity, UnitPrice = x.UnitPrice, TotalPrice = x.TotalPrice, TFReserveId = x.TFReserveId })
                                            .ToList();
            return getlist;

        }

        TFReservelistsEntity ITFReservelist.Getid(int id)
        {
            var db = new AppDbContext();
            var get = db.TFReservelists.Find(id);
            TFReservelistsEntity getlist = new TFReservelistsEntity()
            {
                Id = get.Id,
                TFItemsId = get.TFItemsId,
                Quantity = get.Quantity,
                UnitPrice = get.UnitPrice,
                Discount=get.Discount,
                TFReserveId = get.TFReserveId,
                TotalPrice = get.TotalPrice
            };
            return getlist;
        }

        List<TFReservelistsEntity> ITFReservelist.Search(TFReservelistsEntity entity)
        { //todo
            var db = new AppDbContext();
            List<TFReservelistsEntity> getlist = db.TFReservelists.AsNoTracking()
                                            .Where(x => x.TFItemsId == entity.TFItemsId)
                                            .OrderBy(x => x.Id)
                                            .Select(x => new TFReservelistsEntity { Id = x.Id, TFItemsId = x.TFItemsId, Quantity = x.Quantity, UnitPrice = x.UnitPrice, TotalPrice = x.TotalPrice, TFReserveId = x.TFReserveId })
                                            .ToList();
            return getlist;
        }

        void ITFReservelist.Update(TFReservelistsEntity entity)
        {
            var db = new AppDbContext();
            db.TFReservelists.Find(entity.Id);

            var tfModel = db.TFReservelists.Find(entity.Id);
            tfModel.Id = entity.Id;
            tfModel.TFItemsId = entity.TFItemsId;
            tfModel.Quantity = entity.Quantity;
            tfModel.UnitPrice = entity.UnitPrice;
            tfModel.TotalPrice = entity.TotalPrice;
            tfModel.TFReserveId = entity.TFReserveId;
            db.SaveChanges();

        }
    }
}
