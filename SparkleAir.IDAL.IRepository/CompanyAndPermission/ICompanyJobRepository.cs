using SparkleAir.Infa.Entity.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.IDAL.IRepository.CompanyAndPermission
{
    public interface ICompanyJobRepository
    {
        List<CompanyJobEntity> Search();

        void Create(CompanyJobEntity entity);

        CompanyJobEntity Get(int id);

        void Update(CompanyJobEntity entity);

        void Delete(int id);
    }
}
