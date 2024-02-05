using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.CompanyAndPermission
{
    public class PermissionGroupsAddStaffEFRepository : IPermissionGroupsAddStaffRepository
    {
        private AppDbContext _db = new AppDbContext();

        public void Create(PermissionGroupsAddStaffEntity entity)
        {
            var permissionGroupsAddStaff = new PermissionGroupsAddStaff
            {
                PermissionGroupsId = entity.PermissionGroupsId,
                CompanyStaffsId = entity.CompanyStaffsId
            };

            _db.PermissionGroupsAddStaffs.Add(permissionGroupsAddStaff);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var permissionGroupsAddStaff = _db.PermissionGroupsAddStaffs.Find(id);
            _db.PermissionGroupsAddStaffs.Remove(permissionGroupsAddStaff);
            _db.SaveChanges();
        }

        public PermissionGroupsAddStaffEntity Get(int id)
        {
            var permissionGroupsAddStaff = _db.PermissionGroupsAddStaffs.Find(id);

            var entity = new PermissionGroupsAddStaffEntity
            {
                Id = permissionGroupsAddStaff.Id,
                PermissionGroupsId = permissionGroupsAddStaff.PermissionGroupsId,
                PermissionGroupsName = permissionGroupsAddStaff.PermissionGroup.Name,
                CompanyStaffsId = permissionGroupsAddStaff.CompanyStaffsId,
                CompanyStaffsName = permissionGroupsAddStaff.CompanyStaff.FirstName + " " + permissionGroupsAddStaff.CompanyStaff.LastName
            };
            return entity;
        }

        public List<PermissionGroupsAddStaffEntity> Search()
        {
            var entities = _db.PermissionGroupsAddStaffs
                .Include(x => x.PermissionGroup)
                .Include(x => x.CompanyStaff)
                .Select(x => new PermissionGroupsAddStaffEntity
                {
                    Id = x.Id,
                    PermissionGroupsId = x.PermissionGroupsId,
                    PermissionGroupsName = x.PermissionGroup.Name,
                    CompanyStaffsId = x.CompanyStaffsId,
                    CompanyStaffsName = x.CompanyStaff.FirstName + " " + x.CompanyStaff.LastName
                }).ToList();

            return entities;
        }

        public List<PermissionGroupsAddStaffEntity> SearchByGroupId(int groupId)
        {
            var entities = _db.PermissionGroupsAddStaffs
                .Include(x => x.PermissionGroup)
                .Include(x => x.CompanyStaff)
                .Where(x => x.PermissionGroupsId == groupId)
                .Select(x => new PermissionGroupsAddStaffEntity
                {
                    Id = x.Id,
                    PermissionGroupsId = x.PermissionGroupsId,
                    PermissionGroupsName = x.PermissionGroup.Name,
                    CompanyStaffsId = x.CompanyStaffsId,
                    CompanyStaffsName = x.CompanyStaff.FirstName + " " + x.CompanyStaff.LastName
                }).ToList();

            return entities;
        }

        public List<PermissionGroupsAddStaffEntity> SearchByStaffId(int staffId)
        {
            var entities = _db.PermissionGroupsAddStaffs
                .Include(x => x.PermissionGroup)
                .Include(x => x.CompanyStaff)
                .Where(x => x.CompanyStaffsId == staffId)
                .Select(x => new PermissionGroupsAddStaffEntity
                {
                    Id = x.Id,
                    PermissionGroupsId = x.PermissionGroupsId,
                    PermissionGroupsName = x.PermissionGroup.Name,
                    CompanyStaffsId = x.CompanyStaffsId,
                    CompanyStaffsName = x.CompanyStaff.FirstName + " " + x.CompanyStaff.LastName
                }).ToList();

            return entities;
        }

        public void Update(PermissionGroupsAddStaffEntity entity)
        {
            var permissionGroupsAddStaff = _db.PermissionGroupsAddStaffs.Find(entity.Id);

            if (entity.PermissionGroupsId != 0) permissionGroupsAddStaff.PermissionGroupsId = entity.PermissionGroupsId;
            if (entity.CompanyStaffsId != 0) permissionGroupsAddStaff.CompanyStaffsId = entity.CompanyStaffsId;

            _db.SaveChanges();
        }
    }
}
