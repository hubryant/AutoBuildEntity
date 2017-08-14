using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using AutoBuildEntity.Model;
using Microsoft.VisualStudio.Shell.Interop;
using EnvDTE;
using System.Collections.Generic;
using AutoBuildEntity.Common.Ext;

namespace AutoBuildEntity
{
    internal sealed class AutoBuildCommand
    {
        public const int CommandId = 0x0100;
        public static readonly Guid CommandSet = new Guid("99021ae8-6a78-4730-96c5-31ca6391ecfd");
        private readonly Package package;

        private AutoBuildCommand(Package package)
        {
            //if (package == null)
            //{
            //    throw new ArgumentNullException("package");
            //}

            //this.package = package;

            //OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            //if (commandService != null)
            //{
            //    var menuCommandID = new CommandID(CommandSet, CommandId);
            //    var menuItem = new MenuCommand(this.StartBuild, menuCommandID);
            //    commandService.AddCommand(menuItem);
            //}
        }

        public static AutoBuildCommand Instance
        {
            get;
            private set;
        }

        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        public static void Initialize(Package package)
        {
            Instance = new AutoBuildCommand(package);
        }

        private void StartBuild(object sender, EventArgs e)
        {
        }
    }
}
