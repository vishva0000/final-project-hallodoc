using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.ProviderDTO
{
    public class ProviderRequestData
    {
        public int? RequestId { get; set; }
        public int RequestTypeId { get; set; }

        public string Name { get; set; }
        public string PhoneP { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }
        public int status { get; set; }

        public int typeofcare { get; set; }
    }
}
