using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace performance_monitor.Models
{
    public class ProcessData
    {
        public ProcessData(string name, float value)
        {
            this.Name = name;
            this.Value = value;

        }
        public string Name { get; set; }
        public float Value { get; set; }
    }
}