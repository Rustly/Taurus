using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taurus.Regions;
using Taurus.UserAccounts;
using Taurus.UserGroups;

namespace Taurus.Entities
{
    internal static class EntityHelper
    {
        private static readonly Databases.DatabaseClient _db;

        static EntityHelper()
        {
            _db = new("your mother");
        }

        public static T TryGet<T>(string name) where T : IEntity
        {
            string table = nameof(T).ToLower() + "s"; // temporary
            var entity = _db.FindOne<T>(x => x.Name == name, table);
            if (entity != null)
                return entity;
            else throw new KeyNotFoundException("No group was found under this name.");
        }

        public static T TryGet<T>(Guid uid) where T : IEntity
        {
            string table = nameof(T).ToLower() + "s"; // temporary
            var entity = _db.FindOne<T>(x => x.Id == uid, table);
            if (entity != null)
                return entity;
            else throw new KeyNotFoundException("No group was found under this ID");
        }
    }
}
