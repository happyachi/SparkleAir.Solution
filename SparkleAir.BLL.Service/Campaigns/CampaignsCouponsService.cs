using SparkleAir.IDAL.IRepository.Campaigns;
using SparkleAir.Infa.Dto.Campaigns;
using SparkleAir.Infa.Entity.Campaigns;
using SparkleAir.Infa.Utility.Helper.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;

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
            string status = CamapignsTimeHelper.DetermineStatus(dto.DateStart, dto.DateEnd);

            CampaignsCouponEntity entity = new CampaignsCouponEntity(
             
              dto.CampaignId,
              dto.Name,
              dto.DateStart,
              dto.DateEnd,
              DateTime.Now,
              status,
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

            // 檢查 datastart 和 dataend 期間不能超過三個月
            if (!CamapignsTimeHelper.IsDateRangeValid(dto.DateStart, dto.DateEnd))
            {
                throw new ArgumentException("活動期間不能超過三個月。");
            }

            // 檢查 datastart 必須是現在的時間半小時以後
            if (!CamapignsTimeHelper.IsStartDateValid(dto.DateStart))
            {
                throw new ArgumentException("開始時間必須在目前時間的半小時後");
            }

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
