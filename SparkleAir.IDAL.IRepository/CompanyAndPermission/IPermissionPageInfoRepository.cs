using SparkleAir.Infa.Entity.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.IDAL.IRepository.CompanyAndPermission
{
    public interface IPermissionPageInfoRepository
    {
        List<PermissionPageInfoEntity> Search();

        void Create(PermissionPageInfoEntity entity);

        PermissionPageInfoEntity Get(int id);

        void Update(PermissionPageInfoEntity entity);

        void Delete(int id);
    }
}
