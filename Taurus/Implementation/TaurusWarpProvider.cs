using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taurus.Warps;
using Orion.Core.Utils;
using System.Collections;

namespace Taurus.Implementation
{
    public class TaurusWarpProvider : IWarpProvider
    {
        public bool AddWarp(IWarp warp)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IWarp> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IWarp GetWarpByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool RemoveWarp(IWarp warp)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
