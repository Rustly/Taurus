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
        ///     The name of this region.
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

        /// <summary>
        ///     Tries to get a region by name.
        /// </summary>
        /// <param name="name">The name of the region to look for.</param>
        /// <param name="result">The group to return.</param>
        /// <returns><see cref="true"/> if found. <see cref="false"/> if not.</returns>
        public static bool TryGet(string name, out Region result)
        {
            result = Entities.EntityHelper.TryGet<Region>(name);
            return result != null;
        }

        /// <summary>
        ///     Tries to get a region by ID.
        /// </summary>
        /// <param name="uid">The ID of the region to look for.</param>
        /// <param name="result">The region to return.</param>
        /// <returns><see cref="true"/> if found. <see cref="false"/> if not.</returns>
        public static bool TryGet(Guid uid, out Region result)
        {
            result = Entities.EntityHelper.TryGet<Region>(uid);
            return result != null;
        }
    }
}
