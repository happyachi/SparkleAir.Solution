using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.CompanyAndPermission
{
    public class PermissionSettingEFRepository : IPermissionSettingRepository
    {
        private AppDbContext _db = new AppDbContext();

        public void Create(PermissionSettingEntity entity)
        {
            var permissionSetting = new PermissionSetting
            {
                PermissionGroupsId = entity.PermissionGroupsId,
                PermissionPageInfoId = entity.PermissionPageInfoId,
                ViewPermission = entity.ViewPermission,
                EditPermission = entity.EditPermission,
                DeletePermission = entity.DeletePermission,
                CreatePermission = entity.CreatePermission
            };
            _db.PermissionSettings.Add(permissionSetting);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var permissionSetting = _db.PermissionSettings.Find(id);
            _db.PermissionSettings.Remove(permissionSetting);
            _db.SaveChanges();
        }

        public PermissionSettingEntity Get(int id)
        {
            var permissionSetting = _db.PermissionSettings.Find(id);
            var entity = new PermissionSettingEntity
            {
                Id = permissionSetting.Id,
                PermissionGroupsId = permissionSetting.PermissionGroupsId,
                PermissionGroupsName = permissionSetting.PermissionGroup.Name,
                PermissionPageInfoId = permissionSetting.PermissionPageInfoId,
                PermissionPageInfoName = permissionSetting.PermissionPageInfo.PageName,
                ViewPermission = permissionSetting.ViewPermission,
                EditPermission = permissionSetting.EditPermission,
                DeletePermission = permissionSetting.DeletePermission,
                CreatePermission = permissionSetting.CreatePermission
            };
            return entity;
        }

        public List<PermissionSettingEntity> Search()
        {
            var entities = _db.PermissionSettings
                .Include(x=>x.PermissionGroup)
                .Include(x=>x.PermissionPageInfo)
                .AsNoTracking()
                .Select(p => new PermissionSettingEntity
                {
                    Id = p.Id,
                    PermissionGroupsId = p.PermissionGroupsId,
                    PermissionGroupsName = p.PermissionGroup.Name,
                    PermissionPageInfoId = p.PermissionPageInfoId,
                    PermissionPageInfoName = p.PermissionPageInfo.PageName,
                    ViewPermission = p.ViewPermission,
                    EditPermission = p.EditPermission,
                    DeletePermission = p.DeletePermission,
                    CreatePermission = p.CreatePermission
                })
                .ToList();

            return entities;
        }

        public List<PermissionSettingEntity> Search(int groupId)
        {
            var entities = _db.PermissionSettings
                .Include(x => x.PermissionGroup)
                .Include(x => x.PermissionPageInfo)
                .AsNoTracking()
                .Where(p=> p.PermissionGroupsId == groupId)
                .Select(p => new PermissionSettingEntity
                {
                    Id = p.Id,
                    PermissionGroupsId = p.PermissionGroupsId,
                    PermissionGroupsName = p.PermissionGroup.Name,
                    PermissionPageInfoId = p.PermissionPageInfoId,
                    PermissionPageInfoName = p.PermissionPageInfo.PageName,
                    ViewPermission = p.ViewPermission,
                    EditPermission = p.EditPermission,
                    DeletePermission = p.DeletePermission,
                    CreatePermission = p.CreatePermission
                })
                .ToList();

            return entities;
        }

        public void Update(PermissionSettingEntity entity)
        {
            var permissionSetting = _db.PermissionSettings.Find(entity.Id);

            permissionSetting.DeletePermission = entity.DeletePermission;
            permissionSetting.EditPermission = entity.EditPermission;
            permissionSetting.CreatePermission = entity.CreatePermission;
            permissionSetting.ViewPermission = entity.ViewPermission;
            permissionSetting.PermissionGroupsId = entity.PermissionGroupsId;
            permissionSetting.PermissionPageInfoId = entity.PermissionPageInfoId;

            _db.SaveChanges();
        }

        public string[] GetAllowGroupIdsByPageName(string pageName)
        {
            var result = _db.PermissionSettings
                            .Include(x => x.PermissionGroup)
                            .Include(x => x.PermissionPageInfo)
                            .AsNoTracking()
                            .Where(x => x.PermissionPageInfo.PageNumber == pageName)
                            .Select(x => x.PermissionGroupsId.ToString())
                            .ToArray();

            return result;
        }

    }
}
