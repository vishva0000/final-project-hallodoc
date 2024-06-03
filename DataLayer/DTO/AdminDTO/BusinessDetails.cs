using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.AdminDTO
{
    public class BusinessDetails
    {
        public int Businessid { get; set; }
        public string Name { get; set; }
        public string BusinessContact  { get; set; }
        public string Email { get; set; }
        public string FaxNumber { get; set; }
    }
}
