using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.UserGroups
{
    internal class GroupProvider
    {
        private readonly string _tableName;

        internal GroupProvider(string table)
        {
            _tableName = table;
        }
    }
}
