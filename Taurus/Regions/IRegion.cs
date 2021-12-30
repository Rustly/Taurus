namespace Taurus.Regions
{
    public interface IRegion : Entities.IEntity
    {
        public string Name { get; set; }

        public Vector2f Pos1 { get; }

        public Vector2f Pos2 { get; }

        public Guid OwnerId { get; }

        public IReadOnlyCollection<Guid> IdsWithAccess { get; }

        public IReadOnlyCollection<Buff> Buffs { get; }

        public IReadOnlyCollection<Flags.RegionFlags> Flags { get; }
    }
}
