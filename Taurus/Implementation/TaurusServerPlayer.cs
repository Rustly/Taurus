using Orion.Core.Players;
using Orion.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taurus.Commands;
using Taurus.Permissions;
using Taurus.Players;
using Taurus.UserAccounts;
using Taurus.UserGroups;

namespace Taurus.Implementation
{
    public class TaurusServerPlayer : IServerPlayer
    {
        public string Name { get; set; }

        public int Index { get; set; }

        public string IP { get; set; }

        public string UUID { get; set; }

        public IUserGroup Group { get; set; }

        public IUserAccount Account { get; set; }

        public IPlayer TPlayer => TaurusPlugin.serverReference.Players[Index];

        public bool HasPermission(string permission)
        {
            return Group.HasPermission(permission);
        }

        public void SendMessage(string message)
        {
            TPlayer.SendMessage(new(Orion.Core.Packets.DataStructures.NetworkTextMode.Literal, message), Color3.White);
        }

        public void SendMessage(string message, Color3 color)
        {
            TPlayer.SendMessage(new(Orion.Core.Packets.DataStructures.NetworkTextMode.Literal, message), color);
        }
    }
}
