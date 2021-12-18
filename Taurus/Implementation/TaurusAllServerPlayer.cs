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
using Taurus.Players;
using Taurus.UserAccounts;
using Taurus.UserGroups;

namespace Taurus.Implementation
{
    public class TaurusAllServerPlayer : IServerPlayer
    {
        public string Name { get; set; } = "All";

        public int Index { get; set; } = -1;

        public string IP { get; set; }

        public string UUID { get; set; }

        public IUserGroup Group { get; set; }

        public IUserAccount Account { get; set; }

        public IPlayer TPlayer => TaurusPlugin.serverReference.Players[Index];

        private readonly IPlayerService _provider;

        public TaurusAllServerPlayer(IPlayerService provider)
        {
            _provider = provider;
        }

        public bool HasPermission(string permission)
        {
            return true;
        }

        public void SendMessage(string message)
        {
            _provider.BroadcastMessage(new(Orion.Core.Packets.DataStructures.NetworkTextMode.Literal, message), Color3.White);
        }

        public void SendMessage(string message, Color3 color)
        {
            _provider.BroadcastMessage(new(Orion.Core.Packets.DataStructures.NetworkTextMode.Literal, message), color);
        }

        private class TaurusAllPlayer : IPlayer
        {
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

            private readonly IPlayerService _provider;

            public TaurusAllPlayer(IPlayerService provider)
            {
                _provider = provider;
            }

            public void ClearAnnotations()
            {
                throw new NotImplementedException();
            }

            public TAnnotation GetAnnotation<TAnnotation>(AnnotationKey<TAnnotation> key, Func<TAnnotation>? initializer = null)
            {
                throw new NotImplementedException();
            }

            public void ReceivePacket<TPacket>(TPacket packet) where TPacket : IPacket
            {
                throw new NotImplementedException();
            }

            public bool RemoveAnnotation<TAnnotation>(AnnotationKey<TAnnotation> key)
            {
                throw new NotImplementedException();
            }

            public void SendPacket<TPacket>(TPacket packet) where TPacket : IPacket
            {
                
            }

            public void SetAnnotation<TAnnotation>(AnnotationKey<TAnnotation> key, TAnnotation value)
            {
                throw new NotImplementedException();
            }

            public void Teleport(Vector2f newPosition, byte style)
            {
                
            }
        }
    }
}
