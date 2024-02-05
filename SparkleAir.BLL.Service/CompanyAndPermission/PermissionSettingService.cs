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
    public class PermissionSettingService
    {
        private readonly IPermissionSettingRepository _repo;

        public PermissionSettingService(IPermissionSettingRepository repo)
        {
            _repo = repo;

        }

        public List<PermissionSettingDto> Search()
        {
            var eneities = _repo.Search();
            var dtos = eneities.Select(p => new PermissionSettingDto
            {
                Id = p.Id,
                PermissionGroupsId = p.PermissionGroupsId,
                PermissionGroupsName = p.PermissionGroupsName,
                PermissionPageInfoId = p.PermissionPageInfoId,
                PermissionPageInfoName = p.PermissionPageInfoName,
                ViewPermission = p.ViewPermission,
                EditPermission = p.EditPermission,
                DeletePermission = p.DeletePermission,
                CreatePermission = p.CreatePermission
            }).ToList();

            return dtos;
        }

        public void Create(PermissionSettingDto dto)
        {
            var entity = new PermissionSettingEntity
            {
                PermissionGroupsId = dto.PermissionGroupsId,
                PermissionGroupsName = dto.PermissionGroupsName,
                PermissionPageInfoId = dto.PermissionPageInfoId,
                PermissionPageInfoName = dto.PermissionPageInfoName,
                ViewPermission = dto.ViewPermission,
                EditPermission = dto.EditPermission,
                DeletePermission = dto.DeletePermission,
                CreatePermission = dto.CreatePermission
            };

            _repo.Create(entity);
        }

        public PermissionSettingDto Get(int id)
        {
            var entity = _repo.Get(id);
            var dto = new PermissionSettingDto
            {
                Id = entity.Id,
                PermissionGroupsId = entity.PermissionGroupsId,
                PermissionGroupsName = entity.PermissionGroupsName,
                PermissionPageInfoId = entity.PermissionPageInfoId,
                PermissionPageInfoName = entity.PermissionPageInfoName,
                ViewPermission = entity.ViewPermission,
                EditPermission = entity.EditPermission,
                DeletePermission = entity.DeletePermission,
                CreatePermission = entity.CreatePermission
            };
            return dto;
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public void Update(PermissionSettingDto dto)
        {
            var entity = new PermissionSettingEntity
            {
                Id = dto.Id,
                PermissionGroupsId = dto.PermissionGroupsId,
                PermissionGroupsName = dto.PermissionGroupsName,
                PermissionPageInfoId = dto.PermissionPageInfoId,
                PermissionPageInfoName = dto.PermissionPageInfoName,
                ViewPermission = dto.ViewPermission,
                EditPermission = dto.EditPermission,
                DeletePermission = dto.DeletePermission,
                CreatePermission = dto.CreatePermission
            };

            _repo.Update(entity);
        }

        public string[] GetAllowGroupIdsByPageName(string pageName)
        {
            var result = _repo.GetAllowGroupIdsByPageName(pageName);

            return result;
        }
    }
}
