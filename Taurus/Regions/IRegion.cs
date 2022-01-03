namespace Taurus.Regions
{
    public interface IRegion : Entities.IEntity
    { 
        /// <summary>
        ///     Top left position of the region.
        /// </summary>
        public Vector2f Pos1 { get; }

        /// <summary>
        ///     Bottom right position of the region.
        /// </summary>
        public Vector2f Pos2 { get; }

        /// <summary>
        ///     ID of the regions' owner.
        /// </summary>
        public Guid OwnerId { get; }

        /// <summary>
        ///     All ID's with access to this region, including groups & users.
        /// </summary>
        public IReadOnlyCollection<Guid> IdsWithAccess { get; }

        /// <summary>
        ///     Buffs added to all users who enter this region.
        /// </summary>
        public IReadOnlyCollection<Buff> Buffs { get; }

        /// <summary>
        ///     Flags for this region (Kill, PvP, etc.)
        /// </summary>
        public IReadOnlyCollection<Flags.RegionFlags> Flags { get; }
    }
}
