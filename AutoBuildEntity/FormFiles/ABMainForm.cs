using AutoBuildEntity.Common.Ext;
using AutoBuildEntity.Common.Helper;
using AutoBuildEntity.Model;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AutoBuildEntity.FormFiles
{

    public partial class ABMainForm : Form
    {

        string tag = "True";//Tag标签
        public AutoBuildEntityContent ABContent = null;
        public static DBInfoModel DBInfo = new DBInfoModel();
        public ABMainForm(AutoBuildEntityContent abContent)
        {
            InitializeComponent();
            ABContent = abContent;
            DBInfo = GetDBLink.GetBDList();
            BindData(DBInfo);
            OutputWindowHelper.OutPutMessage("数据已加载完成");
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="model"></param>
        /// <param name="tview"></param>
        private void BindData(DBInfoModel model)
        {
            foreach (DBInfo info in model.DBInfoList)
            {
                TreeNode node = new TreeNode();
                node.ImageKey = "database.png";
                node.SelectedImageKey = "database.png";
                node.Name = info.DBName;
                node.Text = info.DBName;
                foreach (var table in info.TableStruList.Select(s => s.TableName).Distinct())
                {
                    TreeNode subNode = new TreeNode()
                    {
                        Name = table,
                        Text = table,
                        ImageKey = "table.png",
                        SelectedImageKey = "table.png"
                    };
                    node.Nodes.Add(subNode);
                }
                tv_DBList.Nodes.Add(node);
            }
            cbx_Folder.DataSource = ABContent.SelectedProject.FolderNames;
        }

        #region CheckBox操作
        private void tv_DBList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                TreeNode node = e.Node;
                if (node.Tag == null)
                    node.Tag = tag;//附加结点信息
                else
                    node.Tag = null;

                CheckAllChildNodes(e.Node, e.Node.Checked);

                //选中父节点 
                bool bol = true;
                if (e.Node.Parent != null)
                {
                    for (int i = 0; i < e.Node.Parent.Nodes.Count; i++)
                    {
                        if (!e.Node.Parent.Nodes[i].Checked)
                            bol = false;
                    }
                    e.Node.Parent.Checked = bol;

                    ////记得如果父节点被选中或取消，记得设置它的tag哦
                    if (bol)
                    {
                        e.Node.Parent.Tag = tag;
                    }
                    else
                    {
                        e.Node.Parent.Tag = null;
                    }
                }
            }
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                node.Tag = tag;////记得在这里为选中的项目设置tag属性
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        #endregion

        /// <summary>
        /// 选中后数据查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tv_DBList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null) //判断选中节点是否有父节点
            {
                return;
            }
            bool hasControl = false;
            foreach (Control ctrol in tabControl1.Controls)
            {
                if (ctrol.Name == e.Node.Name)
                {
                    tabControl1.SelectedIndex = tabControl1.Controls.IndexOf(ctrol);
                    hasControl = true;
                }
            }
            if (hasControl == false)
            {
                TabPage tabpage = new TabPage(e.Node.Name);
                tabpage.Name = e.Node.Name;
                tabpage.AutoScroll = true;
                IList<DBStructure> ilist = new List<DBStructure>();
                var data = DBInfo.DBInfoList.Where(w => w.DBName == e.Node.Parent.Name).FirstOrDefault();
                var list = data.TableStruList.Where(w => w.TableName == e.Node.Name).ToList();
                DataGridView dgv = new DataGridView()
                {
                    Dock = DockStyle.Fill,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    DataSource = list.Select(s => new CHNDesc
                    {
                        列名 = s.ColName,
                        类型 = s.ColType,
                        长度 = s.ColLen.ToString(),
                        自增 = s.ColIsinc,
                        主键 = s.ColIsPri,
                        允许空 = s.ColisNull,
                        默认值 = s.DefaultValue,
                        描述 = s.ColDesc
                    }).ToList()
                };
                tabpage.Controls.Add(dgv);
                this.tabControl1.Controls.Add(tabpage);
                tabControl1.SelectedTab = tabpage;
            }
        }

        /// <summary>
        /// 数据执行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Build_Click(object sender, EventArgs e)
        {
            List<string> csFileList = new List<string>();
            var template = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Templates", "Entity.txt"));
            foreach (TreeNode tnode in this.tv_DBList.Nodes)
            {
                foreach (TreeNode node in tnode.Nodes)
                {
                    if (node.Checked)
                    {
                        var csFile = GetCSFile(node.Parent.Name, node.Name, template);
                        csFileList.Add(csFile);
                    }
                }
            }
            ABContent.SelectedProject.ProjectDte.AddFilesToProject(csFileList);
        }

        /// <summary>
        /// 获取CS文件
        /// </summary>
        /// <param name="parentName"></param>
        /// <param name="subName"></param>
        /// <param name="template"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private string GetCSFile(string parentName, string subName, string template, string entity = "Entity")
        {
            var csFile = string.Empty;
            try
            {
                List<DBStructure> infos = DBInfo.DBInfoList.Where(w => w.DBName == parentName).Select(s => s.TableStruList).FirstOrDefault();
                var info = infos.Where(w => w.TableName == subName).FirstOrDefault() ?? null;
                if (info == null)
                {
                    return csFile;
                }
                Dictionary<string, object> dicInfo = new Dictionary<string, object>();
                dicInfo.Add("Entity", info);
                dicInfo.Add("ClassLibrary", ABContent.SelectedProject.ProjectName);
                dicInfo.Add("FolderName", cbx_Folder.Text);
                var result = NVelocityHelper.ProcessTemplate(template, dicInfo);
                //string result = Engine.Razor.RunCompile(template, "template6111", null, dbs); razor 略卡
                csFile = FilesHelper.Write(Path.Combine(ABContent.SelectedProject.ProjectDirectoryName, cbx_Folder.Text), subName + "Entity.cs", result);
            }
            catch (Exception ex)
            {
                OutputWindowHelper.OutPutMessage($"获取CS文件出现异常 \n 信息：{ex.Message} \n 堆栈：{ex.StackTrace}");
            }
            return csFile;
        }

        private void 新建临时连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TempConnect().ShowDialog();
        }
    }
}
