using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.Members
{
    public class MemberClassIndexVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ClassOrder { get; set; }

        public int MileageStart { get; set; }

        public int MileageEnd { get; set; }
    }
}
