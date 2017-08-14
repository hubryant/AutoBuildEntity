using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBuildEntity.Model
{
    public class CHNDesc
    {
        public string 列名 { get; set; } = string.Empty;
        public string 类型 { get; set; } = string.Empty;
        public string 长度 { get; set; } = string.Empty;
        public string 自增 { get; set; } = string.Empty;
        public string 主键 { get; set; } = string.Empty;
        public string 允许空 { get; set; } = string.Empty;
        public string 默认值 { get; set; } = string.Empty;
        public string 描述 { get; set; } = string.Empty;
    }
}
