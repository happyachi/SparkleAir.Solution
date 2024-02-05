using SparkleAir.IDAL.IRepository.Campaigns;
using SparkleAir.Infa.Criteria.Campaigns;
using SparkleAir.Infa.Dto.Campaigns;
using SparkleAir.Infa.Entity.Campaigns;
using SparkleAir.Infa.Utility.Helper.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.Campaigns
{
    public class CampaignsDiscountsService
    {
        private readonly ICampaignsDiscountsRepository _repo;
        public CampaignsDiscountsService(ICampaignsDiscountsRepository repo)
        {
            _repo = repo;
        }

        public int Create(CampaignsDiscountDto dto)
        {
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

            // 檢查 MaximumDiscountAmount 必須小於等於 MinimumOrderValue
            if (!PriceHelper.IsMaximumDiscountValid(dto.DiscountValue, (int?)dto.Value))
            {
                throw new ArgumentException("最高折扣金額不得大於最低消費金額。");
            }

            if (dto.DateEnd < dto.DateStart)
            {
                throw new ArgumentException("結束時間不能早於開始時間。");
            }

            if (dto.CampaignId == 6)
            {
                if (dto.DiscountValue >= 99 || dto.DiscountValue < 10)
                {
                    throw new ArgumentException("折數必須介於10-99之間。");
                }
            }

            string status = CamapignsTimeHelper.DetermineStatus(dto.DateStart, dto.DateEnd);

            CampaignsDiscountEntity entity = new CampaignsDiscountEntity(
              
              dto.CampaignId,
              dto.Name,
              DateTime.Now,
              dto.DateStart,
              dto.DateEnd,
              status,
              dto.DiscountValue,
              dto.Value,
              dto.BundleSKUs,
              dto.MemberCriteria,
              dto.TFItemsCriteria,
              dto.Type
                //dto.Id
                );

            _repo.Create(entity);
            return entity.Id;

            
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public CampaignsDiscountDto Get(int id)
        {

            CampaignsDiscountEntity entity = _repo.Get(id);
            CampaignsDiscountDto dto = new CampaignsDiscountDto
            {
                Id = id,
                CampaignId = entity.CampaignId,
                Name = entity.Name,
                DateCreated = entity.DateCreated,
                DateStart = entity.DateStart,
                DateEnd = entity.DateEnd,
                Status = entity.Status,
                DiscountValue = entity.DiscountValue,
                Value = entity.Value,
                BundleSKUs = entity.BundleSKUs,
                MemberCriteria = entity.MemberCriteria,
                TFItemsCriteria = entity.TFItemsCriteria,
                Type = entity.Type,
                Campaign = entity.Campaign
            };
            return dto;
        }

        public List<CampaignsDiscountDto> GetAll()
        {
            List<CampaignsDiscountEntity> entity = _repo.GetAll();

            List<CampaignsDiscountDto> dto = entity.Select(d => new CampaignsDiscountDto
            {
                Id = d.Id,
                CampaignId = d.CampaignId,
                Name = d.Name,
                DateCreated = d.DateCreated,
                DateStart = d.DateStart,
                DateEnd = d.DateEnd,
                Status = CamapignsTimeHelper.DetermineStatus(d.DateStart, d.DateEnd),
                DiscountValue = d.DiscountValue,
                Value = d.Value,
                BundleSKUs = d.BundleSKUs,
                MemberCriteria = d.MemberCriteria,
                TFItemsCriteria = d.TFItemsCriteria,
                Type = d.Type
                //Campaign = d.Campaign
            }).ToList();

            return dto;

        }
        public void Update(CampaignsDiscountDto dto)
        {
            string status = CamapignsTimeHelper.DetermineStatus(dto.DateStart, dto.DateEnd);

            CampaignsDiscountEntity entity = new CampaignsDiscountEntity
            (
              dto.CampaignId,
              dto.Name,
              dto.DateCreated,
              dto.DateStart,
              dto.DateEnd,
              status,
              dto.DiscountValue,
              dto.Value,
              dto.BundleSKUs,
              dto.MemberCriteria,
              dto.TFItemsCriteria,
              dto.Type,
              dto.Id
                );

            _repo.Update(entity);
        }

        public List<CampaignsDiscountDto> Search(CampaignsDiscountSearchCriteria dto)
        {

            var list = _repo.Search(dto);

            return list.Select(d => new CampaignsDiscountDto
            {
                Id = d.Id,
                CampaignId = d.CampaignId,
                Name = d.Name,
                DateCreated = d.DateCreated,
                DateStart = d.DateStart,
                DateEnd = d.DateEnd,
                Status = d.Status,
                DiscountValue = d.DiscountValue,
                Value = d.Value,
                BundleSKUs = d.BundleSKUs,
                MemberCriteria = d.MemberCriteria,
                TFItemsCriteria = d.TFItemsCriteria,
                Type = d.Type
            }).ToList();

        }
    }
}
