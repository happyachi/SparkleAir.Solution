using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.Criteria.CompanyAndPermission;
using SparkleAir.Infa.Dto.CompanyAndPermission;
using SparkleAir.Infa.Entity.CompanyAndPermission;
using SparkleAir.Infa.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace SparkleAir.BLL.Service.CompanyAndPermission
{
    public class CompanyStaffService
    {
        private readonly ICompanyStaffRepository _repo;
        public CompanyStaffService(ICompanyStaffRepository repo)
        {
            _repo = repo;
        }

        public List<CompanyStaffDto> Search()
        {
            var eneities = _repo.Search();
            var dtos = eneities.Select(c=> new CompanyStaffDto
            {
                Id = c.Id,
                Account = c.Account,
                Password = c.Password,
                FirstName = c.FirstName,
                LastName = c.LastName,
                CompanyJobId = c.CompanyJobId,
                CompanyDepartmentName = c.CompanyDepartmentName,
                JobTitle = c.JobTitle,
                Status = c.Status,
                RegistrationTime = c.RegistrationTime
            }).ToList();

            return dtos;
        }

        public void Create(CompanyStaffDto dto)
        {
            var account = CreateAccount(DateTime.Now);
            var salt = HashHelper.GetSalt(); // 取得salt
            var hashPassword = HashHelper.ToSHA256(account, salt); // 密碼加密

            var entity = new CompanyStaffEntity
            {
                Account = account,
                Password = hashPassword,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                CompanyJobId = dto.CompanyJobId,
                Status = "正常",
                RegistrationTime = DateTime.Now
            };

            _repo.Create(entity);
        }

        private string CreateAccount(DateTime dateTime)
        {
            string account = "";
            string accountYearAndMonth = "s"+  dateTime.ToString("yyyyMM");

            string leastAccount = _repo.GetLeastAccount(accountYearAndMonth);

            if (leastAccount == null)
            {
                account = accountYearAndMonth + "001";
            }
            else
            {
                var leastAccountInt = int.Parse(leastAccount.Substring(1,9));
                account = "s"+(leastAccountInt + 1);
            }
            return account;
        }

        public CompanyStaffDto Get(CompanyStaffGetCriteria criteria)
        {
            
            var entity = _repo.Get(criteria);

            var dto = new CompanyStaffDto
            {
                Id = entity.Id,
                Account = entity.Account,
                Password = entity.Password,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                CompanyJobId = entity.CompanyJobId,
                CompanyDepartmentName = entity.CompanyDepartmentName,
                JobTitle = entity.JobTitle,
                Status = entity.Status,
                RegistrationTime = entity.RegistrationTime
            }; 
            
            return dto;
        }
        

        public void Update(CompanyStaffDto dto)
        {
            var entity = new CompanyStaffEntity
            {
                Id = dto.Id,
                Account = dto.Account,
                Password = dto.Password,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                CompanyJobId = dto.CompanyJobId,
                CompanyDepartmentName = dto.CompanyDepartmentName,
                JobTitle = dto.JobTitle,
                Status = dto.Status,
                RegistrationTime = dto.RegistrationTime
            };
            _repo.Update(entity);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
