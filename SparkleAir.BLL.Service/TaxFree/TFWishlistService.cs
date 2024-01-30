using SparkleAir.IDAL.IRepository.TaxFree;
using SparkleAir.Infa.Dto.TaxFree;
using SparkleAir.Infa.Entity.TaxFree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.TaxFree
{
    public class TFWishlistService
    {
        private readonly ITFWishlist _repo;
        public TFWishlistService(ITFWishlist repo)
        {
            _repo = repo;
        }

        public List<TFWishlistDto> Get()
        {
            List<TFWishlistsEntity> result = _repo.Get();
            List<TFWishlistDto> list = result.Select(x => new TFWishlistDto
            {
                Id = x.Id,
                MemberId = x.MemberId,
                TFItemsId = x.TFItemsId,

            }).ToList();
            return list;
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public int Create(TFWishlistDto dto)
        {
            TFWishlistsEntity entity = new TFWishlistsEntity
            {
                Id = dto.Id,
                MemberId = dto.MemberId,
                TFItemsId = dto.TFItemsId,
            };
            return entity.Id;
        }

        public void Update(TFWishlistDto dto)
        {
            TFWishlistsEntity entity = new TFWishlistsEntity
            {
                Id = dto.Id,
                MemberId = dto.MemberId,
                TFItemsId = dto.TFItemsId
            };
            _repo.Update(entity);
        }

        public TFWishlistDto Getid(int id)
        {
            TFWishlistsEntity entity = _repo.Getid(id);
            TFWishlistDto dto = new TFWishlistDto
            {
                Id = entity.Id,
                MemberId = entity.MemberId,
                TFItemsId = entity.TFItemsId
            };
            return dto;
        }

    }
}
