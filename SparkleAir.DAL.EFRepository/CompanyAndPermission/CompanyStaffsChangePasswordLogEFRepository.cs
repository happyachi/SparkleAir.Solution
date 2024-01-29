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
    public class CompanyStaffsChangePasswordLogEFRepository : ICompanyStaffsChangePasswordLogRepository
    {
        private AppDbContext _db = new AppDbContext();
        public List<CompanyStaffsChangePasswordLogEntity> Search()
        {
            var entities = _db.CompanyStaffsChangePasswordLogs
                .Include(c=>c.CompanyStaff)
                .AsNoTracking()
                .Select(c => new CompanyStaffsChangePasswordLogEntity
                {
                    Id = c.Id,
                    CompanyStaffId = c.CompanyStaffId,
                    CompanyStaffName = c.CompanyStaff.FirstName + " " + c.CompanyStaff.LastName,
                    UpdateTime = c.UpdateTime
                }).ToList();
            return entities;
        }
    }
}
