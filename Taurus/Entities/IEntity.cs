using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.Entities
{
    /// <summary>
    ///     A cacheable entity with a unique ID and name.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        ///     The entities ID.
        /// </summary>
        public Guid Id { get; }

        public string Name { get; }
    }
}
