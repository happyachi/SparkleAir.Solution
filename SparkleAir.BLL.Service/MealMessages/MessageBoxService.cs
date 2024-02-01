using SparkleAir.IDAL.IRepository.MealMessages;
using SparkleAir.Infa.Dto.MealMessages;
using SparkleAir.Infa.Entity.MealMessageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.MealMessages
{
    public class MessageBoxService
    {
        private readonly IMessageBoxRepository _repo;
        public MessageBoxService(IMessageBoxRepository repo)
        {
            _repo = repo;
        }

        public void GetOrCreateNewBox(MessageBoxDto dto)
        {
            MessageBoxEntity entity = new MessageBoxEntity
            {
                Id = dto.Id,
                MemberId = dto.MemberId,
                IsProcessed = dto.IsProcessed,
                ProcessedTime = dto.ProcessedTime
            };
            _repo.Create(entity);
        }

    }
}
