using SparkleAir.IDAL.IRepository.TaxFree;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.TaxFree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using SparkleAir.Infa.Entity.Airports;
using System.Xml.Linq;

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
            db.TFItems.Find(entity.Id);

            var tfModel = db.TFItems.Find(entity.Id);
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
            var wishModel = db.TFWishlists.Where(x => x.TFItemsId == id);
            db.TFWishlists.RemoveRange(wishModel);
            db.TFItems.Remove(tfModel);
            db.SaveChanges();

        }

        //public void DeleteTFWishlist(int id)
        //{
        //    var db =new AppDbContext();
            
        //    db.SaveChanges();
        //}




        public List<TFItemEntity> Get()
        {
            var db = new AppDbContext();
            var itemget = db.TFItems.AsNoTracking()
                                    .Include(x => x.TFCategoriesId)
                                    .Select(x => new TFItemEntity
                                    {
                                        Id = x.Id,
                                        TFCategoriesName = x.TFCategory.Category,
                                        Name = x.Name,
                                        SerialNumber = x.SerialNumber,
                                        Image = x.Image,
                                        Quantity = x.Quantity,
                                        UnitPrice = x.UnitPrice,
                                        Description = x.Description,
                                        IsPublished = x.IsPublished,
                                        TFCategoriesId = x.TFCategoriesId
                                    })
                                    .ToList();
            return itemget;
        }



        public List<TFItemEntity> Search(TFItemEntity entity)
        {
            var db = new AppDbContext();
            List<TFItemEntity> itemList = db.TFItems.AsNoTracking()
                                        //.Where(x => x.Name.Contains(name))
                                        .Include(x => x.TFCategory)
                                        .OrderBy(x => x.Id)
                                        .Select(x => new TFItemEntity
                                        {
                                            Id = x.Id,
                                            TFCategoriesName = x.TFCategory.Category,
                                            Name = x.Name,
                                            SerialNumber = x.SerialNumber,
                                            Image = x.Image,
                                            Quantity = x.Quantity,
                                            UnitPrice = x.UnitPrice,
                                            Description = x.Description,
                                            IsPublished = x.IsPublished,
                                            TFCategoriesId = x.TFCategoriesId
                                        })
                                        .ToList();

            return itemList;
        }

        public TFItemEntity Getid(int id)
        {
            var db = new AppDbContext();
            var get = db.TFItems.Find(id);

            TFItemEntity getitem = new TFItemEntity()
            {
                Id = get.Id,
                TFCategoriesName = get.TFCategory.Category,
                Name = get.Name,
                SerialNumber = get.SerialNumber,
                Image = get.Image,
                Quantity = get.Quantity,
                UnitPrice = get.UnitPrice,
                Description = get.Description,
                IsPublished = get.IsPublished,
                TFCategoriesId = get.TFCategoriesId
            };

            return getitem;
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


