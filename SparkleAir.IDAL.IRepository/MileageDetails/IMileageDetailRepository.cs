using SparkleAir.Infa.Entity.Luggage;
using SparkleAir.Infa.Entity.MileageDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.IDAL.IRepository.MileageDetails
{
    public interface IMileageDetailRepository
    {
        //取全部
        List<MileageDetailEntity> GetAll();

        //新增
        int Create(MileageDetailEntity model);

        //取得一筆
        MileageDetailEntity Get(int id);

        //更新
        void Update(MileageDetailEntity model);

        //刪除
        void Delete(int id);

        int Getfinalmile(int memberid);
    }
}
