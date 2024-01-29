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
    public class PermissionGroupsAddStaffService
    {
        private readonly IPermissionGroupsAddStaffRepository _repo;

        public PermissionGroupsAddStaffService(IPermissionGroupsAddStaffRepository repo)
        {
            _repo = repo;
        }

        public List<PermissionGroupsAddStaffDto> Search()
        {
            var eneities = _repo.Search();
            var dtos = eneities.Select(p => new PermissionGroupsAddStaffDto
            {
                Id = p.Id,
                PermissionGroupsId = p.PermissionGroupsId,
                PermissionGroupsName = p.PermissionGroupsName,
                CompanyStaffsId = p.CompanyStaffsId,
                CompanyStaffsName = p.CompanyStaffsName
            }).ToList();

            return dtos;
        }

        public void Create(PermissionGroupsAddStaffDto dto)
        {
            var entity = new PermissionGroupsAddStaffEntity
            {
                PermissionGroupsId = dto.PermissionGroupsId,
                PermissionGroupsName = dto.PermissionGroupsName,
                CompanyStaffsId = dto.CompanyStaffsId,
                CompanyStaffsName = dto.CompanyStaffsName
            };

            _repo.Create(entity);
        }

        public void Update(PermissionGroupsAddStaffDto dto) 
        {
            var entity = new PermissionGroupsAddStaffEntity
            {
                Id = dto.Id,
                PermissionGroupsId = dto.PermissionGroupsId,
                PermissionGroupsName = dto.PermissionGroupsName,
                CompanyStaffsId = dto.CompanyStaffsId,
                CompanyStaffsName = dto.CompanyStaffsName
            };
            _repo.Update(entity);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public PermissionGroupsAddStaffDto Get(int id)
        {
            var entity = _repo.Get(id);
            var dto = new PermissionGroupsAddStaffDto
            {
                Id = entity.Id,
                PermissionGroupsId = entity.PermissionGroupsId,
                PermissionGroupsName = entity.PermissionGroupsName,
                CompanyStaffsId = entity.CompanyStaffsId,
                CompanyStaffsName = entity.CompanyStaffsName
            };
            return dto;
        }
    }
}
