using EnvDTE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AutoBuildEntity.Model
{
    /// <summary>
    /// 上下文
    /// </summary>
    public class AutoBuildEntityContent
    {
        /// <summary>
        /// 选中项目
        /// </summary>
        public SelectedProject SelectedProject { get; set; }

        /// <summary>
        /// 选中文件夹
        /// </summary>
        public SelectedProjectFolder SelectedProjectFolder { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public List<string> TablesName { get; set; }
    }
}
