using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatencyDemo.FnApp.Data
{
    internal class LatencyTestRun
    {
        public int Id { get; set; }
        public String CorrelationId { get; set; }
        public string FromRegion { get; set; }
        public string ToRegion { get; set; }
        public int TimeTakenMS { get; set; }
        public DateTime Created { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Request { get; set; }
    }
}
