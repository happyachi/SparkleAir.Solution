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
    public class PermissionPageInfoEFRepository : IPermissionPageInfoRepository
    {
        private AppDbContext _db = new AppDbContext();

        public void Create(PermissionPageInfoEntity entity)
        {
            var permissionPageInfo = new PermissionPageInfo
            {
                PageNumber = entity.PageNumber,
                PageName = entity.PageName,
                PageDescription = entity.PageDescription
            };

            _db.PermissionPageInfos.Add(permissionPageInfo);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var page = _db.PermissionPageInfos.Find(id);
            _db.PermissionPageInfos.Remove(page);
            _db.SaveChanges();
        }

        public PermissionPageInfoEntity Get(int id)
        {
            var page = _db.PermissionPageInfos.Find(id);
            var entity = new PermissionPageInfoEntity
            {
                Id = page.Id,
                PageNumber = page.PageNumber,
                PageName = page.PageName,
                PageDescription = page.PageDescription
            };
            return entity;
        }

        public List<PermissionPageInfoEntity> Search()
        {
            var entities = _db.PermissionPageInfos
                .AsNoTracking()
                .Select(p => new PermissionPageInfoEntity
                {
                    Id = p.Id,
                    PageNumber = p.PageNumber,
                    PageName = p.PageName,
                    PageDescription = p.PageDescription
                })
                .ToList();

            return entities;
        }

        public void Update(PermissionPageInfoEntity entity)
        {
            var page = _db.PermissionPageInfos.Find(entity.Id);

            if(entity.PageName != null) page.PageName = entity.PageName;
            if (entity.PageNumber != null) page.PageNumber = entity.PageNumber;
            if (entity.PageDescription != null) page.PageDescription = entity.PageDescription;

            _db.SaveChanges();
        }
    }
}
