using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.Databases
{
    public interface IDatabase<T>
    {
        public T Get(Guid id);

        public IEnumerable<T> GetWhere(Predicate<T> predicate);

        public bool Add(T entity);

        public bool Save(T entity);

        public bool Delete(Guid id);
    }
}
