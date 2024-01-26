using SparkleAir.IDAL.IRepository.Members;
using SparkleAir.Infa.Criteria.Members;
using SparkleAir.Infa.Dto.Members;
using SparkleAir.Infa.Entity.Members;
using SparkleAir.Infa.Utility.Exts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.Members
{
	public class MemberService
	{
		private readonly IMemberRepository _repo;

        public MemberService(IMemberRepository repo)
        {
			_repo = repo;
		}

		public List<MemberDto> GetAll()
		{
			var list = _repo.GetAll()
				.Select(m => m.EntityToDto())
				.ToList();

			return list;
		}


		public MemberDto Get(MemberGetCriteria criteria) 
		{
			var member = _repo.Get(criteria);

            var dto = member.EntityToDto();

            return dto;

        }
	}
}
