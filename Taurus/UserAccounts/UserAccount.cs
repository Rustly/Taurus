using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Taurus.UserGroups;

namespace Taurus.UserAccounts
{
    /// <summary>
    ///     We want setters to be internal, and not accessible from outside the library.
    /// </summary>
    public class UserAccount : IUserAccount
    {
        private readonly string _password;

        private List<string> _userPerms;

        public Guid Id { get; internal set; }

        /// <summary>
        ///     UUID of this account.
        /// </summary>
        public string UUID { get; internal set; }

        /// <summary>
        ///     The name of this account.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///     Prefix of this account. Will be prefix of the <see cref="Group"/> if left unmodified.
        /// </summary>
        public string Prefix { get; internal set; }

        /// <summary>
        ///     Suffix of this account. Will be suffix of the <see cref="Group"/> if left unmodified.
        /// </summary>
        public string Suffix { get; internal set; }

        /// <summary>
        ///     Permissions of this account, together with the permission of its <see cref="Group"/>.
        /// </summary>
        public IReadOnlyCollection<string> Permissions { get; internal set; }

        /// <summary>
        ///     The history of IP's on this account. IPAddress type for consistency throughout all usecases.
        /// </summary>
        public IReadOnlyCollection<IPAddress> KnownIPs { get; internal set; } 

        /// <summary>
        ///     Group of the account.
        /// </summary>
        public IUserGroup Group { get; internal set; }

        /// <summary>
        ///     Gets if this account is currently muted.
        /// </summary>
        public bool IsMuted { get; internal set; }

        /// <summary>
        ///     Gets if this account is currently warned.
        /// </summary>
        public bool IsWarned { get; internal set; }

        /// <summary>
        ///     Gets if this account is currently banned.
        /// </summary>
        public bool IsBanned { get; internal set; }

        /// <summary>
        ///     The leave position of this account.
        /// </summary>
        public Vector2f LastPosition { get; internal set; }

        internal UserAccount()
        {
            // DB!
        }

        /// <summary>
        ///     Checks if this account has the permission looked for.
        /// </summary>
        /// <param name="permission">The permission to check.</param>
        /// <returns><see cref="true"/> if found. <see cref="false"/> if not.</returns>
        public bool HasPermission(string permission)
            => Permissions.Contains(permission);

        /// <summary>
        ///     Adds a range of permissions to this account. If all permissions being added already exist, none will be added.
        /// </summary>
        /// <param name="permissions">The range of permissions to add.</param>
        /// <returns><see cref="true"/> if all or any permissions were added. <see cref="false"/> if none were added.</returns>
        public bool AddPermission(params string[] permissions)
        {
            var @new = permissions.Except(_userPerms.Where(x => permissions.Contains(x)));
            if (!@new.Any())
                return false;
            var current = Permissions.ToList();
            current.AddRange(@new);
            _userPerms.AddRange(@new);
            Permissions = current;
            return true;
        }

        /// <summary>
        ///     Removes a range of permissions from this account. If all permissions in <paramref name="permissions"/> do not exist, none will be removed.
        /// </summary>
        /// <param name="permissions">The range of permissions to remove.</param>
        /// <returns><see cref="true"/> if all or any permissions were removed. <see cref="false"/> if none were removed.</returns>
        public bool RemovePermission(params string[] permissions)
        {
            var @new = _userPerms.Except(_userPerms.Where(x => permissions.Contains(x))).ToList();
            if (@new.Count == _userPerms.Count)
                return false;
            _userPerms = @new;
            @new.AddRange(Group.Permissions);
            Permissions = @new;
            return true;
        }

        /// <summary>
        ///     Verifies if the password of this account matches to the provided parameter or not.
        /// </summary>
        /// <param name="password">The password to match.</param>
        /// <returns><see cref="true"/> if it matches. <see cref="false"/> if not.</returns>
        public bool VerifyPassword(string password)
            => password.Trim() == _password;

        /// <summary>
        /// Modifies the current user based on provided data.
        /// </summary>
        /// <param name="action"></param>
        public void Modify(Action<AccountProperties> action)
        {
            var args = new AccountProperties();

            action(args);

            Prefix ??= args.Prefix;
            Suffix ??= args.Suffix;
            Name ??= args.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reason"></param>
        /// <param name="span"></param>
        /// <returns></returns>
        public bool Ban(string reason = "", TimeSpan? span = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reason"></param>
        /// <returns></returns>
        public bool Warn(string reason = "")
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reason"></param>
        /// <param name="span"></param>
        /// <returns></returns>
        public bool Mute(string reason = "", TimeSpan? span = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetMetadata<T>(string key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetMetadata(string key, object value)
        {
            throw new NotImplementedException();
        }
    }
}
