using System;
using System.Data.Common;

namespace Helpers.Common.Data
{
    /// <summary>
    /// Base class to interact with a DB.
    /// </summary>
    public abstract class StorageBase
    {
        /// <summary>
        /// <see cref="DbProviderFactory"/> object with a set of methods for creating instances of a provider's implementation of data source classes.
        /// </summary>
        protected DbProviderFactory DbFactory { get; }

        /// <summary>
        /// <see cref="DbConnection"/> object to connect to DB.
        /// </summary>
        protected DbConnection Connection { get; }

        /// <summary>
        /// The wait time before terminating the attempt to execute a command and generating an error.
        /// </summary>
        protected int TimeoutInSeconds { get; }

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="connectionString">the string used to open the connection to DB</param>
        /// <param name="timeoutInSeconds">the wait time before terminating the attempt to execute a command and generating an error</param>
        protected StorageBase(string connectionString, int timeoutInSeconds = 30)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException($"{nameof(connectionString)} cannot be null or empty", nameof(connectionString));

            TimeoutInSeconds = timeoutInSeconds;
            DbFactory = DbProviderFactories.GetFactory(connectionString);

            if (DbFactory == null)
                throw new StorageInitializationException("Cannot create DB provider factory object");

            Connection = DbFactory.CreateConnection();

            if (Connection == null)
                throw new StorageInitializationException("Cannot create connection object");

            Connection.ConnectionString = connectionString;
        }

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="connectionString">the string used to open the connection to DB</param>
        /// <param name="dbFactory"><see cref="DbProviderFactory"/> object with a set of methods for creating instances of a provider's implementation of data source classes</param>
        /// <param name="timeoutInSeconds">the wait time before terminating the attempt to execute a command and generating an error</param>
        protected StorageBase(string connectionString, DbProviderFactory dbFactory, int timeoutInSeconds = 30)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException($"{nameof(connectionString)} cannot be null or empty", nameof(connectionString));

            DbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory), $"{nameof(dbFactory)} cannot be null");
            TimeoutInSeconds = timeoutInSeconds;
            Connection = DbFactory.CreateConnection();

            if (Connection == null)
                throw new StorageInitializationException("Cannot create connection object");

            Connection.ConnectionString = connectionString;
        }

        /// <summary>
        /// Returns a new instance of the <see cref="DbCommand"/> class.
        /// </summary>
        /// <param name="commandText">the text command to run against the data source</param>
        /// <returns>a new instance of <see cref="DbCommand"/></returns>
        protected virtual DbCommand CreateCommand(string commandText)
        {
            var command = DbFactory.CreateCommand();

            if (command == null)
                throw new StorageInitializationException("Cannot create command object");

            command.CommandText = commandText;
            command.CommandTimeout = TimeoutInSeconds;
            command.Connection = Connection;

            return command;
        }

        /// <summary>
        /// Execute an action enclosed by connection open/close calls.
        /// </summary>
        /// <param name="action"><see cref="Action"/> object to execute</param>
        protected void Execute(Action action)
        {
            lock (Connection) {
                try {
                    Connection.Open();

                    action?.Invoke();
                }
                finally {
                    Connection.Close();
                }
            }
        }

        /// <summary>
        /// Execute an func enclosed by connection open/close calls.
        /// </summary>
        /// <param name="func"><see cref="Func{T}"/> object to execute</param>
        protected T Execute<T>(Func<T> func)
        {
            lock (Connection) {
                try {
                    Connection.Open();

                    return func != null ? func() : default(T);
                }
                finally {
                    Connection.Close();
                }
            }
        }
    }
}