using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.Databases
{
    public interface ICachedDatabase<TEntity, TIdentifier> : IEnumerable<TEntity>
    {
        public TEntity Get(TIdentifier id);

        public bool Save(TEntity entity);

        public bool Add(TEntity entity);

        public bool Delete(TIdentifier id);
    }
}
