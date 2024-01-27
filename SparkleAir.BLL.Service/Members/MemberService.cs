using SparkleAir.IDAL.IRepository.Members;
using SparkleAir.Infa.Criteria.Members;
using SparkleAir.Infa.Dto.Members;
using SparkleAir.Infa.Entity.Members;
using SparkleAir.Infa.Utility.Exts.Dtos;
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

		public List<MemberDto> Search(MemberSearchCriteria criteria)
		{
			var list = _repo.Search(criteria)
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

		public void Update(MemberDto dto)
		{
			var entity = dto.DotToEntity();

			_repo.Update(entity);
        }
	}
}
