using Dapper;
using System;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApplication.Repository
{
    public static class DapperExtension
    {

        public static bool ExecuteWithStatus(this IDbConnection con, string query, object param = null, IDbTransaction dbTransaction = null, int? commandTimeout = null, CommandType commandType = CommandType.Text)
        {
            bool result = false;
            int effectedRow = con.Execute(query, param, dbTransaction, commandTimeout, commandType);
            if (effectedRow > 0)
                result = true;
            return result;
        }
        public static T ExecuteWithScalar<T>(this IDbConnection con, string query, object param = null, IDbTransaction dbTransaction = null, int? commandTimeout = null, CommandType commandType = CommandType.Text)
        {
            T result = default(T);
            T Id = default(T);
            Type type = param.GetType();
            if (param is DynamicParameters)
            {
                Id = ((DynamicParameters)param).Get<T>("Id");

            }
            else
            {
                PropertyInfo property = type.GetProperty("Id");
                Id = (T)property.GetValue(param);
            }

            if (Id.ToString() == "0")
            {
                query += "  select LAST_INSERT_ID();";
                result = con.ExecuteScalar<T>(query, param, dbTransaction, commandTimeout, commandType);
            }
            else
            {

                int effectedRow = con.Execute(query, param, dbTransaction, commandTimeout, commandType);
                if (effectedRow > 0)
                {
                    result = Id;
                }
            }

            return result;
        }

        public static async Task<bool> ExecuteWithStatusAsync(this IDbConnection con, string query, object param = null, IDbTransaction dbTransaction = null, int? commandTimeout = null, CommandType commandType = CommandType.Text)
        {
            bool result = false;
            int effectedRow = await con.ExecuteAsync(query, param, dbTransaction, commandTimeout, commandType);
            if (effectedRow > 0)
                result = true;
            return result;
        }

        public static async Task<T> ExecuteWithScalarAsync<T>(this IDbConnection con, string query, object param = null, IDbTransaction dbTransaction = null, int? commandTimeout = null, CommandType commandType = CommandType.Text)
        {
            T result = default(T);
            T Id = default(T);
            Type type = param.GetType();
            if (param is DynamicParameters)
            {
                Id = ((DynamicParameters)param).Get<T>("Id");

            }
            else
            {
                PropertyInfo property = type.GetProperty("Id");
                Id = (T)property.GetValue(param);
            }
            if (Id.ToString() == "0")
            {
                query += "  select LAST_INSERT_ID();";
                result = await con.ExecuteScalarAsync<T>(query, param, dbTransaction, commandTimeout, commandType);
            }
            else
            {

                int effectedRow = await con.ExecuteAsync(query, param, dbTransaction, commandTimeout, commandType);
                if (effectedRow > 0)
                {
                    result = Id;
                }
            }

            return result;
        }
    }
}
