using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.CompanyAndPermission
{
    public class CompanyStaffLoginLogEFRepository : ICompanyStaffLoginLogRepository
    {
        private AppDbContext _db;
        public CompanyStaffLoginLogEFRepository()
        {
            _db = new AppDbContext();
        }

        public List<CompanyStaffLoginLogEntity> Search()
        {
            var entities = _db.CompanyStaffLoginLogs
                .Include(c => c.CompanyStaff)
                .AsNoTracking()
                .Select(c => new CompanyStaffLoginLogEntity
                {
                    Id = c.Id,
                    CompanyStaffId = c.CompanyStaffId,
                    CompanyStaffName = c.CompanyStaff.FirstName + " " + c.CompanyStaff.LastName,
                    LoginTime = c.Logintime,
                    LogoutTime = c.LogoutTime,
                    IPAddress = c.IPAddress,
                    LoginStatus = c.LoginStatus
                }).ToList();

            return entities;
        }
    }
}
