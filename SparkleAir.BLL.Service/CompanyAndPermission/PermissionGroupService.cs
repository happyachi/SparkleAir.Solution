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
        private readonly ICompanyStaffRepository _staffRepo;
        private readonly IPermissionGroupsAddStaffRepository _groupsAddStaffRepo;

        public PermissionGroupService(
            IPermissionGroupRepository repo,
            IPermissionSettingRepository settingRepo, 
            ICompanyStaffRepository staffRepo, 
            IPermissionGroupsAddStaffRepository groupsAddStaffRepo)
        {
            _repo = repo;
            _settingRepo = settingRepo;
            _staffRepo = staffRepo;
            _groupsAddStaffRepo = groupsAddStaffRepo;
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
            // 人員篩選
            if (dto.Criteria != null)
            {
                var criteriaArry = dto.Criteria.Split(',');
                var jobIdList = new List<int>();
                foreach (var item in criteriaArry)
                {
                    item.Split('_');
                    jobIdList.Add(int.Parse(item.Split('_')[1]));
                }
                // 先找到所有符合的人員
                List<CompanyStaffEntity> staffEntity = new List<CompanyStaffEntity>();
                jobIdList.ForEach(jobId => staffEntity.AddRange(_staffRepo.SearchByJobId(jobId)));
                var staffIdList = staffEntity.Select(p => p.Id).ToArray();

                // 到權限表找出原本的人員Id
                var originalGroupAddStaffList = _groupsAddStaffRepo.SearchByGroupId(dto.Id);
                var originalStaffIdArray = originalGroupAddStaffList.Select(p => p.CompanyStaffsId).ToArray();

                // 找需要新增的
                var needCreateList = staffIdList.Except(originalStaffIdArray);
                needCreateList.ToList().Select(p => new PermissionGroupsAddStaffEntity
                {
                    PermissionGroupsId = dto.Id,
                    CompanyStaffsId = p
                }).ToList().ForEach(p => _groupsAddStaffRepo.Create(p));

                // 找需要刪除的
                var needDeleteList = originalStaffIdArray.Except(staffIdList);
                foreach (var staffId in needDeleteList)
                {
                    originalGroupAddStaffList
                        .Where(s => s.CompanyStaffsId == staffId)
                        .ToList()
                        .ForEach(s => _groupsAddStaffRepo.Delete(s.Id));
                }
            }
            else
            {
                // 先找到所有符合的人員，把全部刪除
                var originalGroupAddStaffList = _groupsAddStaffRepo.SearchByGroupId(dto.Id);
                originalGroupAddStaffList.ForEach(p => _groupsAddStaffRepo.Delete(p.Id));

            }

            // 頁面設定更新
            if (dto.PermissionSettingPageIdString != null)
            {
                var permissionSettingId = dto.PermissionSettingPageIdString;
                var permissionSettingIdList = permissionSettingId.Split(',').Select(int.Parse).ToArray();

                var settingEntity = _settingRepo.Search(dto.Id);
                var settingPageIdList = settingEntity.Select(p=>p.PermissionPageInfoId).ToArray();

                // 找需要新增的
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
                
                // 找需要刪除的
                var neddDeleteList = settingPageIdList.Except(permissionSettingIdList);
                foreach (var pageId in neddDeleteList)
                {
                    settingEntity
                        .Where(s => s.PermissionPageInfoId == pageId)
                        .ToList()
                        .ForEach(s => _settingRepo.Delete(s.Id));
                }
            }
            else
            {
                // 先找到所有符合的，把全部刪除
                var settingEntity = _settingRepo.Search(dto.Id);
                settingEntity.ToList().ForEach(s => _settingRepo.Delete(s.Id));
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
