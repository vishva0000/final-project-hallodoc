using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.ProviderDTO
{
    public class ConcludeCareData
    {
        public int requestid { get; set; }
        public string name { get; set; }    
        
        public List<IFormFile> filesToUpload { get; set; }
        public List<allfiles> files { get; set; }
        
        public string notes { get; set; }
      
    }
    public class allfiles
    {
        public string filename { get; set; }
        public int fileid { get; set; }

    }
}
