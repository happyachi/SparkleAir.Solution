using SparkleAir.IDAL.IRepository.Campaigns;
using SparkleAir.Infa.Dto.Campaigns;
using SparkleAir.Infa.Entity.Campaigns;
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
            CampaignsDiscountEntity entity = new CampaignsDiscountEntity(
              //dto.Id,
              //dto.CampaignId,
              dto.Name,
               dto.DateCreated,
              dto.DateStart,
              dto.DateEnd,
              dto.Status,
              dto.DiscountValue,
              dto.Value,
              dto.BundleSKUs,
              dto.MemberCriteria,
              dto.TFItemsCriteria
              //dto.Campaign
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
                DateCreated = DateTime.Now,
                DateStart = entity.DateStart,
                DateEnd = entity.DateEnd,
                Status = entity.Status,
                DiscountValue = entity.DiscountValue,
                Value = entity.Value,
                BundleSKUs = entity.BundleSKUs,
                MemberCriteria = entity.MemberCriteria,
                TFItemsCriteria = entity.TFItemsCriteria,
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
                DateCreated = DateTime.Now,
                DateStart = d.DateStart,
                DateEnd = d.DateEnd,
                Status = d.Status,
                DiscountValue = d.DiscountValue,
                Value = d.Value,
                BundleSKUs = d.BundleSKUs,
                MemberCriteria = d.MemberCriteria,
                TFItemsCriteria = d.TFItemsCriteria,
                Campaign = d.Campaign
            }).ToList();

            return dto;
        }
        public void Update(CampaignsDiscountDto dto)
        {
            CampaignsDiscountEntity entity = new CampaignsDiscountEntity
            (
              //dto.Id,
              //dto.CampaignId,
              dto.Name,
              dto.DateCreated,
              dto.DateStart,
              dto.DateEnd,
              dto.Status,
              dto.DiscountValue,
              dto.Value,
              dto.BundleSKUs,
              dto.MemberCriteria,
              dto.TFItemsCriteria
              //dto.Campaign
                );

            _repo.Update(entity);
        }
    }
}
