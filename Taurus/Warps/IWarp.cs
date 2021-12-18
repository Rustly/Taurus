using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.Warps
{
    public interface IWarp
    {
        public string Name { get; set; }

        public int DestinationTileX { get; set; }

        public int DestinationTileY { get; set; }

        public int HitboxTileX { get; set; }

        public int HitboxTileY { get; set; }

        public int HitboxWidth { get; set; }

        public int HitboxHeight { get; set; }

        public int WorldId { get; set; }
    }
}
