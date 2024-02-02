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
    public class MessageBoxEFRepository : IMessageBoxRepository
    {
        private AppDbContext db=new AppDbContext();
        public int Create(MessageBoxEntity entity)
        {
            MessageBox messageBox = new MessageBox
            {
                Id = entity.Id,
                MemberId = entity.MemberId,
                IsProcessed = false,
                ProcessedTime = null
            };
            db.MessageBoxes.Add(messageBox);
            db.SaveChanges();
            return messageBox.Id;
        }

        public void Delete(int id)
        {
            var messageBox = db.MessageBoxes.Find(id);
            db.MessageBoxes.Remove(messageBox);
            db.SaveChanges();
        }

        public MessageBoxEntity GetById(int id)
        {
            var messageBoxData= db.MessageBoxes.Find(id);
            var messageBox = new MessageBoxEntity
            {
                Id = messageBoxData.Id,
                MemberId = messageBoxData.MemberId,
                IsProcessed = messageBoxData.IsProcessed,
                ProcessedTime = messageBoxData.ProcessedTime
            };
            return messageBox;
        }

        public List<MessageBoxEntity> Search(bool isProcessed)
        {
            List<MessageBoxEntity> data=db.MessageBoxes.AsNoTracking()
                .Where(x => x.IsProcessed)
                .OrderBy(x => x.MemberId)
                .Select(x=>new MessageBoxEntity { Id = x.Id, MemberId = x.MemberId, IsProcessed = x.IsProcessed,ProcessedTime=x.ProcessedTime }).ToList();
            return data;
        }

        public void Update(MessageBoxEntity entity)
        {
           var box=db.MessageBoxes.Find(entity.MemberId);
           box.IsProcessed = entity.IsProcessed;
           box.ProcessedTime = entity.ProcessedTime;

           db.SaveChanges();
        }
    }
}
