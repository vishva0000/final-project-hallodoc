using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.AdminDTO
{
    public class BlockHistroyData
    {
        public int RequestId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Notes { get; set; }
        public bool isActive { get; set; }
    }
}
