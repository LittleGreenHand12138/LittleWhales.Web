using System;
using System.Collections.Generic;
using System.Data;

namespace LittleWhales.DB
{
    public interface IBaseRepository<T> where T : class, new()
    {
        Snapshot<T> Snapshot(T t, string _connectionStrName = "");
        /// <summary>
        /// 根据主键ID获取唯一数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        T GetEntry(object key, string _connectionStrName = "");
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        Guid Insert(T obj, string _connectionStrName = "");
        string Insert1(T obj, string _connectionStrName = "");
        string Insert11(T obj, string _connectionStrName = "");
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        T2 Insert<T2>(T obj, string _connectionStrName = "");

        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <param name="objList"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        bool BulkInsert(List<T> objList, string _connectionStrName = "");
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        int Update(T obj, string _connectionStrName = "");

        /// <summary>
        /// 修改数据（只更新有变化的列）
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="updatedColumns"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        int Update(T obj, List<string> updatedColumns, string _connectionStrName = "");

        /// <summary>
        /// 根据主键ID删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        int Delete(int id, string _connectionStrName = "");

        /// <summary>
        /// 根据主键ID删除数据     Thong  2015-09-21 18:31添加
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        int Delete(object id, string _connectionStrName = "");
        int Execute(Sql sql, string _connectionStrName = "");
        int Execute(string sql, object[] args, string _connectionStrName = "");
        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="condition">条件，不需要带where，【为了防止有特殊字符，条件中的值请调用ToValidDbValue方法】</param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        int DeleteBy(string condition, string _connectionStrName = "");
        /// <summary>
        /// 根据条件获取第一条数据
        /// </summary>
        /// <param name="condition">条件，不需要带where，【为了防止有特殊字符，条件中的值请调用ToValidDbValue方法】</param>
        /// <param name="orderby">排序，不需要order by</param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        T GetOne(string condition = "", string orderby = "", string _connectionStrName = "");


        /// <summary>
        /// 根据条件获取第一条数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="connectionStrName"></param>
        /// <returns></returns>
        T GetOne(Sql sql, string connectionStrName = "");
        /// <summary>
        /// 根据条件获取所有数据
        /// </summary>
        /// <param name="sql">条件，不需要带where，【为了防止有特殊字符，条件中的值请调用ToValidDbValue方法】</param>
        /// <param name="orderby">排序，不需要order by</param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        List<T> GetAll(string condition = "", string orderby = "", string _connectionStrName = "");


        /// <summary>
        /// 根据条件获取所有数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        List<T> GetAll(Sql sql, string _connectionStrName = "");
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
        Pager<T> Search(int pageSize, int pageIndex, string sql, string _connectionStrName = "", params object[] args);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="sql">完整的查询语句，【为了防止有特殊字符，条件中的值请调用ToValidDbValue方法】</param>
        /// <param name="total">返回的总数</param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        Pager<T> Search(int pageSize, int pageIndex, Sql sql, string _connectionStrName = "");
        /// <summary>
        /// 获取当前对象的名称
        /// </summary>
        /// <returns></returns>
        string GetCurrName();

        /// <summary>
        /// 从实体中获取指定属性的值
        /// </summary>
        /// <param name="obj">实体</param>
        /// <param name="colName">属性名</param>
        /// <returns></returns>
        object GetValueFromObj(T obj, string colName = "Id");

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="sql">完整的SQL语句，【为了防止有特殊字符，条件中的值请调用ToValidDbValue方法】</param>
        /// <param name="_connectionStrName"></param>
        /// <returns></returns>
        DataTable GetData(string sql, string _connectionStrName = "");
    }
}
