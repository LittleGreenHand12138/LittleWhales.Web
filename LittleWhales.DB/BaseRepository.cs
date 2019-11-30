using LittleWhales.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace LittleWhales.DB
{
    /// <summary>
    /// 数据处理基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly static string connectionString = "dbName";
        public Snapshot<T> Snapshot(T t, string _connectionStrName = "")
        {
            using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
            {
                return db.StartSnapshot(t);
            }
        }
        /// <summary>
        /// 根据主键ID获取唯一数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        public T GetEntry(object key, string _connectionStrName = "")
        {
            using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
            {
                return db.SingleOrDefaultById<T>(key);
            }
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        public Guid Insert(T obj, string _connectionStrName = "")
        {
            return Insert<Guid>(obj);
        }
        public string Insert1(T obj, string _connectionStrName = "")
        {
            return Insert11(obj);
        }
        public string Insert11(T obj, string _connectionStrName = "")
        {
            using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
            {
                db.Insert(obj);
                string pk = db.PocoDataFactory.ForType(typeof(T)).TableInfo.PrimaryKey;
                string s = GetValueFromObj(obj, pk).ToString();
                return s;
            }
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        public T2 Insert<T2>(T obj, string _connectionStrName = "")
        {
            using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
            {
                db.Insert(obj);
                string pk = db.PocoDataFactory.ForType(typeof(T)).TableInfo.PrimaryKey;

                object id = GetValueFromObj(obj, pk);


                T2 t = (T2)id;



                return t;
            }
        }

        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <param name="objList"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        public bool BulkInsert(List<T> objList, string _connectionStrName = "")
        {
            try
            {
                using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
                {
                    db.InsertBulk(objList);
                    return true;
                }
            }
            catch (Exception exp)
            {
                return false;
            }
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        public int Update(T obj, string _connectionStrName = "")
        {
            using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
            {
                return db.Update(obj);
            }
        }

        /// <summary>
        /// 修改数据（只更新有变化的列）
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="updatedColumns"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        public int Update(T obj, List<string> updatedColumns, string _connectionStrName = "")
        {
            if (updatedColumns == null || updatedColumns.Count == 0)
            {
                return 1;
            }
            using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
            {
                db.UpdateMany<T>();
                return db.Update(obj, updatedColumns);
            }
        }

        /// <summary>
        /// 根据主键ID删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        public int Delete(int id, string _connectionStrName = "")
        {
            using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
            {
                return db.Delete<T>(id);
            }
        }

        /// <summary>
        /// 根据主键ID删除数据     Thong  2015-09-21 18:31添加
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        public int Delete(object id, string _connectionStrName = "")
        {
            using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
            {
                return db.Delete<T>(id);
            }
        }
        public int Execute(Sql sql, string _connectionStrName = "")
        {
            using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
            {
                return db.Execute(sql);
            }
        }
        public int Execute(string sql, object[] args, string _connectionStrName = "")
        {
            using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
            {
                return db.Execute(sql, args);
            }
        }
        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="condition">条件，不需要带where，【为了防止有特殊字符，条件中的值请调用ToValidDbValue方法】</param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        public int DeleteBy(string condition, string _connectionStrName = "")
        {
            if (string.IsNullOrWhiteSpace(condition))
            {
                return 0;
            }
            Sql sql = new Sql();
            sql.Append(" where " + condition);
            using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
            {
                return db.Delete<T>(sql);
            }
        }
        /// <summary>
        /// 根据条件获取第一条数据
        /// </summary>
        /// <param name="condition">条件，不需要带where，【为了防止有特殊字符，条件中的值请调用ToValidDbValue方法】</param>
        /// <param name="orderby">排序，不需要order by</param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        public T GetOne(string condition = "", string orderby = "", string _connectionStrName = "")
        {
            Sql sql = new Sql();
            sql.Append("select   * from " + GetCurrName() + " limit 0,1");
            if (!string.IsNullOrWhiteSpace(condition))
            {
                sql.Append("where " + condition);
            }
            if (!string.IsNullOrWhiteSpace(orderby))
            {
                sql.Append("order by " + orderby);
            }

            using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
            {
                return db.FirstOrDefault<T>(sql);
            }
        }


        /// <summary>
        /// 根据条件获取第一条数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="connectionStrName"></param>
        /// <returns></returns>
        public T GetOne(Sql sql, string connectionStrName = "")
        {
            using (var db = new Database(string.IsNullOrWhiteSpace(connectionStrName) ? connectionString : connectionStrName))
            {
                return db.FirstOrDefault<T>(sql);
            }
        }
        /// <summary>
        /// 根据条件获取所有数据
        /// </summary>
        /// <param name="sql">条件，不需要带where，【为了防止有特殊字符，条件中的值请调用ToValidDbValue方法】</param>
        /// <param name="orderby">排序，不需要order by</param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        public List<T> GetAll(string condition = "", string orderby = "", string _connectionStrName = "")
        {
            Sql sql = new Sql();
            sql.Append("select * from " + GetCurrName());
            if (!string.IsNullOrWhiteSpace(condition))
            {
                sql.Append("where " + condition);
            }
            if (!string.IsNullOrWhiteSpace(orderby))
            {
                sql.Append("order by " + orderby);
            }

            using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
            {
                return db.Fetch<T>(sql);
            }
        }


        /// <summary>
        /// 根据条件获取所有数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        public List<T> GetAll(Sql sql, string _connectionStrName = "")
        {
            using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
            {
                return db.Fetch<T>(sql);
            }
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="total">返回的总数</param>
        /// <param name="condition">条件，不需要带where，【为了防止有特殊字符，条件中的值请调用ToValidDbValue方法】</param>
        /// <param name="orderBy">排序，不需要order by</param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        public Pager<T> Search(int pageSize, int pageIndex, string sql, string _connectionStrName = "", params object[] args)
        {
            using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
            {
                return db.Page<T>(pageIndex, pageSize, sql, args);
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="sql">完整的查询语句，【为了防止有特殊字符，条件中的值请调用ToValidDbValue方法】</param>
        /// <param name="total">返回的总数</param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        public Pager<T> Search(int pageSize, int pageIndex, Sql sql, string _connectionStrName = "")
        {
            using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
            {
                return db.Page<T>(pageIndex, pageSize, sql);
            }
        }
        /// <summary>
        /// 获取当前对象的名称
        /// </summary>
        /// <returns></returns>
        public string GetCurrName()
        {
            T t = new T();
            return t.GetType().Name;
        }

        /// <summary>
        /// 从实体中获取指定属性的值
        /// </summary>
        /// <param name="obj">实体</param>
        /// <param name="colName">属性名</param>
        /// <returns></returns>
        public object GetValueFromObj(T obj, string colName = "Id")
        {
            PropertyInfo[] propertys = obj.GetType().GetProperties();
            foreach (PropertyInfo info in propertys)
            {
                if (info.Name.Equals(colName))
                {
                    return info.GetValue(obj, null);
                }
            }
            return "";
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="sql">完整的SQL语句，【为了防止有特殊字符，条件中的值请调用ToValidDbValue方法】</param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        public DataTable GetData(string sql, string _connectionStrName = "")
        {
            DataTable dt = new DataTable();
            using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionString : _connectionStrName))
            {
                db.Fill(dt, sql);
                return dt;
            }
        }
    }
}

