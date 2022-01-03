using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.UserAccounts
{
    internal class AccountProvider
    {
        private readonly string _tableName;

        internal AccountProvider(string table)
        {
            _tableName = table;
        }
    }
}
