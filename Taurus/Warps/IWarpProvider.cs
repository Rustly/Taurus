using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.Warps
{
    public interface IWarpProvider : IEnumerable<IWarp>
    {
        public bool AddWarp(IWarp warp);

        public bool RemoveWarp(IWarp warp);

        public IWarp GetWarpByName(string name);
    }
}
