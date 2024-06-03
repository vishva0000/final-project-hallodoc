using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.AdminDTO
{
    public class PatientRecordData
    {
        public int requestId { get; set; }
        public string Name { get; set;}
        public DateTime CreatedDate { get; set;}
        public string ConfirmationNumber { get; set;}
        public string ProviderName { get; set;}
        public DateTime ConcludeDate { get; set;}
        public int Status { get; set;}
        public int DocCount { get; set; }
    }
}
