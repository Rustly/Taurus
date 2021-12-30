using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Taurus.UserGroups;

namespace Taurus.UserAccounts
{
    public interface IUserAccount : Entities.IEntity
    {
        public string Name { get; }

        public string UUID { get; }

        public string Prefix { get; }

        public string Suffix { get; }

        public IReadOnlyCollection<string> Permissions { get; }

        public IUserGroup Group { get; }

        public IReadOnlyCollection<IPAddress> KnownIPs { get; }
    }
}
