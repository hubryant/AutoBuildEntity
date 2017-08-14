using AutoBuildEntity.Common.EnumFolder;
using AutoBuildEntity.Common.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AutoBuildEntity.Model
{
    /// <summary>
    /// 物理表的列信息
    /// </summary>
    public class TableColumn
    {
        private readonly string _connStr;
        public TableColumn()
        {

        }
        public TableColumn(string connStr)
        {
            _connStr = connStr;
        }

        public string TableName { get; private set; }

        public string Name { get; private set; }

        public string Remark { get; private set; }

        public string Type { get; private set; }

        public int Length { get; private set; }

        public bool IsIdentity { get; private set; }

        public bool IsKey { get; private set; }

        public bool IsNullable { get; private set; }

        public string CSharpType
        {
            get
            {
                return SqlHelper.MapCsharpType(Type, IsNullable);
            }
        }

        /// <summary>
        /// 查询列信息
        /// </summary>
        /// <param name="tablesName"></param>
        /// <returns></returns>
        public List<TableColumn> QueryColumn(DBInfoModel model, DBEnum dbenum)
        {
            DataTable table = new DataTable();
            if (dbenum == DBEnum.SqlServer)
            {
                //var table 
            }
            else if (dbenum == DBEnum.MySQL)
            {

            }
            //var result = new SqlHelper(_connStr).ExecuteDataTable(sql, paramVal);

            //return (from DataRow row in result.Rows
            //        select new TableColumn
            //        {
            //            IsIdentity = Convert.ToBoolean(row["isidentity"]),
            //            IsKey = Convert.ToBoolean(row["iskey"]),
            //            IsNullable = Convert.ToBoolean(row["isnullable"]),
            //            Length = Convert.ToInt32(row["length"]),
            //            Name = row["name"].ToString(),
            //            Remark = row["remark"].ToString(),
            //            TableName = row["tablename"].ToString(),
            //            Type = row["type"].ToString()
            //        }).ToList();
            return null;
        }
    }
}
