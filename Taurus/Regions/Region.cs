using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taurus.Flags;

namespace Taurus.Regions
{
    public class Region : IRegion
    {
        public Guid Id { get; internal set; }

        /// <summary>
        ///     Name of this region.
        /// </summary>
        public string Name { get; internal set; }

        public Vector2f Pos1 { get; internal set; }

        public Vector2f Pos2 { get; internal set; }

        public Guid OwnerId { get; internal set; }

        public IReadOnlyCollection<Guid> IdsWithAccess { get; internal set; }

        public IReadOnlyCollection<Buff> Buffs { get; internal set; }

        public IReadOnlyCollection<RegionFlags> Flags { get; internal set; }

        internal Region()
        {
            // DB!
        }
    }
}
