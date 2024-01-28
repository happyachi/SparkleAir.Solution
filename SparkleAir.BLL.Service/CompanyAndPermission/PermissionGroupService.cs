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
    public class PermissionGroupService
    {
        private readonly IPermissionGroupRepository _repo;

        public PermissionGroupService(IPermissionGroupRepository repo)
        {
            _repo = repo;
        }

        public List<PermissionGroupDto> Search()
        {
            var eneities = _repo.Search();
            var dtos = eneities.Select(p => new PermissionGroupDto
            {
                Id = p.Id,
                Name = p.Name,
                Ddescribe = p.Ddescribe,
                Criteria = p.Criteria
            }).ToList();

            return dtos;
        }

        public void Create(PermissionGroupDto dto)
        {
            var entity = new PermissionGroupEntity
            {
                Name = dto.Name,
                Ddescribe = dto.Ddescribe,
                Criteria = dto.Criteria
            };
            _repo.Create(entity);
        }

        public PermissionGroupDto Get(int id)
        {
            var entity = _repo.Get(id);
            var dto = new PermissionGroupDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Ddescribe = entity.Ddescribe,
                Criteria = entity.Criteria
            };
            return dto;
        }

        public void Update(PermissionGroupDto dto)
        {
            var entity = new PermissionGroupEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Ddescribe = dto.Ddescribe,
                Criteria = dto.Criteria
            };
            _repo.Update(entity);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
