using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.UserGroups
{
    /// <summary>
    ///     Making this a struct since groups should be cached, and not require a lookup if no values are changed inside. 
    ///     
    ///     We can set events in the setters to trigger re-caching.
    /// </summary>
    public class UserGroup : IUserGroup
    {
        public Guid Id { get; internal set; }

        /// <summary>
        ///     The name of this group.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///     The prefix of this group.
        /// </summary>
        public string Prefix { get; internal set; }

        /// <summary>
        ///     The suffix of this group.
        /// </summary>
        public string Suffix { get; internal set; }

        /// <summary>
        ///     The permissions of this group.
        /// </summary>
        public IReadOnlyCollection<string> Permissions { get; internal set; }

        internal UserGroup()
        {
            // DB!
        }

        /// <summary>
        ///     Checks if this group has a permission.
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public bool HasPermission(string permission)
            => Permissions.Contains(permission);

        /// <summary>
        ///     Adds a range of permissions to this Group. If all permissions being added already exist, none will be added.
        /// </summary>
        /// <param name="permissions">The range of permissions to add.</param>
        /// <returns><see cref="true"/> if all or any permissions were added. <see cref="false"/> if none were added.</returns>
        public bool AddPermission(params string[] permissions)
        {
            var @new = permissions.Except(Permissions.Where(x => permissions.Contains(x)));
            if (!@new.Any())
                return false;
            var current = Permissions.ToList();
            current.AddRange(@new);
            Permissions = current;
            return true;
        }

        /// <summary>
        ///     Removes a range of permissions from this Group. If all permissions in <paramref name="permissions"/> do not exist, none will be removed.
        /// </summary>
        /// <param name="permissions">The range of permissions to remove.</param>
        /// <returns><see cref="true"/> if all or any permissions were removed. <see cref="false"/> if none were removed.</returns>
        public bool RemovePermission(params string[] permissions)
        {
            var @new = Permissions.Except(Permissions.Where(x => permissions.Contains(x))).ToList();
            if (@new.Count == Permissions.Count)
                return false;
            Permissions = @new;
            return true;
        }

        /// <summary>
        ///     Modifies the group.
        /// </summary>
        /// <param name="action">The modification action to use.</param>
        public void Modify(Action<GroupProperties> action)
        {
            var args = new GroupProperties();

            action(args);

            Name ??= args.Name;
            Prefix ??= args.Prefix;
            Suffix ??= args.Suffix;
        }
    }
}
