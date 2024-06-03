using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.AdminDTO
{
    public class shift
    {
        public string regionName { get; set; }
        public int regionid { get; set; }
        public int shiftid { get; set; }
        public int phyid { get; set; }
        public string phyname { get; set; }
        public DateTime shiftDate { get; set; }
        public string date { get; set; }
        public TimeOnly startTime { get; set; }
        public TimeOnly endTime { get; set; }
    }
}
