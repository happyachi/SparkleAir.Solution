using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.Basics
{
    public class CountryIndexVm
    {
        public int Id { get; set; }

        public string ChineseName { get; set; }

        public string EnglishName { get; set; }
    }
}
