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
        /// <summary>
        ///     UUID of this account.
        /// </summary>
        public string UUID { get; }

        /// <summary>
        ///     Prefix of this account. Will be prefix of the <see cref="Group"/> if left unmodified.
        /// </summary>
        public string Prefix { get; }

        /// <summary>
        ///     Suffix of this account. Will be suffix of the <see cref="Group"/> if left unmodified.
        /// </summary>
        public string Suffix { get; }

        /// <summary>
        ///     Permissions of this account, together with the permission of its <see cref="Group"/>.
        /// </summary>
        public IReadOnlyCollection<string> Permissions { get; }

        /// <summary>
        ///     The history of IP's on this account. IPAddress type for consistency throughout all usecases.
        /// </summary>
        public IReadOnlyCollection<IPAddress> KnownIPs { get; }

        /// <summary>
        ///     Group of the account.
        /// </summary>
        public IUserGroup Group { get; }

        /// <summary>
        ///     Gets if this account is currently muted.
        /// </summary>
        public bool IsMuted { get; }

        /// <summary>
        ///     Gets if this account is currently warned.
        /// </summary>
        public bool IsWarned { get; }

        /// <summary>
        ///     Gets if this account is currently banned.
        /// </summary>
        public bool IsBanned { get; }

        /// <summary>
        ///     The leave position of this account.
        /// </summary>
        public Vector2f LastPosition { get; }
    }
}
