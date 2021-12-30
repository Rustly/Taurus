using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.UserGroups
{
    public interface IUserGroup : Entities.IEntity
    {
        public string Name { get; }

        public string Prefix { get; }

        public string Suffix { get; }

        public IReadOnlyCollection<string> Permissions { get; }
    }
}
