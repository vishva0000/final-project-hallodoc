using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.AdminDTO
{
    public class ValidShiftsData
    {
        public int providerid { get; set; }
        public DateTime shiftdate { get; set; }
        public TimeOnly starttime { get; set; }
        public TimeOnly endtime { get; set; }

        public int repeatupto { get; set; }
        public int regionid { get; set; }

    }
}
