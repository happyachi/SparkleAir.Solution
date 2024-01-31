using SparkleAir.IDAL.IRepository.MealMessages;
using SparkleAir.Infa.EFModel.EFModels;
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
        private AppDbContext db=new AppDbContext();
        public int Create(MessageEntity entity)
        {
            Message message = new Message
            {
                Id = entity.Id,
                MessageBoxId = entity.MessageBoxId,
                SendTime = entity.SendTime,
                MessageContent = entity.MessageContent,
                MemberId = entity.MemberId,
                CompanyStaffId = entity.CompanyStaffId,
                IsReaded = entity.IsReaded,
                ReadedTime = entity.ReadedTime

            };
            db.Messages.Add(message);
            db.SaveChanges();
            return message.Id;
        }

        //todo 一次顯示幾筆/升冪or降冪
        public List<MessageEntity> GetByBoxId(int messageBoxId)
        {
            List<MessageEntity> data=db.Messages.AsNoTracking()
                .Where(x=>x.MessageBoxId==messageBoxId).OrderBy(x=>x.SendTime).Select(x=>new MessageEntity
                {
                    Id = x.Id,
                    MessageBoxId = x.MessageBoxId,
                    SendTime = x.SendTime,
                    MessageContent = x.MessageContent,
                    MemberId = x.MemberId,
                    CompanyStaffId = x.CompanyStaffId,
                    IsReaded = x.IsReaded,
                    ReadedTime = x.ReadedTime
                }).ToList();
            return data;
        }
        //todo 在對話框中搜尋對話內容
        public List<MessageEntity> SearchByContent(string content)
        {
            List<MessageEntity> data=db.Messages.AsNoTracking()
                .Where(x=>x.MessageContent.Contains(content))
                .OrderBy(x=>x.Id).Select(x => new MessageEntity
                {
                    Id = x.Id,
                    MessageBoxId = x.MessageBoxId,
                    SendTime = x.SendTime,
                    MessageContent = x.MessageContent,
                    MemberId = x.MemberId,
                    CompanyStaffId = x.CompanyStaffId,
                    IsReaded = x.IsReaded,
                    ReadedTime = x.ReadedTime
                }).ToList();
            return data;
        }
        //todo 時間range(精確到年/月/日/時)
        public List<MessageEntity> SearchByTime(string time)
        {
            throw new NotImplementedException();
        }
    }
}
