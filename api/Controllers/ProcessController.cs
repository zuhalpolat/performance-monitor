using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using performance_monitor.Common;
using performance_monitor.Models;

namespace performance_monitor.Controllers
{
    [Route("api/[controller]")]
    public class ProcessController : Controller
    {
        private GetMainApplication _app = new GetMainApplication();
        public ProcessController()
        {
        }


        [HttpGet]
        public IActionResult GetProcesses()
        {

            Dictionary<string, int> procs = _app.RunningProcess();
            ProcessDTO[] response = new ProcessDTO[procs.Count];
            int i = 0;
            

            foreach (KeyValuePair<string, int> ele1 in procs)
            {
                response[i] = new ProcessDTO(ele1.Value, ele1.Key, true);
                i++;
            }
            return Ok(response);
        }

        [HttpPut("{name}")]
        public IActionResult Message(string name, [FromBody] ProcessMessage msg)
        {
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                if(process.ProcessName.Contains(msg.Name))
                {
                    process.Kill();
                    return Ok();
                }
            }

            return BadRequest();
        }
    }
}