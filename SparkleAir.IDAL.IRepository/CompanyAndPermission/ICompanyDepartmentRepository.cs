using SparkleAir.Infa.Entity.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.IDAL.IRepository.CompanyAndPermission
{
    public interface ICompanyDepartmentRepository
    {
        List<CompanyDepartmentEntity> Search ();

        void Create(CompanyDepartmentEntity department);

        CompanyDepartmentEntity Get(int id);

        void Update(CompanyDepartmentEntity department);

        void Delete(int id);
    }
}
