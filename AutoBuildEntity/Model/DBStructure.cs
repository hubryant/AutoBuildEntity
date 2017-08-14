using AutoBuildEntity.Common.EnumFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBuildEntity.Model
{
    [Serializable]
    public class DBStructure
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 列名
        /// </summary>
        public string ColName { get; set; }
        /// <summary>
        /// 列描述
        /// </summary>
        public string ColDesc { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string ColType { get; set; }
        /// <summary>                                         
        /// 长度
        /// </summary>
        public long ColLen { get; set; }
        /// <summary>
        /// 是否自增
        /// </summary>
        public string ColIsinc { get; set; }
        /// <summary>
        /// 是否主键
        /// </summary>
        public string ColIsPri { get; set; }
        /// <summary>
        /// 是否允许空
        /// </summary>
        public string ColisNull { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        public DBStructure()
        {
            TableName = string.Empty;
            ColName = string.Empty;
            ColDesc = string.Empty;
            ColName = string.Empty;
            ColType = string.Empty;
            ColLen = 0;
            DefaultValue = string.Empty;
        }
    }
}
