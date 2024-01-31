using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SparkleAir.Infa.Entity.Members;

namespace SparkleAir.IDAL.IRepository.Members
{
    public interface IMemberClassRepository
    {
        List<MemberClassEntity> Search();

        void Create(MemberClassEntity entity);

        MemberClassEntity Get(int id);

        void Update(MemberClassEntity entity);

        void Delete(int id);
    }
}
