/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：TransactionService.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/6 18:10:54
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using LittleWhales.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace LittleWhales.DB
{
    /// <summary>
    /// 事务处理
    /// </summary>
    public class TransactionService
    {
        /// <summary>
        /// 写数据连接
        /// </summary>
        private const string ConnectionWriteString = "dbName";

        // ReSharper disable once InconsistentNaming
        private Database transactionDB { get; set; }

        /// <summary>
        /// 开始事务，自动启动事务
        /// 该事务中的所有处理方法，都应该放在一个统一的try中
        /// 事务结束，一定要调用ComplateTransaction方法处理，异常时调用AbortTransaction方法
        /// </summary>
        /// <param name="connectionStrName"></param>
        /// <param name="level">事物级别</param>
        public TransactionService(string connectionStrName = "", IsolationLevel level = IsolationLevel.ReadUncommitted)
        {
            transactionDB = new Database(string.IsNullOrWhiteSpace(connectionStrName) ? ConnectionWriteString : connectionStrName);
            transactionDB.BeginTransaction(level);
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void ComplateTransaction()
        {
            if (transactionDB == null)
            {
                return;
            }
            transactionDB.CompleteTransaction();

            transactionDB.Dispose();
            transactionDB = null;
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        public void AbortTransaction()
        {
            if (transactionDB == null)
            {
                return;
            }
            transactionDB.AbortTransaction();
            transactionDB.Dispose();
            transactionDB = null;
        }
        /// <summary>
        /// 释放事物
        /// </summary>
        public void DisposeTransaction()
        {
            if (transactionDB == null)
            {
                return;
            }
            transactionDB.Dispose();
            transactionDB = null;
        }

        /// <summary>
        /// 获取对象的快照
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Snapshot<T> Snapshot<T>(T t)
        {
            return transactionDB.StartSnapshot(t);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Guid Insert<T>(T obj)
        {
            //刘波 2019-3-24 对插入事件的返回结果进行处理
            object result = transactionDB.Insert(obj);
            if (result == null || (result is int && (int)result == 0))
            {
                return Guid.Empty;
            }

            string pk = transactionDB.PocoDataFactory.ForType(typeof(T)).TableInfo.PrimaryKey;
            return (Guid)GetValueFromObj(obj, pk);
        }

        public string Insert1<T>(T obj)
        {
            try
            {
                //刘波 2019-3-24 对插入事件的返回结果进行处理
                object result = transactionDB.Insert(obj);
                if (result == null || (result is int && (int)result == 0))
                {
                    return string.Empty;
                }

                string pk = transactionDB.PocoDataFactory.ForType(typeof(T)).TableInfo.PrimaryKey;
                return GetValueFromObj(obj, pk).ToString();
            }
            catch (Exception x)
            {
                return string.Empty;
            }

        }

        /// <summary>
        /// 批量添加添加
        /// </summary>
        /// <param name="objList"></param>
        /// <returns></returns>
        public bool BulkInsert<T>(List<T> objList)
        {
            try
            {
                if (objList == null || objList.Count == 0)
                {
                    return false;
                }
                transactionDB.InsertBulk(objList);
                return true;

            }
            catch (Exception e)
            {
                return false;
            }

        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Update<T>(T obj)
        {
            return transactionDB.Update(obj);
        }

        /// <summary>
        /// 修改（只更新有变化的列）
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="updatedColumns"></param>
        /// <returns></returns>
        public int Update<T>(T obj, List<string> updatedColumns)
        {
            if (updatedColumns == null || updatedColumns.Count == 0)
            {
                return 1;
            }
            transactionDB.UpdateMany<T>();
            return transactionDB.Update(obj, updatedColumns);
        }

        public int Update<T>(Sql sql)
        {
            return transactionDB.Update<T>(sql);
        }

        public int Update<T>(string sql, params object[] args)
        {
            return transactionDB.Update<T>(sql, args);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete<T>(object id)
        {
            return transactionDB.Delete<T>(id);
        }
        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="condition">条件，不需要带where，【为了防止有特殊字符，条件中的值请调用ToValidDbValue方法】</param>
        /// <returns></returns>
        public int DeleteBy<T>(string condition)
        {
            if (string.IsNullOrWhiteSpace(condition))
            {
                return 0;
            }
            Sql sql = new Sql();
            sql.Append(" where " + condition);
            return transactionDB.Delete<T>(sql);
        }
        /// <summary>
        /// 执行语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int Execute(Sql sql)
        {
            return transactionDB.Execute(sql);
        }
        /// <summary>
        /// 执行语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public int Execute(string sql, object[] args)
        {
            return transactionDB.Execute(sql, args);
        }

        /****************************************************************/

        /// <summary>
        /// 根据条件获取所有数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T> GetAll<T>(Sql sql)
        {
            return transactionDB.Fetch<T>(sql);
        }

        /// <summary>
        /// 根据条件获取所有数据
        /// </summary>
        /// <param name="condition">条件，不需要带where，【为了防止有特殊字符，条件中的值请调用ToValidDbValue方法】</param>
        /// <param name="orderby">排序，不需要order by</param>
        /// <returns></returns>
        public List<T> GetAll<T>(string condition = "", string orderby = "") where T : class, new()
        {
            Sql sql = new Sql();
            sql.Append("select * from " + GetCurrName<T>());
            if (!string.IsNullOrWhiteSpace(condition))
            {
                sql.Append("where " + condition);
            }
            if (!string.IsNullOrWhiteSpace(orderby))
            {
                sql.Append("order by " + orderby);
            }

            return transactionDB.Fetch<T>(sql);
        }

        /// <summary>
        /// 根据条件获取第一条数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public T GetOne<T>(Sql sql)
        {
            return transactionDB.FirstOrDefault<T>(sql);
        }

        /// <summary>
        /// 根据条件获取第一条数据
        /// </summary>
        /// <param name="conditionWhereStr">条件，不需要带where，【为了防止有特殊字符，条件中的值请调用ToValidDbValue方法】</param>
        /// <param name="orderby">排序，不需要order by</param>
        /// <returns></returns>
        public T GetOne<T>(string conditionWhereStr = "", string orderby = "") where T : class, new()
        {
            Sql sql = new Sql();
            sql.Append("select top 1 * from " + GetCurrName<T>());
            if (!string.IsNullOrWhiteSpace(conditionWhereStr))
            {
                sql.Append("where " + conditionWhereStr);
            }
            if (!string.IsNullOrWhiteSpace(orderby))
            {
                sql.Append("order by " + orderby);
            }

            return GetOne<T>(sql);
        }

        /// <summary>
        /// 根据主键获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetEntry<T>(object key)
        {
            return transactionDB.SingleOrDefaultById<T>(key);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object Scalar(Sql sql)
        {
            return transactionDB.ExecuteScalar(sql);
        }

        /// <summary>
        /// 获取第一行的第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object GetScalar(string sql)
        {
            return transactionDB.ExecuteScalar(new Sql(sql));
        }

        public bool Exists<T>(string conditionWhereStr = "") where T : class, new()
        {
            Sql sql = new Sql();
            sql.Append("if exists(select top 1 * from " + GetCurrName<T>());
            if (!string.IsNullOrWhiteSpace(conditionWhereStr))
            {
                sql.Append(" where " + conditionWhereStr);
            }
            sql.Append(") select cast(1 as bit) else select cast(0 as bit)");

            return Scalar(sql).ToInt() == 1;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">第几页</param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Pager<T> Search<T>(int pageSize, int pageIndex, string sql, params object[] args)
        {
            //using (var db = new Database(string.IsNullOrWhiteSpace(_connectionStrName) ? connectionReadString : _connectionStrName))
            //{
            return transactionDB.Page<T>(pageIndex, pageSize, sql, args);
            //}
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="sql">完整的查询语句，【为了防止有特殊字符，条件中的值请调用ToValidDbValue方法】</param>
        /// <returns></returns>
        public Pager<T> Search<T>(int pageSize, int pageIndex, Sql sql)
        {
            return transactionDB.Page<T>(pageIndex, pageSize, sql);
        }

        #region 私有

        /// <summary>
        /// 从实体中获取指定属性的值
        /// </summary>
        /// <param name="obj">实体</param>
        /// <param name="colName">属性名</param>
        /// <returns></returns>
        private object GetValueFromObj<T>(T obj, string colName = "ID")
        {
            PropertyInfo[] propertys = obj.GetType().GetProperties();
            foreach (PropertyInfo info in propertys.Where(info => info.Name.Equals(colName)))
            {
                return info.GetValue(obj, null);
            }
            return "";
        }

        /// <summary>
        /// 获取当前对象的名称
        /// </summary>
        /// <returns></returns>
        private static string GetCurrName<T>() where T : class, new()
        {
            T t = new T();
            return t.GetType().Name;
        }

        #endregion
    }
}
