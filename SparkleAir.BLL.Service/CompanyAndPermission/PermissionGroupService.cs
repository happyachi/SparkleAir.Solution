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
        private readonly IPermissionSettingRepository _settingRepo;

        public PermissionGroupService(IPermissionGroupRepository repo, IPermissionSettingRepository settingRepo)
        {
            _repo = repo;
            _settingRepo = settingRepo;
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
                Criteria = entity.Criteria,
                PermissionSettingPageId = entity.PermissionSettingPageId,
                PermissionSettingPageName = entity.PermissionSettingPageName
            };
            return dto;
        }

        public void Update(PermissionGroupDto dto)
        {
            var permissionSettingId = dto.PermissionSettingPageIdString;
            var permissionSettingIdList = permissionSettingId.Split(',').Select(int.Parse).ToArray();

            var settingEntity = _settingRepo.Search(dto.Id);
            var settingPageIdList = settingEntity.Select(p=>p.PermissionPageInfoId).ToArray();

            var needCreateList = permissionSettingIdList.Except(settingPageIdList);
            needCreateList.ToList().Select(p => new PermissionSettingEntity
            {
                PermissionGroupsId = dto.Id,
                PermissionPageInfoId = p,
                ViewPermission = true,
                EditPermission = true,
                DeletePermission = true,
                CreatePermission = true
            }).ToList().ForEach(p => _settingRepo.Create(p));

            var neddDeleteList = settingPageIdList.Except(permissionSettingIdList);
            foreach (var pageId in neddDeleteList)
            {
                settingEntity.Where(s => s.PermissionPageInfoId == pageId).ToList()
                    .ForEach(s => _settingRepo.Delete(s.Id));
            }
                
            // PermissionGroup
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
