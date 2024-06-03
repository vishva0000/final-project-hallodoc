using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interface;
using DataLayer.DTO.AdminDTO;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BusinessLayer.Repository.Implementation
{
    public class ViewUploads : IViewUploads
    {
        public HallodocContext db;
        public readonly IHostingEnvironment _environment;
            
        public ViewUploads(HallodocContext context, IHostingEnvironment environment) 
        {
            _environment = environment;
            this.db = context;
        }
        public ViewUploadsModel Uploadedfilesdata(int viewid)
        {
            ViewUploadsModel details = new ViewUploadsModel();

            List<FileData> files = new();

            details.name = db.Requests.Where(a => a.RequestId == viewid).FirstOrDefault().FirstName + " " + db.Requests.Where(a => a.RequestId == viewid).FirstOrDefault().LastName;
            details.reqid = viewid;
            var data = db.RequestWiseFiles.Where(a => a.RequestId == viewid ).ToList().Where(a=>!a.IsDeleted.Get(0)).ToList();
            foreach (var item in data)
            {
                FileData fileup = new FileData();

                fileup.file = item.FileName;
                //fileup.file = item.FileName;
                fileup.createdate = item.CreatedDate;
                fileup.docid = item.RequestWiseFileId;
                files.Add(fileup);
            }
            details.filedata = files;

            return details;
        }

        public string GetFilepath(int docid)
        {
            var data = db.RequestWiseFiles.Where(a => a.RequestWiseFileId == docid).FirstOrDefault();
            string filePath = data.FileName;
            return filePath;
        }

        public void DeleteFile(int fileid)
        {
            var data = db.RequestWiseFiles.Where(a => a.RequestWiseFileId == fileid).FirstOrDefault();
            data.IsDeleted = new BitArray(new bool[1] { true });

            db.RequestWiseFiles.Update(data);
            db.SaveChanges();

        }

        public void AddFiles(List<IFormFile> file, int reqid)
        {
            foreach (var item in file)
            {
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, item.FileName);


                item.CopyTo(new FileStream(filePath, FileMode.Create));
                RequestWiseFile insertfile = new RequestWiseFile()
                {
                    RequestId = reqid,
                    FileName = filePath,
                    CreatedDate = DateTime.Now,
                    IsDeleted = new BitArray(new bool[1] { false })
                };
                db.RequestWiseFiles.Add(insertfile);
            }

            db.SaveChanges();
        }
    }
}
