using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using performance_monitor.Common;

namespace performance_monitor.Controllers
{
    [Route("api/[controller]")]
    public class GeneralController : Controller
    {
        private GetMainApplication _app = new GetMainApplication();

        public GeneralController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetProcessesData()
        {
            PerformanceCounter cpuCounter;
            PerformanceCounter ramCounter;

            cpuCounter = new PerformanceCounter("Process", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            cpuCounter.NextValue();
            await Task.Delay(500);
            return Ok(cpuCounter.NextValue());
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetProcessesData(string name)
        {
            PerformanceCounter cpuCounter;

            cpuCounter = new PerformanceCounter("Process", "% Processor Time", name);

            cpuCounter.NextValue();
            await Task.Delay(500);
            return Ok(cpuCounter.NextValue());
        }
    }
}