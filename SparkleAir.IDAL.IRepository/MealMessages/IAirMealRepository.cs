//using SparkleAir.Infa.Dto.MealMessages;
using SparkleAir.Infa.Entity.MealMessageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.IDAL.IRepository.MealMessages
{
    public interface IAirMealRepository
    {
        //CRUD

        //頁面輸入完後要傳回資料庫
        //新增entity類別
        int Create(AirMealEntity entity);
        void Update(AirMealEntity entity);
        void Delete(int id);
        //沒有要搜尋 直接呈現
        List<AirMealEntity> Search();
        //給其他方法用(?
        AirMealEntity Get (int id);
    }
}
