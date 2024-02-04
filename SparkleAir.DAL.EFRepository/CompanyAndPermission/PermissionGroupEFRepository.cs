using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.CompanyAndPermission
{
    public class PermissionGroupEFRepository : IPermissionGroupRepository
    {
        private AppDbContext _db = new AppDbContext();

        public void Create(PermissionGroupEntity entity)
        {
            var permissionGroup = new PermissionGroup
            {
                Name = entity.Name,
                Ddescribe = entity.Ddescribe,
                Criteria = entity.Criteria
            };
            _db.PermissionGroups.Add(permissionGroup);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var permissionGroup = _db.PermissionGroups.Find(id);
            _db.PermissionGroups.Remove(permissionGroup);
            _db.SaveChanges();
        }

        public PermissionGroupEntity Get(int id)
        {
            var permissionGroup = _db.PermissionGroups.Find(id);
            var entity = new PermissionGroupEntity
            {
                Id = permissionGroup.Id,
                Name = permissionGroup.Name,
                Ddescribe = permissionGroup.Ddescribe,
                Criteria = permissionGroup.Criteria,
                PermissionSettingPageName = permissionGroup.PermissionSettings.Select(m => m.PermissionPageInfo.PageName).ToList(),
                PermissionSettingPageId = permissionGroup.PermissionSettings.Select(m => m.PermissionPageInfo.Id).ToList()
            };

            return entity;
        }

        public List<PermissionGroupEntity> Search()
        {
            var entities = _db.PermissionGroups
                .AsNoTracking()
                .Select(p => new PermissionGroupEntity
                {
                    Id = p.Id,
                    Name = p.Name,
                    Ddescribe = p.Ddescribe,
                    Criteria = p.Criteria
                })
                .ToList();

            return entities;
        }

        public void Update(PermissionGroupEntity entity)
        {
            var permissionGroup = _db.PermissionGroups.Find(entity.Id);

            if(entity.Name != null) permissionGroup.Name = entity.Name;
            if (entity.Ddescribe != null) permissionGroup.Ddescribe = entity.Ddescribe;
            permissionGroup.Criteria = entity.Criteria;

            _db.SaveChanges();
        }
    }
}
