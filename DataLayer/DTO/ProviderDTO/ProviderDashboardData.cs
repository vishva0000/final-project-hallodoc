using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.ProviderDTO
{
    public class ProviderDashboardData
    {
        public int New{ get; set; }
        public int Pending { get; set; }
        public int Active { get; set; }
        public int Conclude { get; set; }

    }
}
