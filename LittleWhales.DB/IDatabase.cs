using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using LittleWhales.DB.Linq;

namespace LittleWhales.DB
{
    public interface IDatabase : IDisposable, IDatabaseQuery, IDatabaseConfig
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        IDataParameter CreateParameter();
        void AddParameter(IDbCommand cmd, object value);
        IDbCommand CreateCommand(IDbConnection connection, string sql, params object[] args);
        ITransaction GetTransaction();
        ITransaction GetTransaction(IsolationLevel isolationLevel);
        void SetTransaction(IDbTransaction tran);
        void BeginTransaction();
        void BeginTransaction(IsolationLevel isolationLevel);
        void AbortTransaction();
        void CompleteTransaction();
        object Insert<T>(string tableName, string primaryKeyName, bool autoIncrement, T poco);
        object Insert<T>(string tableName, string primaryKeyName, T poco);
        object Insert<T>(T poco);
        void InsertBulk<T>(IEnumerable<T> pocos);
        int Update(string tableName, string primaryKeyName, object poco, object primaryKeyValue);
        int Update(string tableName, string primaryKeyName, object poco);
        int Update(string tableName, string primaryKeyName, object poco, object primaryKeyValue, IEnumerable<string> columns);
        int Update(string tableName, string primaryKeyName, object poco, IEnumerable<string> columns);
        int Update(object poco, IEnumerable<string> columns);
        int Update(object poco, object primaryKeyValue, IEnumerable<string> columns);
        int Update(object poco);
        int Update<T>(T poco, Expression<Func<T, object>> fields);
        int Update(object poco, object primaryKeyValue);
        int Update<T>(string sql, params object[] args);
        int Update<T>(Sql sql);
        IUpdateQueryProvider<T> UpdateMany<T>();
        int Delete(string tableName, string primaryKeyName, object poco);
        int Delete(string tableName, string primaryKeyName, object poco, object primaryKeyValue);
        int Delete(object poco);
        int Delete<T>(string sql, params object[] args);
        int Delete<T>(Sql sql);
        int Delete<T>(object pocoOrPrimaryKey);
        IDeleteQueryProvider<T> DeleteMany<T>();
        void Save<T>(object poco);
        bool IsNew<T>(object poco);
        void Fill(DataTable dt, string sql, params object[] args);
    }

    public interface IDatabaseConfig
    {
        IMapper Mapper { get; set; }
        PocoDataFactory PocoDataFactory { get; set; }
        DatabaseType DatabaseType { get; }
        string ConnectionString { get; }
    }
}