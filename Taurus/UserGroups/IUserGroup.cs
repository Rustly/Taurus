using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.UserGroups
{
    public interface IUserGroup
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool HasPermission(string permission);

        public bool AddPermission(string permission);

        public bool RemovePermission(string permission);
    }
}
