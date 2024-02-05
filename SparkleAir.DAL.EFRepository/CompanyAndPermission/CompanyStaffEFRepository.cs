using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.Criteria.CompanyAndPermission;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.CompanyAndPermission;
using static SparkleAir.Infa.Utility.Helper.CompanyAndPermission.CompanyFunc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.CompanyAndPermission
{
    public class CompanyStaffEFRepository : ICompanyStaffRepository
    {
        private AppDbContext _db;
        public CompanyStaffEFRepository()
        {
            _db = new AppDbContext();
        }

        public void Create(CompanyStaffEntity entity)
        {
            var staff = new CompanyStaff
            {
                Account = entity.Account,
                Password = entity.Password,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                CompanyJobId = (int)entity.CompanyJobId,
                Status = entity.Status,
                RegistrationTime = entity.RegistrationTime
            };
            _db.CompanyStaffs.Add(staff);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var staff = _db.CompanyStaffs.Find(id);
            _db.CompanyStaffs.Remove(staff);
            _db.SaveChanges();
        }

        public CompanyStaffEntity Get(CompanyStaffGetCriteria criteria)
        {
            var staff = _db.CompanyStaffs;
            var query = new CompanyStaff();

            if (criteria.Id != null)
            {
                query = staff.Find(criteria.Id);
            }
            else
            {
                query = staff.FirstOrDefault(m => m.Account == criteria.Account);
            }

            if (query == null) return null;

            var entity = new CompanyStaffEntity
            {
                Id = query.Id,
                Account = query.Account,
                Password = query.Password,
                FirstName = query.FirstName,
                LastName = query.LastName,
                CompanyJobId = query.CompanyJobId,
                CompanyDepartmentName = query.CompanyJob.CompanyDepartment.Name,
                JobTitle = query.CompanyJob.JobTitle,
                Status = query.Status,
                RegistrationTime = query.RegistrationTime,
                RoleGroupName = query.PermissionGroupsAddStaffs.Select(m => m.PermissionGroup.Name).ToList(),
                RoleGroupId = query.PermissionGroupsAddStaffs.Select(m => m.PermissionGroup.Id).ToList()
            };

            return entity;
        }

        public List<CompanyStaffEntity> Search()
        {
            var entity = _db.CompanyStaffs
                .Include(c => c.CompanyJob)
                .Include(c => c.CompanyJob.CompanyDepartment)
                .AsNoTracking()
                .Select(c => new CompanyStaffEntity
                {
                    Id = c.Id,
                    Account = c.Account,
                    Password = c.Password,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    CompanyJobId = c.CompanyJobId,
                    CompanyDepartmentName = c.CompanyJob.CompanyDepartment.Name,
                    JobTitle = c.CompanyJob.JobTitle,
                    Status = c.Status,
                    RegistrationTime = c.RegistrationTime
                })
                .ToList();

            return entity;
        }

        public List<CompanyStaffEntity> SearchByJobId(int jobId)
        {
            var entity = _db.CompanyStaffs
                .Include(c => c.CompanyJob)
                .Include(c => c.CompanyJob.CompanyDepartment)
                .AsNoTracking()
                .Where(c => c.CompanyJobId == jobId)
                .Select(c => new CompanyStaffEntity
                {
                    Id = c.Id,
                    Account = c.Account,
                    Password = c.Password,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    CompanyJobId = c.CompanyJobId,
                    CompanyDepartmentName = c.CompanyJob.CompanyDepartment.Name,
                    JobTitle = c.CompanyJob.JobTitle,
                    Status = c.Status,
                    RegistrationTime = c.RegistrationTime
                })
                .ToList();

            return entity;
        }

        public string GetLeastAccount(string yearAndMonth)
        {
            var account = _db.CompanyStaffs
                .AsNoTracking()
                .Where(c => c.Account.Contains(yearAndMonth))
                .OrderByDescending(c => c.Account)
                .FirstOrDefault();
            if (account == null) return null;
            return account.Account;
        }

        public void Update(CompanyStaffEntity entity)
        {
            var staff = _db.CompanyStaffs.Find(entity.Id);

            if (entity.Password != null) staff.Password = entity.Password;
            if (entity.FirstName != null) staff.FirstName = entity.FirstName;
            if (entity.LastName != null) staff.LastName = entity.LastName;
            if (entity.CompanyJobId != 0) staff.CompanyJobId = (int)entity.CompanyJobId;
            if (entity.Status != null) staff.Status = entity.Status;
            if (entity.RegistrationTime != new DateTime(1,1,1)) staff.RegistrationTime = entity.RegistrationTime;

            _db.SaveChanges();
        }
    }
}
