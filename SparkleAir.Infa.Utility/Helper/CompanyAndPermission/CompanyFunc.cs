using SparkleAir.Infa.Criteria.CompanyAndPermission;
using SparkleAir.Infa.Criteria.Members;
using SparkleAir.Infa.EFModel.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Utility.Helper.CompanyAndPermission
{
    public class CompanyFunc
    {
        public static Func<CompanyStaff, CompanyStaffGetCriteria, bool> CompanyStaffGetFunc = (staff, criteria) =>
        {
            if (staff.Account.Contains(criteria.Account)) return true;

            return false;
        };
    }
}
