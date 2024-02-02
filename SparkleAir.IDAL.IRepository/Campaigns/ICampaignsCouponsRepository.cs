using SparkleAir.Infa.Criteria.AirFlights;
using SparkleAir.Infa.Criteria.Campaigns;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using SparkleAir.Infa.Entity.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.IDAL.IRepository.Campaigns
{
    public interface ICampaignsCouponsRepository
    {
        //取全部
        List<CampaignsCouponEntity> GetAll();

        //取得一筆
        CampaignsCouponEntity Get(int id);

        //新增
        int Create(CampaignsCouponEntity model);

        //刪除
        void Delete(int id);

        //更新
        void Update(CampaignsCouponEntity model);

        List<CampaignsCouponEntity> Search(CampaignsCouponSearchCriteria entity);
    }
}
