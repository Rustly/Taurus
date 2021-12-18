using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.UserAccounts
{
    public interface IUserAccount
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string UUID { get; set; }

        public UserGroups.IUserGroup Group { get; set; }

        public ICollection<string> KnownIPs { get; set; }

        public bool VerifyPassword(string passwordToVerify);

        public T GetMetadata<T>(string key);

        public void SetMetadata(string key, object value);
    }
}
