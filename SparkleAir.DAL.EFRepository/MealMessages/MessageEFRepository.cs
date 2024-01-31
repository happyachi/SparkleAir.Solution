using SparkleAir.IDAL.IRepository.MealMessages;
using SparkleAir.Infa.Entity.MealMessageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.MealMessages
{
    public class MessageEFRepository : IMessageRepository
    {
        public int Create(MessageEntity message)
        {
            throw new NotImplementedException();
        }

        public List<MessageEntity> GetByBoxId(int messageBodId)
        {
            throw new NotImplementedException();
        }

        public List<MessageEntity> SearchByContent(string content)
        {
            throw new NotImplementedException();
        }

        public List<MessageEntity> SearchByTime(string time)
        {
            throw new NotImplementedException();
        }
    }
}
