using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.AdminDTO
{
    public class EmailLogData
    {
        public  string Recepient { get; set; }
        public string Email { get; set; }
        public int Action { get; set; }
        public bool EmailSent { get; set; }
        public int SentTries { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedDate{ get; set; }
        public DateTime SentDate{ get; set; }
        public string CNumber { get; set; }
    }
}
