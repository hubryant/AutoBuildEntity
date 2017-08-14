using AutoBuildEntity.Common.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AutoBuildEntity.Model
{
    /// <summary>
    /// 物理表
    /// </summary>
    public class DbTable
    {
        public string TableName { get; private set; }

        public List<TableColumn> Columns { get; set; }

        private readonly string _conn;

        public DbTable(string conn)
        {
            _conn = conn;
        }

        public DbTable(string tableName, List<TableColumn> columns)
        {
            TableName = tableName;
            Columns = columns;
        }

        public List<string> QueryTablesName()
        {
            var result = new SqlHelper(_conn).ExecuteDataTable(@"SELECT  name FROM    sysobjects WHERE  xtype IN ( 'u','v' ); ");

            return (from DataRow row in result.Rows select row[0].ToString()).ToList();
        }

        public List<DbTable> GetTables(List<string> tablesName)
        {
            //if (!tablesName.Any())
            //    return new List<DbTable>();

            //var t = new TableColumn(_conn);

            //var columns = t.QueryColumn(tablesName);

            //return columns.GroupBy(a => a.TableName).Select(a => new DbTable(a.Key, a.ToList())).ToList();
            return null;
        }

    }
}
