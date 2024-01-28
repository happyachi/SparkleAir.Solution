﻿using SparkleAir.Infa.Criteria.CompanyAndPermission;
using SparkleAir.Infa.Entity.CompanyAndPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.IDAL.IRepository.CompanyAndPermission
{
    public interface ICompanyStaffRepository
    {
        List<CompanyStaffEntity> Search();

        void Create(CompanyStaffEntity entity);

        CompanyStaffEntity Get(CompanyStaffGetCriteria criteria);

        void Update(CompanyStaffEntity entity);

        void Delete(int id);
    }
}