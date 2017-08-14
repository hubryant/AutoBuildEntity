using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using System.ComponentModel.Design;
using System.Collections.Generic;
using AutoBuildEntity.Model;
using EnvDTE;
using Microsoft.VisualStudio.Shell.Interop;
using AutoBuildEntity.Common.Ext;
using AutoBuildEntity.FormFiles;

namespace AutoBuildEntity
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(AutoBuildCommandPackage.PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class AutoBuildCommandPackage : Package
    {
        public const string PackageGuidString = "66914cb7-6126-4c24-80f0-3c8d49c2ba04";
        public const int CommandId = 0x0100;
        public static readonly Guid CommandSet = new Guid("99021ae8-6a78-4730-96c5-31ca6391ecfd");
        public AutoBuildCommandPackage()
        {
        }

        protected override void Initialize()
        {
            AutoBuildCommand.Initialize(this);
            base.Initialize();

            var mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (null != mcs)
            {
                var menuCommandId = new CommandID(CommandSet, CommandId);
                var menuItem = new OleMenuCommand(AutoBuildEntityEvent, menuCommandId);
                mcs.AddCommand(menuItem);
            }
        }
        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoBuildEntityEvent(object sender, EventArgs e)
        {
            var uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));

            //获取选中项目信息
            var autoBuildEntityContent = new AutoBuildEntityContent { SelectedProject = GetSelectedProject() };
            if (autoBuildEntityContent.SelectedProject == null)
            {
                uiShell.ShowMessageBox("获取项目信息失败");
                return;
            }
            new ABMainForm(autoBuildEntityContent).ShowDialog();
        }

        /// <summary>
        /// 获取选中的项目所有信息
        /// </summary>
        /// <returns></returns>
        private SelectedProject GetSelectedProject()
        {
            var dte = (DTE)GetService(typeof(SDTE));
            //获取选中项目信息
            var projectInfo = dte.GetSelectedProjectInfo();
            return projectInfo;
        }

        /// <summary>
        /// 获取选中的项目所有信息
        /// </summary>
        /// <returns></returns>
        private SelectedProjectFolder GetSelectedProjectFolder()
        {
            var dte = (DTE)GetService(typeof(SDTE));
            //获取选中项目信息
            var projectFolderInfo = dte.GetSelectedProjectFolderInfo();
            return projectFolderInfo;
        }

        /// <summary>
        /// 获取物理表
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        private List<string> GetTables(string sqlstr)
        {
            var dbTable = new DbTable(sqlstr);

            return dbTable.QueryTablesName();
        }
    }
}
