using SparkleAir.Infa.Entity.MealMessageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.IDAL.IRepository.MealMessages
{
    public interface IMessageRepository
    {
        int Create(MessageEntity message);
        //void Update(MessageEntity message);
        List<MessageEntity> SearchByContent(string content);

        //也可能放DateTime
        List<MessageEntity> SearchByTime(string time);
        List<MessageEntity> GetByBoxId(int messageBodId);
    }
}
