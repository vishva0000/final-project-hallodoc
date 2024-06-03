using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.AdminDTO
{
    public  class ShiftTableData
    {
        public string phyName { get; set; }
        public DateTime shiftDate { get; set; }
        public TimeOnly startTime { get; set; }
        public TimeOnly endTime { get; set; }
        public string region { get; set; }
        public int shiftId { get; set; }
    }
}
