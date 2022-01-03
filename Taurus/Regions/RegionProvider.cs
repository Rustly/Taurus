using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.Regions
{
    internal class RegionProvider
    {
        private readonly string _tableName;

        internal RegionProvider(string table)
        {
            _tableName = table;
        }
    }
}
