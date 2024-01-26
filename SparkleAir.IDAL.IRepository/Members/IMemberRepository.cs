using SparkleAir.Infa.Criteria.Members;
using SparkleAir.Infa.Dto.Members;
using SparkleAir.Infa.Entity.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.IDAL.IRepository.Members
{
	public interface IMemberRepository
	{
		List<MemberEntity> GetAll();

        MemberEntity Get (MemberGetCriteria criteria);
    }
}
