using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace performance_monitor.Common
{
    public class GetMainApplication
    {
        public Dictionary<string, int> RunningProcess() {

            Process[] processes = Process.GetProcesses();

            Dictionary<string, int> procs = new Dictionary<string, int>();

            foreach (Process process in processes)
            {
                process.Refresh();

                if(!string.IsNullOrEmpty(process.MainWindowTitle))
                {
                    if (procs.ContainsKey(process.ProcessName))
                    {
                        var value = procs.FirstOrDefault(x => x.Key == process.ProcessName).Value;
                        procs[process.ProcessName] = ++value;
                    }
                    else
                    {
                        procs.Add(process.ProcessName, 1);
                    }
                }
            }
            return procs;
        }
    }
}