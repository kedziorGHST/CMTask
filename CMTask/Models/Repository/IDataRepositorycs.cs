using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMTask.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(Guid id);
        void Post(TEntity entity);
        void Put(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
