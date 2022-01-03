using Taurus.Regions;
using Taurus.UserAccounts;
using Taurus.UserGroups;

namespace Taurus.Commands.Parsers
{
    internal class EntityParsers
    {
        public static UserAccount ParseUserAccount(string s)
        {
            if (UserAccount.TryParse(s, out UserAccount result))
                return result;
            else return null;
        }
        public static UserGroup ParseUserGroup(string s)
        {
            if (UserGroup.TryParse(s, out UserGroup result))
                return result;
            else return null;
        }

        public static Region ParseRegion(string s)
        {
            if (Region.TryParse(s, out Region result))
                return result;
            else return null;
        }
    }
}
