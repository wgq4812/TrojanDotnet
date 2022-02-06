using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using DapperExtensions;
using PublicLib;

namespace FiddlerDataAPI
{
    public class DapperHelper<T>
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private static readonly string connectionString = AppConfigurtaionServices.Configuration["AppSettings:SqlConn"];
        //private static readonly string connectionString = "Server=127.0.0.1;Database=shuigong;Uid=root;Pwd=123456;";

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="sql">查询的sql</param>
        /// <param name="param">替换参数</param>
        /// <returns></returns>
        public static List<T> Query(string sql, object param)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                return con.Query<T>(sql, param).ToList();
            }
        }

        /// <summary>
        /// 查询第一个数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T QueryFirst(string sql, object param)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                return con.QueryFirst<T>(sql, param);
            }
        }

        /// <summary>
        /// 查询第一个数据没有返回默认值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T QueryFirstOrDefault(string sql, object param)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                return con.QueryFirstOrDefault<T>(sql, param);
            }
        }

        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T QuerySingle(string sql, object param)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                return con.QuerySingle<T>(sql, param);
            }
        }

        /// <summary>
        /// 查询单条数据没有返回默认值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T QuerySingleOrDefault(string sql, object param)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                return con.QuerySingleOrDefault<T>(sql, param);
            }
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int Execute(string sql, object param)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                return con.Execute(sql, param);
            }
        }

        /// <summary>
        /// 根据实体类插入表（实体类需要加标记处理）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public static async Task<int> InsertAsync<T>(T model, IDbTransaction transaction = null, int? commandTimeout = null) where T : class, new()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return await conn.InsertAsync<T>(model, transaction, commandTimeout);
            }
        }

        /// <summary>
        /// 根据实体类更新表（实体类需要加标记处理）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public static async Task<bool> UpdateAsync<T>(T model, IDbTransaction transaction = null, int? commandTimeout = null) where T : class, new()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                bool b = await conn.UpdateAsync<T>(model, transaction, commandTimeout);
                return b;
            }
        }
        /// <summary>
        /// 根据实体类删除表（实体类需要加标记处理）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public static async Task<bool> DeleteAsync<T>(T model, IDbTransaction transaction = null, int? commandTimeout = null) where T : class, new()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                bool b = await conn.DeleteAsync<T>(model, transaction, commandTimeout);
                return b;
            }
        }

        /// <summary>
        /// Reader获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static IDataReader ExecuteReader(string sql, object param)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                return con.ExecuteReader(sql, param);
            }
        }

        /// <summary>
        /// Scalar获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, object param)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                return con.ExecuteScalar(sql, param);
            }
        }

        /// <summary>
        /// Scalar获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T ExecuteScalarForT(string sql, object param)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                return con.ExecuteScalar<T>(sql, param);
            }
        }

        /// <summary>
        /// 带参数的存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static List<T> ExecutePro(string proc, object param)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                List<T> list = con.Query<T>(proc,
                    param,
                    null,
                    true,
                    null,
                    CommandType.StoredProcedure).ToList();
                return list;
            }
        }


        /// <summary>
        /// 事务1 - 全SQL
        /// </summary>
        /// <param name="sqlarr">多条SQL</param>
        /// <param name="param">param</param>
        /// <returns></returns>
        public static int ExecuteTransaction(string[] sqlarr)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        int result = 0;
                        foreach (var sql in sqlarr)
                        {
                            result += con.Execute(sql, null, transaction);
                        }

                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// 事务2 - 声明参数
        ///demo:
        ///dic.Add("Insert into Users values (@UserName, @Email, @Address)",
        ///        new { UserName = "jack", Email = "380234234@qq.com", Address = "上海" });
        /// </summary>
        /// <param name="Key">多条SQL</param>
        /// <param name="Value">param</param>
        /// <returns></returns>
        public static int ExecuteTransaction(Dictionary<string, object> dic)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        int result = 0;
                        foreach (var sql in dic)
                        {
                            result += con.Execute(sql.Key, sql.Value, transaction);
                        }

                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
        }
    }

}
