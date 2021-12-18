using Orion.Core;
using Orion.Core.Entities;
using Orion.Core.Items;
using Orion.Core.Packets;
using Orion.Core.Players;
using Orion.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.Players
{
    public class BaseServerPlayer : AnnotatableObject, IPlayer
    {
        public UserAccounts.IUserAccount Account { get; protected set; }

        public UserGroups.IUserGroup Group { get; set; }

        public string IP { get; set; }

        public string UUID { get; set; }

        public ICharacter Character => throw new NotImplementedException();

        public IArray<Buff> Buffs => throw new NotImplementedException();

        public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MaxHealth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Mana { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MaxMana { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IArray<ItemStack> Inventory => throw new NotImplementedException();

        public bool IsInPvp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Team Team { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Index => throw new NotImplementedException();

        public bool IsActive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2f Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2f Velocity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2f Size { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected readonly IServer _server;

        public BaseServerPlayer(IServer server)
        {
            _server = server;
        }

        public void ReceivePacket<TPacket>(TPacket packet) where TPacket : IPacket
        {
            throw new NotImplementedException();
        }

        public void SendPacket<TPacket>(TPacket packet) where TPacket : IPacket
        {
            throw new NotImplementedException();
        }

        public void Teleport(Vector2f newPosition, byte style)
        {
            throw new NotImplementedException();
        }
    }
}
