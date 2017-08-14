using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBuildEntity.Common.Helper
{
    public static class OutputWindowHelper
    {
        #region OutputWindow
        /// <summary>
        /// 向Output Window 写入信息
        /// </summary>
        /// <param name="Message"></param>
        public static void OutPutMessage(string Message)
        {
            OutPutMessage(Message, false);
        }
        /// <summary>
        /// 向Output Window 写入信息
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="IsClear">IsClear</param>
        public static void OutPutMessage(string Message, bool IsClear)
        {
            IVsOutputWindow outWindow = Package.GetGlobalService(typeof(SVsOutputWindow)) as IVsOutputWindow;
            //Guid generalWindowGuid = VSConstants.GUID_OutWindowGeneralPane;
            //IVsOutputWindowPane windowPane;
            //outWindow.GetPane(ref generalWindowGuid, out windowPane);
            Guid guidOutPut = new Guid();

            outWindow.CreatePane(ref guidOutPut, "AutoBuildEntity", 1, 0);
            IVsOutputWindowPane windowPane;
            outWindow.GetPane(ref guidOutPut, out windowPane);

            if (IsClear) windowPane.Clear();
            //激活窗体  ？有问题
            windowPane.Activate();
            windowPane.OutputString(Message + "\n");

        }
        #endregion
    }
}
