using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interface;
using DataLayer.DTO.ProviderDTO;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementation
{
    public class ConcludeCare : IConcludeCare
    {
        public HallodocContext db;

        public ConcludeCare(HallodocContext context)
        {
            this.db = context;

        }
        public ConcludeCareData getData(int reqid)
        {
              ConcludeCareData obj = new ConcludeCareData();
            var req = db.Requests.Where(a=>a.RequestId== reqid).Include(a=>a.RequestClients).FirstOrDefault();
            obj.name = req.RequestClients.FirstOrDefault().FirstName + " " + req.RequestClients.FirstOrDefault().LastName;
            obj.requestid = reqid;
            var file = db.RequestWiseFiles.Where(a => a.RequestId == reqid).ToList();
            List<allfiles> filelist = new();
            foreach(var item in file)
            {
                allfiles f = new allfiles()
                {
                    fileid = item.RequestWiseFileId,
                    filename = item.FileName.Split('\\').Last()
                };
                filelist.Add(f);
            }

            obj.files = filelist;
            
            return obj;
        }

        public void concludetherequest(int reqid, string usermail, string note)
        {
            int id = db.Physicians.Where(a => a.Email == usermail).FirstOrDefault().PhysicianId;
            var req = db.Requests.Where(a => a.RequestId == reqid).FirstOrDefault();
            req.Status = 8;
            req.AcceptedDate = DateTime.Now;
            RequestStatusLog data = new RequestStatusLog();
            data.RequestId = reqid;
            data.Notes = note;
            data.CreatedDate = DateTime.Now;
            data.PhysicianId = id;

            db.RequestStatusLogs.Add(data);

            db.Requests.Update(req);
            db.SaveChanges();
        }
    }
}
