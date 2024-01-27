using SparkleAir.IDAL.IRepository.Campaigns;
using SparkleAir.Infa.Dto.Campaigns;
using SparkleAir.Infa.Entity.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SparkleAir.BLL.Service.Campaigns
{
    public class CampaignsCouponsService
    {
        private readonly ICampaignsCouponsRepository _repo;
        public CampaignsCouponsService(ICampaignsCouponsRepository repo)
        {
            _repo = repo;
        }

        public int Create(CampaignsCouponDto dto)
        {
            CampaignsCouponEntity entity = new CampaignsCouponEntity(
             
              dto.CampaignId,
              dto.Name,
              dto.DateStart,
              dto.DateEnd,
              DateTime.Now,
              dto.Status,
              dto.DiscountQuantity,
              dto.DiscountValue,
              dto.AvailableQuantity,
              dto.MinimumOrderValue,
              dto.MaximumDiscountAmount,
              dto.Code,
              dto.DisplayDescription,
              dto.MemberCriteria,
              dto.AirFlightsCriteria,
              dto.Campaign
              //dto.Id
                );

            _repo.Create(entity);
            return entity.Id;
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public CampaignsCouponDto Get(int id)
        {
            CampaignsCouponEntity entity = _repo.Get(id);
            CampaignsCouponDto dto = new CampaignsCouponDto
            {
                Id = id,
                CampaignId = entity.CampaignId,
                Name = entity.Name,
                DateCreated = entity.DateCreated,
                DateStart = entity.DateStart,
                DateEnd = entity.DateEnd,
                Status = entity.Status,
                DiscountQuantity = entity.DiscountQuantity,
                DiscountValue = entity.DiscountValue,
                AvailableQuantity = entity.AvailableQuantity,
                MinimumOrderValue = entity.MinimumOrderValue,
                MaximumDiscountAmount = entity.MaximumDiscountAmount,
                Code = entity.Code,
                DisplayDescription = entity.DisplayDescription,
                MemberCriteria = entity.MemberCriteria,
                AirFlightsCriteria = entity.AirFlightsCriteria,
                Campaign = entity.Campaign
            };
            return dto;
        }

        public List<CampaignsCouponDto> GetAll()
        {
            List<CampaignsCouponEntity> entity = _repo.GetAll();

            List<CampaignsCouponDto> dto = entity.Select(c => new CampaignsCouponDto
            {
                Id = c.Id,
                Name = c.Name,
                CampaignId = c.CampaignId,
                DateStart = c.DateStart,
                DateEnd = c.DateEnd,
                DateCreated = c.DateCreated,
                Status = c.Status,
                DiscountQuantity = c.DiscountQuantity,
                DiscountValue = c.DiscountValue,
                AvailableQuantity = c.AvailableQuantity,
                MinimumOrderValue = c.MinimumOrderValue,
                MaximumDiscountAmount = c.MaximumDiscountAmount,
                Code = c.Code,
                DisplayDescription = c.DisplayDescription,
                MemberCriteria = c.MemberCriteria,
                AirFlightsCriteria = c.AirFlightsCriteria,
                Campaign = c.Campaign
            }).ToList();

            return dto;
        }

        public void Update(CampaignsCouponDto dto)
        {
            CampaignsCouponEntity entity = new CampaignsCouponEntity
            (
              dto.CampaignId,
              dto.Name,
              dto.DateStart,
              dto.DateEnd,
              dto.DateCreated,
              dto.Status,
              dto.DiscountQuantity,
              dto.DiscountValue,
              dto.AvailableQuantity,
              dto.MinimumOrderValue,
              dto.MaximumDiscountAmount,
              dto.Code,
              dto.DisplayDescription,
              dto.MemberCriteria,
              dto.AirFlightsCriteria,
              dto.Campaign,
              dto.Id
            );

            _repo.Update(entity);
        }
    }
}
