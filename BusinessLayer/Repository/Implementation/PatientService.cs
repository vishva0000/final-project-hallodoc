using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interface;
using DataLayer.DTO;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BusinessLayer.Repository.Implementation
{
    public class PatientService : IPatientService
    {
        public HallodocContext db;
        public readonly IHostingEnvironment _environment;

        public PatientService(HallodocContext db, IHostingEnvironment environment)
        {
            _environment = environment;
            this.db = db;

        }

        public void ResetPassword(string mail, string password)
        {
            var data = db.AspNetUsers.Where(a => a.Email == mail).FirstOrDefault();
            data.PasswordHash = password;
            db.Update(data);
            db.SaveChanges();

        }

        public bool IsPatientPresent(string email)
        {
            var data = db.AspNetUsers.Where(a => a.Email == email).FirstOrDefault();
            if (data == null)
            {
                return false;
            }
            
                return true;

          
        }

        public void CreatePatient(CreatePatient model)
        {

            AspNetUser insertuser = new AspNetUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Email,
                Email = model.Email,
                PasswordHash = model.Password,
                CreatedDate = DateTime.Now
            };
            db.AspNetUsers.Add(insertuser);
            var requets = db.Requests.Where(a => a.RequestClients.Any(c => c.Email == model.Email)).ToList();
            var patient = db.RequestClients.Where(a => a.Email == model.Email).FirstOrDefault();
            User user = new User()
            {
                AspNetUserId = insertuser.Id,
                FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Email = model.Email,
                    Mobile = patient.PhoneNumber,
                    Street = patient.Street,
                    City = patient.City,
                    State = patient.State,
                    ZipCode = patient.ZipCode,
                    StrMonth = patient.StrMonth,
                    IntYear = patient.IntYear,
                    IntDate = patient.IntDate,
                    CreatedDate = DateTime.Now,
                    CreatedBy = insertuser.Id
            };

            foreach(var item in requets)
            {
                item.User = user;
                db.Requests.Update(item);
            }

            db.Users.Add(user);
            db.SaveChanges();

        }

        public List<PatientDashboard> GetPatientDashboardData(string email)
        {
            List<PatientDashboard> data = new();
            var details = db.Requests.Where(a => a.RequestClients.Any(b=>b.Email == email)).Include(a => a.RequestWiseFiles);

            foreach (var item in details)
            {
                PatientDashboard dashboard = new PatientDashboard()
                {
                    CreatedDate = item.CreatedDate,
                    status = item.Status,
                    count = item.RequestWiseFiles.Count,
                    RequestID = item.RequestId
                };
                data.Add(dashboard);
            }
            return data;
        }

        public PatientProfile GetPatientProfile(string email)
        {
            PatientProfile model = new PatientProfile();
            var details = db.Users.Where(a => a.Email == email).Include(a => a.Requests).FirstOrDefault();

            if (details.IntYear != null && details.IntDate != null && details.StrMonth != null)
            {
                int month = DateTime.ParseExact(details.StrMonth, "MMMM", CultureInfo.CurrentCulture).Month;
                model.dob = new DateTime((int)details.IntYear, month, (int)details.IntDate);
            }

            model.Firstname = details.FirstName;
            model.Lastname = details.LastName;
            model.phone = details.Mobile;
            model.email = details.Email;
            model.street = details.Street;
            model.city = details.City;
            model.state = details.State;
            model.zipcode = details.ZipCode;

            return model;

        }

        public void EditPatientProfile(string email, PatientProfile model)
        {
            var details = db.Users.Where(a => a.Email == email).FirstOrDefault();
            var dob = model.dob;
            int day = dob.Day;
            var mon = dob.ToString("MMMM");
            var year = dob.Year;

            details.FirstName = model.Firstname;
            details.LastName = model.Lastname;
            details.Mobile = model.phone;
            details.Email = model.email;
            details.Street = model.street;
            details.City = model.city;
            details.State = model.state;
            details.ZipCode = model.zipcode;
            details.StrMonth = mon;
            details.IntDate = day;
            details.IntYear = year;

            db.Users.Update(details);
            db.SaveChanges();

        }

        public ViewDocumentList GetDocuments(int RequestID)
        {
            var file = db.RequestWiseFiles.Where(a => a.RequestId == RequestID);
            var req = db.Requests.Where(a => a.RequestId == RequestID).FirstOrDefault();
            var name = db.RequestClients.Where(a => a.RequestId == RequestID).FirstOrDefault();
            List<FileData> data = new();

            foreach (var files in file)
            {
                FileData FileDataList = new()
                {
                    FileName = files.FileName.Split('\\').Last(),
                    CreatedBy = name.FirstName,
                    CreatedDate = files.CreatedDate,
                    DocumentId = files.RequestWiseFileId

                };
                data.Add(FileDataList);
            }
            ViewDocumentList doc = new()
            {
                Name = name.FirstName,
                ConfirmationNumber = req.ConfirmationNumber,
                Document = data,
                RequestId = RequestID

            };

            return doc;
        }

        public string GetFilePath(int id)
        {
            string data = db.RequestWiseFiles.Where(a => a.RequestWiseFileId == id).FirstOrDefault().FileName;
            return data;
        }

        public void UploadFile(IFormFile file, int reqid)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, file.FileName);


            file.CopyTo(new FileStream(filePath, FileMode.Create));
            RequestWiseFile insertfile = new RequestWiseFile()
            {
                RequestId = reqid,
                FileName = filePath,
                CreatedDate = DateTime.Now,
                IsDeleted = new BitArray(new bool[1] { false })

            };
            db.RequestWiseFiles.Add(insertfile);
            db.SaveChanges();
        }

        public int GetUserId(int id)
        {
            return (int)db.Requests.Where(a => a.RequestId == id).FirstOrDefault().UserId;
        }
        public int GetUserIdByMail(string email)
        {
            return db.Users.Where(a => a.Email == email).FirstOrDefault().UserId;
        }

        public int GetReqStatus(int id)
        {
            return db.Requests.Where(a => a.RequestId == id).FirstOrDefault().Status;
        }

        public void Agree(int reqid)
        {
            var data = db.Requests.Where(a => a.RequestId == reqid).FirstOrDefault();
            data.Status = 4;

            RequestStatusLog statuslog = new RequestStatusLog();
            statuslog.Status = 4;
            statuslog.RequestId = reqid;
            statuslog.CreatedDate = DateTime.Now;


            db.Requests.Update(data);
            db.RequestStatusLogs.Add(statuslog);
            db.SaveChanges();
        }

        public void CancelAgreement(string cancelnote,int reqid)
        {
            var data = db.Requests.Where(a => a.RequestId == reqid).FirstOrDefault();
            data.Status = 3;

            RequestStatusLog statuslog = new RequestStatusLog();
            statuslog.Status = 3;
            statuslog.RequestId = reqid;
            statuslog.Notes = cancelnote;
            statuslog.CreatedDate = DateTime.Now;

            db.Requests.Update(data);
            db.RequestStatusLogs.Add(statuslog);
            db.SaveChanges();
        }

        public void RequestForElse(RequestForSomeoneElse model)
        {
            var dob = model.dob;
            int day = dob.Day;
            var mon = dob.ToString("MMMM");
            var year = dob.Year;
            var email = model.Email;

            Request insertrequest = new Request()
            {
                RequestTypeId = 3,
                FirstName = model.Firstname,
                LastName = model.Lastname,
                PhoneNumber = model.Phone,
                Email = model.Email,
                Status = 1,
                CreatedDate = DateTime.Now,
                IsUrgentEmailSent = new BitArray(new bool[1] { false })

            };
            db.Requests.Add(insertrequest);

            RequestClient insertrequestclient = new RequestClient()
            {
                Request = insertrequest,
                FirstName = model.Firstname,
                LastName = model.Lastname,
                PhoneNumber = model.Phone,
                Email = model.Email,
                IntDate = day,
                StrMonth = mon,
                IntYear = year,
                Street = model.Street,
                State = model.State,
                City = model.City,
                ZipCode = model.Zipcode

            };
            db.RequestClients.Add(insertrequestclient);

            if (model.File != null)
            {

                var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, model.File.FileName);
                var file = model.File;

                file.CopyTo(new FileStream(filePath, FileMode.Create));
                RequestWiseFile insertfile = new RequestWiseFile()
                {
                    Request = insertrequest,
                    FileName = filePath,
                    CreatedDate = DateTime.Now,
                    IsDeleted = new BitArray(new bool[1] { false })


                };
                db.RequestWiseFiles.Add(insertfile);

            }
            db.RequestClients.Add(insertrequestclient);
            db.SaveChanges();
        }

        public AspNetUser GetAspNetUser(string email)
        {
            return db.AspNetUsers.Where(a => a.Email == email).FirstOrDefault();
        }

        public AspNetUser GetUserType(string email, string role)
        {
            return db.AspNetUsers.Where(context => context.Email == email).Include(a => a.Roles).Where(a => a.Roles.Select(b => b.Name).Contains(role)).FirstOrDefault();
        }

        public Physician GetPhysician(string id)
        {
            return db.Physicians.Where(a => a.AspNetUserId == id).FirstOrDefault();
        }

        public Admin GetAdmin(string id)
        {
            return db.Admins.Where(a => a.AspNetUserId == id).FirstOrDefault();
        }

        public User GetUser(string id)
        {
            return db.Users.Where(a => a.AspNetUserId == id).FirstOrDefault();
        }

    }
}
