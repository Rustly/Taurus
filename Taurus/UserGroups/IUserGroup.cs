using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.UserGroups
{
    public interface IUserGroup : Entities.IEntity
    {
        /// <summary>
        ///     The prefix of this group.
        /// </summary>
        public string Prefix { get; }

        /// <summary>
        ///     The suffix of this group.
        /// </summary>
        public string Suffix { get; }

        /// <summary>
        ///     Gets if this group can build in the world.
        /// </summary>
        public bool CanBuild { get; }

        /// <summary>
        ///     Gets if this group can paint in the world.
        /// </summary>
        public bool CanPaint { get; }

        /// <summary>
        ///     Gets if this group is the default group new users obtain.
        /// </summary>
        public bool IsDefault { get; }

        /// <summary>
        ///     The permissions of this group.
        /// </summary>
        public IReadOnlyCollection<string> Permissions { get; }
    }
}
