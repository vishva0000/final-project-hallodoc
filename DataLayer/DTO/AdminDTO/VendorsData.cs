using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.AdminDTO
{
    public class VendorsData
    {
        public int vendorId { get; set; }
        public string vendorName { get; set; }
        public string profession {get; set;}
        public string faxNumber {get; set;}
        public string email {get; set;}
        public string phoneNumber {get; set;}
        public string businessContact {get; set;}

    }
}
