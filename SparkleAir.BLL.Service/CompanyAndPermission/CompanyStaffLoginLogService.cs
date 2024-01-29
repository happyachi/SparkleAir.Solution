using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.Dto.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.CompanyAndPermission
{
    public class CompanyStaffLoginLogService
    {
        private readonly ICompanyStaffLoginLogRepository _repo;

        public CompanyStaffLoginLogService(ICompanyStaffLoginLogRepository repo)
        {
            _repo = repo;
        }

        public List<CompanyStaffLoginLogDto> Search()
        {
            var entity = _repo.Search();
            var dtos = entity.Select(e => new CompanyStaffLoginLogDto
            {
                Id = e.Id,
                CompanyStaffId = e.CompanyStaffId,
                CompanyStaffName = e.CompanyStaffName,
                LoginTime = e.LoginTime,
                LogoutTime = e.LogoutTime,
                IPAddress = e.IPAddress,
                LoginStatus = e.LoginStatus
            }).ToList();

            return dtos;
        }
    }
}
