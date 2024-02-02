using SparkleAir.IDAL.IRepository.Campaigns;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SparkleAir.Infa.Utility.Exts.Models;
using System.Xml.Linq;
using SparkleAir.Infa.Criteria.AirFlights;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using SparkleAir.Infa.Criteria.Campaigns;

namespace SparkleAir.DAL.EFRepository.Campaigns
{
    public class CampaignsCouponsEFRepository : ICampaignsCouponsRepository
    {
        private AppDbContext db = new AppDbContext();
        private Func<CampaignsCoupon, CampaignsCouponEntity> func = c => c.ToEntity();

        public int Create(CampaignsCouponEntity entity)
        {
            CampaignsCoupon coupon = new CampaignsCoupon()
            {
                Id = entity.Id,
                Name = entity.Name,
                CampaignId = entity.CampaignId,
                DateStart= entity.DateStart,
                DateEnd=entity.DateEnd,
                DateCreated =entity.DateCreated,
                Status = entity.Status,
                DiscountQuantity = entity.DiscountQuantity,
                DiscountValue = entity.DiscountValue,
                AvailableQuantity = entity.AvailableQuantity,
                MinimumOrderValue = entity.MinimumOrderValue,
                MaximumDiscountAmount = entity.MaximumDiscountAmount,
                Code = entity.Code,
                DisplayDescription = entity.DisplayDescription,
                MemberCriteria = entity.MemberCriteria,
                AirFlightsCriteria = entity.AirFlightsCriteria
            };

            db.CampaignsCoupons.Add(coupon);
            db.SaveChanges();

            return entity.Id;
        }

        public void Delete(int id)
        {
            var coupon = db.CampaignsCoupons.Find(id);
            db.CampaignsCoupons.Remove(coupon);
            db.SaveChanges();
        }

        public CampaignsCouponEntity Get(int id)
        {
            var get = db.CampaignsCoupons.Find(id).ToEntity();
            return get;
        }

        public List<CampaignsCouponEntity> GetAll()
        {
            var coupons = db.CampaignsCoupons.AsNoTracking()
                             .Include(c => c.Campaign)
                             .OrderBy(c => c.DateCreated)
                             .Select(func)
                             .ToList();

            return coupons;
        }

        public void Update(CampaignsCouponEntity entity)
        {
            var coupon = db.CampaignsCoupons.Find(entity.Id);
            if (coupon != null)
            {
                coupon.Id = entity.Id;
                coupon.CampaignId = entity.CampaignId;
                coupon.Name = entity.Name;
                coupon.DateStart = entity.DateStart;
                coupon.DateEnd = entity.DateEnd;
                coupon.DateCreated = entity.DateCreated;
                coupon.Status = entity.Status;
                coupon.DiscountQuantity = entity.DiscountQuantity;
                coupon.DiscountValue = entity.DiscountValue;
                coupon.AvailableQuantity = entity.AvailableQuantity;
                coupon.MinimumOrderValue = entity.MinimumOrderValue;
                coupon.MaximumDiscountAmount = entity.MaximumDiscountAmount;
                coupon.Code = entity.Code;
                coupon.DisplayDescription = entity.DisplayDescription;
                coupon.MemberCriteria = entity.MemberCriteria;
                coupon.AirFlightsCriteria = entity.AirFlightsCriteria;
               
            };
            db.SaveChanges();
        }

        public List<CampaignsCouponEntity> Search(CampaignsCouponSearchCriteria entity)
        {
            var query = db.CampaignsCoupons.AsNoTracking()
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
    }

}
