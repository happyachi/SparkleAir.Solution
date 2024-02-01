using SparkleAir.Infa.Entity.TaxFree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.IDAL.IRepository.TaxFree
{
    public interface ITFOrderRepository
    {
        List<TFOrderlistsEntity> Get();
        List<TFOrderlistsEntity> Search(TFOrderlistsEntity entity);
        void Update(TFOrderlistsEntity entity);

        int Create(TFOrderlistsEntity entity);

        void Delete(int id);

        TFOrderlistsEntity Getid(int id);
    }
}
