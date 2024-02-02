using SparkleAir.Infa.Entity.MealMessageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.IDAL.IRepository.MealMessages
{
    public interface IMessageBoxRepository
    {
        int Create(MessageBoxEntity entity);
        void Update(MessageBoxEntity entity);
        void Delete(int id);
        List<MessageBoxEntity> Search(bool isProcessed);

        //todo動態顯示包含該串數字的id
        MessageBoxEntity GetById(int id);


    }
}
