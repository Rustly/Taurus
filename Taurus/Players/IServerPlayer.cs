using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orion.Core.Players;
using Orion.Core.Utils;
using Orion.Core.Packets.World.Tiles;
using Orion.Core.Packets.DataStructures;
using Orion.Core.Packets.Misc;
using Orion.Core.Packets.Players;
using Orion.Core;
using Orion.Core.Packets.Items;
using Orion.Core.Items;

namespace Taurus.Players
{
    public interface IServerPlayer : Permissions.IPermissible, Commands.ICommandSender, IPlayer
    {
        public UserAccounts.IUserAccount Account { get; protected set; }

        public UserGroups.IUserGroup Group { get; set; }

        public string IP { get; set; }

        public string UUID { get; set; }
    }

    public static class PlayerExtensions
    {
        public static void Heal(this IPlayer player, int health = 600)
        {
            player.SendPacket(new PlayerHeal() { PlayerIndex = (byte)player.Index, Amount = (short)health });
        }

        public static void GiveItem(this IPlayer player, ItemStack item)
        {
            var i = TaurusPlugin.serverReference.Items.Spawn(item, player.Position);

            player.SendPacket(new ItemInfo()
            {
                Id = item.Id,
                StackSize = item.StackSize,
                Prefix = item.Prefix,
                Velocity = player.Velocity,
                ItemIndex = (short)i.Index,
                Position = player.Position
            });
        }

        public static void Disconnect(this IPlayer player, string reason = "Disconnected by server.")
        {
            player.Disconnect(new NetworkText(NetworkTextMode.Literal, reason));
        }

        public static void SendTileSquare(this IPlayer player, int x, int y, int size = 10)
        {
            player.SendTiles(x, y, new NetworkTileSlice(size, size));
        }

        public static void Teleport(this IServerPlayer player, Vector2f newPosition, byte style = 1)
        {
            player.SendTileSquare((int)newPosition.X / 16, (int)newPosition.Y / 16, 15);
            player.Teleport(newPosition, style);
            TaurusPlugin.serverReference.Players.BroadcastPacket(new Teleport() { Target = (short)player.Index, Position = newPosition, Style = style });
        }
    }
}
