using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Taurus.Logging;

namespace Taurus.Databases
{
    internal class DatabaseClient
    {
        private readonly string _databaseConnectionString;

        internal DatabaseClient(string connectionString)
        { 
            _databaseConnectionString = connectionString;
            Connect();
        }

        public event Action<LogMessage>? Log;

        private bool Connect()
        {
            Log?.Invoke(new LogMessage(LogSeverity.Info, nameof(DatabaseClient), "Succesfully connected!"));
            throw new NotImplementedException();
        }

        public bool InsertOrUpdateOne<T>(T entity, string table) where T : Entities.IEntity
        {
            throw new NotImplementedException();
        }

        public void InsertOne<T>(T entity, string table) where T : Entities.IEntity
        {
            throw new NotImplementedException();
        }

        public bool DeleteMany<T>(Predicate<T> filter, string table) where T : Entities.IEntity
        {
            throw new NotImplementedException();
        }

        public bool DeleteOne<T>(Predicate<T> filter, string table) where T : Entities.IEntity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindMany<T>(Predicate<T> filter, string table) where T : Entities.IEntity
        {
            throw new NotImplementedException();
        }

        public T FindOne<T>(Predicate<T> filter, string table) where T : Entities.IEntity
        {
            throw new NotImplementedException();
        }

        private void RunEFCommand(string command, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
