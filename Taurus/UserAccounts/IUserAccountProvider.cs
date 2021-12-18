using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.UserAccounts
{
    public interface IUserAccountProvider : Databases.IDatabase<IUserAccount>
    {
        public IUserAccount Get(string username);
    }
}
