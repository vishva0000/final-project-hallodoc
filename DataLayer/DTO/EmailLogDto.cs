using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO
{
    public class EmailLogDto
    {
        public string Template { get; set; }
        public string Subject { get; set; }
        public string EmailId { get; set; }
        public string ConfNumber { get; set; }
        public int RoleId { get; set; }
        public int RequestId { get; set; }
        public int AdminId { get; set; }
        public int PhysicianId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime SentDate { get; set; }
        public int Action { get; set; }
    }
}
