using Taurus.Databases;

namespace Taurus.UserGroups
{
    /// <inheritdoc/>
    public class UserGroup : IUserGroup
    {
        private readonly DatabaseClient _db;

        private const string _table = "usergroups";

        /// <inheritdoc/>
        public Guid Id { get; internal set; }

        /// <summary>
        ///     The name of this group.
        /// </summary>
        public string Name { get; internal set; }

        /// <inheritdoc/>
        public string Prefix { get; internal set; }

        /// <inheritdoc/>
        public string Suffix { get; internal set; }

        /// <inheritdoc/>
        public bool CanBuild { get; internal set; }

        /// <inheritdoc/>
        public bool CanPaint { get; internal set; }

        /// <inheritdoc/>
        public bool IsDefault { get; internal set; }

        /// <inheritdoc/>
        public IReadOnlyCollection<string> Permissions { get; internal set; }

        internal UserGroup(string name)
        {
            _db = new DatabaseClient("your mother"); // This is a very wrong approach, will rework this when implementing our service provider.

            var entry = _db.FindOne<UserGroup>(x => x.Id == new Guid(), _table);

            if (entry is null)
                throw new ArgumentNullException(nameof(name), "This group does not exist! The default group will be assigned to this user."); // TODO

            Name = entry.Name;
            Prefix = entry.Prefix;
            Suffix = entry.Suffix;
            CanBuild = entry.CanBuild;
            CanPaint = entry.CanPaint;
            IsDefault = entry.IsDefault;
            Permissions = entry.Permissions;
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
            _db.InsertOrUpdateOne(this, _table);
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
            _db.InsertOrUpdateOne(this, _table);
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
            if (args.CanBuild.HasValue)
                CanBuild = args.CanBuild.Value;
            if (args.CanPaint.HasValue)
                CanPaint = args.CanPaint.Value;

            _db.InsertOrUpdateOne(this, _table);
        }

        /// <summary>
        ///     Tries to get a group by name.
        /// </summary>
        /// <param name="name">The name of the group to look for.</param>
        /// <param name="result">The group to return.</param>
        /// <returns><see cref="true"/> if found. <see cref="false"/> if not.</returns>
        public static bool TryParse(string name, out UserGroup result)
        {
            result = Entities.EntityHelper.TryGet<UserGroup>(name);
            return result != null;
        }

        /// <summary>
        ///     Tries to get a group by ID.
        /// </summary>
        /// <param name="uid">The ID of the group to look for.</param>
        /// <param name="result">The group to return.</param>
        /// <returns><see cref="true"/> if found. <see cref="false"/> if not.</returns>
        public static bool TryGet(Guid uid, out UserGroup result)
        {
            result = Entities.EntityHelper.TryGet<UserGroup>(uid);
            return result != null;
        }
    }
}
