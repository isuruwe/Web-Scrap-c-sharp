using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler
{
    public class TaskData
    {
        public int UId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int MethodActionUId { get; set; }
        public bool Active { get; set; }
        public int Code { get; set; }
    }
}
