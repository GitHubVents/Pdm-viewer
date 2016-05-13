using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DxfAndPDFViewer.Classes
{
    class MyPrograms
    {
        SldWorks swApp;
        public MyPrograms()
        {
        }
        public MyPrograms(SldWorks swApp)
        {
            this.swApp = swApp;
        }
        protected Process[] GetAndStartProcess(string processName, string fileName)
        {
            var processes = Process.GetProcessesByName(processName);
            //if (processes.Length != 0)
            //{
                Process.Start(fileName);
            //}
            return processes;
        }
        public void FindAndKillProcess(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            if (processes.Length != 0)
            {
                foreach (var process in processes)
                {
                    process.Kill();
                }
            }
        }
    }
}