using Microsoft.AspNetCore.Mvc;
using performance_monitor.Common;
using performance_monitor.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Timers;

namespace performance_monitor.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private GetMainApplication _app = new GetMainApplication();

        public DataController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetProcessesData()
        {
            Dictionary<string, int> procs = _app.RunningProcess();
            ProcessData[] response = new ProcessData[procs.Count];
            int i = 0;

            foreach (KeyValuePair<string, int> ele1 in procs)
            {
                PerformanceCounter cpuCounter;

                cpuCounter = new PerformanceCounter("Process", "% Processor Time", ele1.Key);

                cpuCounter.NextValue();
                await Task.Delay(500);

                response[i] = new ProcessData(ele1.Key, cpuCounter.NextValue());
                i++;
            }
            return Ok(response);
        }
    }
}