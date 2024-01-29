using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.Dto.CompanyAndPermission;
using SparkleAir.Infa.Entity.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.CompanyAndPermission
{
    public class PermissionPageInfoService
    {
        private readonly IPermissionPageInfoRepository _repo;
        public PermissionPageInfoService(IPermissionPageInfoRepository repo)
        {
            _repo = repo;
        }

        public List<PermissionPageInfoDto> Search()
        {
            var eneities = _repo.Search();
            var dtos = eneities.Select(p => new PermissionPageInfoDto
            {
                Id = p.Id,
                PageNumber = p.PageNumber,
                PageName = p.PageName,
                PageDescription = p.PageDescription
            }).ToList();

            return dtos;
        }

        public void Create(PermissionPageInfoDto dto)
        {
            var entity = new PermissionPageInfoEntity
            {
                PageNumber = dto.PageNumber,
                PageName = dto.PageName,
                PageDescription = dto.PageDescription
            };

            _repo.Create(entity);
        }

        public PermissionPageInfoDto Get(int id)
        {
            var entity = _repo.Get(id);
            var dto = new PermissionPageInfoDto
            {
                Id = entity.Id,
                PageNumber = entity.PageNumber,
                PageName = entity.PageName,
                PageDescription = entity.PageDescription
            };
            return dto;
        }

        public void Update(PermissionPageInfoDto dto)
        {
            var entity = new PermissionPageInfoEntity
            {
                Id = dto.Id,
                PageNumber = dto.PageNumber,
                PageName = dto.PageName,
                PageDescription = dto.PageDescription
            };
            _repo.Update(entity);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
