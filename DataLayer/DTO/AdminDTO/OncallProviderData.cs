using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.AdminDTO
{
    public class OncallProviderData
    {
        public int ProviderId { get; set; }
        public string Name{ get; set; }
        public string Photo { get; set; }

        public int status { get; set; }

        public int regionId { get; set; }
    }
}
