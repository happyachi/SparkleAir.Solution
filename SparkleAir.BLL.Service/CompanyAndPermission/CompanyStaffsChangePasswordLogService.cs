using SparkleAir.IDAL.IRepository.CompanyAndPermission;
using SparkleAir.Infa.Dto.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.CompanyAndPermission
{
    public class CompanyStaffsChangePasswordLogService
    {
        private readonly ICompanyStaffsChangePasswordLogRepository _repo;

        public CompanyStaffsChangePasswordLogService(ICompanyStaffsChangePasswordLogRepository repo)
        {
            _repo = repo;
        }

        public List<CompanyStaffsChangePasswordLogDto> Search()
        {
            var eneities = _repo.Search();
            var dtos = eneities.Select(e => new CompanyStaffsChangePasswordLogDto
            {
                Id = e.Id,
                CompanyStaffId = e.CompanyStaffId,
                CompanyStaffName = e.CompanyStaffName,
                UpdateTime = e.UpdateTime
            })
            .ToList();

            return dtos;
        }
    }
}
