using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.Permissions
{
    public interface IPermissible
    {
        public bool HasPermission(string permission);
    }
}
