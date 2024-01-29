﻿using SparkleAir.IDAL.IRepository.TaxFree;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.TaxFree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;

namespace SparkleAir.DAL.EFRepository.TaxFree
{
    public class TFItemEFRepository : ITFRepository
    {
        public int Create(TFItemEntity entity)
        {
            var db = new AppDbContext();

            var tfModel = new TFItem();
            tfModel.Id = entity.Id;
            tfModel.Name = entity.Name;
            tfModel.SerialNumber = entity.SerialNumber;
            tfModel.Image = entity.Image;
            tfModel.Quantity = entity.Quantity;
            tfModel.UnitPrice = entity.UnitPrice;
            tfModel.Description = entity.Description;
            tfModel.IsPublished = entity.IsPublished;
            tfModel.TFCategoriesId = entity.TFCategoriesId;

            db.TFItems.Add(tfModel);
            db.SaveChanges();
            return entity.Id;
        }

        public void Update(TFItemEntity entity)
        {
            var db = new AppDbContext();

            var tfModel = new TFItem();
            tfModel.Id = entity.Id;
            tfModel.Name = entity.Name;
            tfModel.SerialNumber = entity.SerialNumber;
            tfModel.Image = entity.Image;
            tfModel.Quantity = entity.Quantity;
            tfModel.UnitPrice = entity.UnitPrice;
            tfModel.Description = entity.Description;
            tfModel.IsPublished = entity.IsPublished;
            tfModel.TFCategoriesId = entity.TFCategoriesId;

            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var db = new AppDbContext();
            var tfModel = db.TFItems.Find(id);
            db.TFItems.Remove(tfModel);
            db.SaveChanges();

        }

        public List<TFItemEntity> Search(string name)
        {
            var db = new AppDbContext();
            List<TFItemEntity> itemList = db.TFItems.AsNoTracking()
                                        .Where(x => x.Name.Contains(name))
                                        .OrderBy(x => x.Id)
                                        .Select(x => new TFItemEntity { Id = x.Id, Name = x.Name, SerialNumber = x.SerialNumber, Image = x.Image, Quantity = x.Quantity, UnitPrice = x.UnitPrice, Description = x.Description, IsPublished = x.IsPublished })
                                        .ToList();

            return itemList;
        }

        public List<TFItemEntity> Get()
        {
            var db = new AppDbContext();
            var itemget = db.TFItems.AsNoTracking()
                                    .Include(x => x.TFCategoriesId)
                                    .Select(x => new TFItemEntity { Id = x.Id, Name = x.Name, SerialNumber = x.SerialNumber, Image = x.Image, Quantity = x.Quantity, UnitPrice = x.UnitPrice, Description = x.Description, IsPublished = x.IsPublished })
                                    .ToList();
            return itemget;
        }



        public List<TFItemEntity> Search(TFItemEntity entity)
        {
            throw new NotImplementedException();
        }

        //public void Delete(int id)
        //{
        //    var ItemGet = db.TFItems.Find(id);
        //    TFItemEntity item = new TFItemEntity
        //    {
        //        Id = ItemGet.Id,
        //        Name = ItemGet.Name,
        //        SerialNumber = ItemGet.SerialNumber,
        //        Image = ItemGet.Image,
        //        Quantity = ItemGet.Quantity,
        //        UnitPrice = ItemGet.UnitPrice,
        //        Description = ItemGet.Description,
        //        IsPublished = ItemGet.IsPublished

        //    };
        //    return item;

        //}
    }
}


