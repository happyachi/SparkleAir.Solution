﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.CompanyAndPermission
{
    public class PermissionPageInfoIndexVm
    {
        public int Id { get; set; }

        public string PageNumber { get; set; }

        public string PageName { get; set; }

        public string PageDescription { get; set; }
    }
}
