﻿using SparkleAir.IDAL.IRepository.Campaigns;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.Campaigns;
using SparkleAir.Infa.Utility.Exts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Xml.Linq;
using SparkleAir.Infa.Criteria.Campaigns;

namespace SparkleAir.DAL.EFRepository.Campaigns
{
    public class CampaignsDiscountsEFRepository : ICampaignsDiscountsRepository
    {
        private AppDbContext db = new AppDbContext();
        private Func<CampaignsDiscount, CampaignsDiscountEntity> func = d => d.ToEntity();
        public int Create(CampaignsDiscountEntity entity)
        {
            CampaignsDiscount discount = new CampaignsDiscount()
            {
                Id = entity.Id,
                Name = entity.Name,
                CampaignId = entity.CampaignId,
                DateStart = entity.DateStart,
                DateEnd = entity.DateEnd,
                DateCreated = entity.DateCreated,
                Status = entity.Status,
                DiscountValue = entity.DiscountValue,
                Value = entity.Value,
                BundleSKUs = entity.BundleSKUs,
                MemberCriteria = entity.MemberCriteria,
                TFItemsCriteria = entity.TFItemsCriteria
            };

            db.CampaignsDiscounts.Add(discount);
            db.SaveChanges();

            return entity.Id;
        }

        public void Delete(int id)
        {
            var discount = db.CampaignsDiscounts.Find(id);
            db.CampaignsDiscounts.Remove(discount);
            db.SaveChanges();
        }

        public CampaignsDiscountEntity Get(int id)
        {
            var get = db.CampaignsDiscounts.Find(id).ToEntity();
            return get;
        }

        public List<CampaignsDiscountEntity> GetAll()
        {
            var discount = db.CampaignsDiscounts.AsNoTracking()
                             .Include(d => d.Campaign)
                             .OrderBy(d => d.DateStart)
                             .Select(func).ToList();

            return discount;
        }

        public List<CampaignsDiscountEntity> Search(CampaignsDiscountSearchCriteria entity)
        {
            var query = db.CampaignsDiscounts.AsNoTracking()
                             .Include(c => c.Campaign)
                             .OrderBy(c => c.DateCreated)
                             .ToList()
                             .Select(func);

            if (!string.IsNullOrEmpty(entity.Name))
            {
                query = query.Where(e => e.Name.Contains(entity.Name));
            }
            return query.ToList();
        }

        public void Update(CampaignsDiscountEntity entity)
        {
            var discount = db.CampaignsDiscounts.Find(entity.Id);
            if (discount != null)
            {
                discount.Id = entity.Id;
                discount.Name = entity.Name;
                discount.CampaignId = entity.CampaignId;
                discount.DateStart = entity.DateStart;
                discount.DateEnd = entity.DateEnd;
                discount.DateCreated = entity.DateCreated;
                discount.Status = entity.Status;
                discount.Status = entity.Status;
                discount.DiscountValue = entity.DiscountValue;
                discount.Value = entity.Value;
                discount.BundleSKUs = entity.BundleSKUs;
                discount.MemberCriteria = entity.MemberCriteria;
                discount.TFItemsCriteria = entity.TFItemsCriteria;
                //discount.Campaign = entity.Campaign;
            };
            db.SaveChanges();
        }
    }
}
