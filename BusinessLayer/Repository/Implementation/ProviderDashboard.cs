using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interface;
using BusinessLayer.Repository.IRepository;
using DataLayer.DTO.AdminDTO;
using DataLayer.DTO.ProviderDTO;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace BusinessLayer.Repository.Implementation
{
    public class ProviderDashboard : IProviderDashboard
    {
        public HallodocContext db;
        public readonly IHostingEnvironment _environment;

        public ProviderDashboard(HallodocContext context, IHostingEnvironment environment)
        {
            this.db = context;
            _environment = environment; 
        }

        public ProviderDashboardData Count(string usermail)
        {
            int id = db.Physicians.Where(a => a.Email == usermail).FirstOrDefault().PhysicianId;
            ProviderDashboardData obj = new ProviderDashboardData()
            {
                 
                New = db.Requests.Where(a =>(a.Status == 1) && (a.PhysicianId == id) &&( a.PhysicianId == id) && (new BitArray(1, false) == a.IsDeleted)).Count(),
                Pending = db.Requests.Where(a =>( a.Status == 2) &&( a.PhysicianId == id) && (new BitArray(1, false) == a.IsDeleted)).Count(),
                Active = db.Requests.Where(a => (a.Status == 4) || (a.Status == 5) && (a.PhysicianId == id) && (new BitArray(1, false) == a.IsDeleted)).Count(),
                Conclude = db.Requests.Where(a => (a.Status == 6) && ( a.PhysicianId == id) && (new BitArray(1, false) == a.IsDeleted)).Count(),
                
            };
            return obj;
        }

        public List<ProviderRequestData> getRequestsForPhysician(int status, int requesttype, string search, string usermail)
        {
            int id = db.Physicians.Where(a => a.Email == usermail).FirstOrDefault().PhysicianId;

            List<ProviderRequestData> data = new();
            List<Request> r;

            var phy = db.Physicians;
            if (requesttype == 0)
            {
                if (status == 1)
                {
                    var my = db.Requests.Where(a => (a.Status == 1) && (a.PhysicianId == id) && (new BitArray(1, false) == a.IsDeleted)).Include(b => b.RequestClients).ToList();
                    var mydata = my.Where(a =>
                        search.IsNullOrEmpty() ||
                        a.RequestClients.FirstOrDefault()!.FirstName!.Contains(search, StringComparison.CurrentCultureIgnoreCase) ||
                        a.RequestClients.FirstOrDefault()!.LastName!.Contains(search, StringComparison.CurrentCultureIgnoreCase));

                    foreach (var item in mydata)
                    {
                        var patient = db.RequestClients.Where(a => a.RequestId == item.RequestId).FirstOrDefault();

                        ProviderRequestData request = new ProviderRequestData();
                        if (patient.IntYear != null && patient.IntDate != null && patient.StrMonth != null)
                        {
                            int month = DateTime.ParseExact(patient.StrMonth, "MMMM", CultureInfo.CurrentCulture).Month;
                            request.Dob = new DateTime((int)patient.IntYear, month, (int)patient.IntDate);
                        }
                        request.status = 1;
                        request.RequestId = item.RequestId;
                        request.RequestTypeId = item.RequestTypeId;
                        request.Name = patient.FirstName + ", " + patient.LastName;
                        request.Address = patient.Street + " " + patient.City + " " + patient.State;
                        request.PhoneP = patient.PhoneNumber;
                        request.Email = patient.Email;
                  

                        data.Add(request);
                    }
                }
                else if (status == 2)
                {
                    var my = db.Requests.Where(a => (a.Status == 2) && (a.PhysicianId == id)  && (new BitArray(1, false) == a.IsDeleted)).Include(b => b.RequestClients).ToList();
                    var mydata = my.Where(a =>
                        search.IsNullOrEmpty() ||
                        a.RequestClients.FirstOrDefault()!.FirstName!.Contains(search, StringComparison.CurrentCultureIgnoreCase) ||
                        a.RequestClients.FirstOrDefault()!.LastName!.Contains(search, StringComparison.CurrentCultureIgnoreCase));

                    foreach (var item in mydata)
                    {

                        ProviderRequestData request = new ProviderRequestData();
                       
                        var patient = db.RequestClients.Where(a => a.RequestId == item.RequestId).FirstOrDefault();
                        if (patient.IntYear != null && patient.IntDate != null && patient.StrMonth != null)
                        {
                            int month = DateTime.ParseExact(patient.StrMonth, "MMMM", CultureInfo.CurrentCulture).Month;
                            request.Dob = new DateTime((int)patient.IntYear, month, (int)patient.IntDate);
                        }
                        request.status = 2;
                        request.RequestId = item.RequestId;
                        request.RequestTypeId = item.RequestTypeId;
                        request.Name = patient.FirstName + ", " + patient.LastName;
                        request.PhoneP = patient.PhoneNumber;
                       request.Email = patient.Email;
                        request.Address = patient.Street + " " + patient.City + " " + patient.State;

                        data.Add(request);
                    }
                }
                else if (status == 3)
                {
                   

                    var my = db.Requests.Where(a => (a.Status == 4) || (a.Status == 5) && (a.PhysicianId == id) && (new BitArray(1, false) == a.IsDeleted)).Include(b => b.RequestClients).ToList();
                    var mydata = my.Where(a =>
                        search.IsNullOrEmpty() ||
                        a.RequestClients.FirstOrDefault()!.FirstName!.Contains(search, StringComparison.CurrentCultureIgnoreCase) ||
                        a.RequestClients.FirstOrDefault()!.LastName!.Contains(search, StringComparison.CurrentCultureIgnoreCase));


                    foreach (var item in mydata)
                    {

                        ProviderRequestData request = new ProviderRequestData();
                        var patient = db.RequestClients.Where(a => a.RequestId == item.RequestId).FirstOrDefault();
                        if (patient.IntYear != null && patient.IntDate != null && patient.StrMonth != null)
                        {
                            int month = DateTime.ParseExact(patient.StrMonth, "MMMM", CultureInfo.CurrentCulture).Month;
                            request.Dob = new DateTime((int)patient.IntYear, month, (int)patient.IntDate);
                        }
                        request.status = 3;
                        request.RequestId = item.RequestId;
                        request.RequestTypeId = item.RequestTypeId;
                        request.Name = patient.FirstName + ", " + patient.LastName;
                        request.PhoneP = patient.PhoneNumber;
                        request.Email = patient.Email;
                        request.Address = patient.Street + " " + patient.City + " " + patient.State;
                        request.typeofcare = item.Status;


                        data.Add(request);
                    }
                }
                else if (status == 4)
                {
                    var my = db.Requests.Where(a => (a.Status == 6) && (a.PhysicianId == id) && (new BitArray(1, false) == a.IsDeleted)).Include(b => b.RequestClients).ToList();
                    var mydata = my.Where(a =>
                        search.IsNullOrEmpty() ||
                        a.RequestClients.FirstOrDefault()!.FirstName!.Contains(search, StringComparison.CurrentCultureIgnoreCase) ||
                        a.RequestClients.FirstOrDefault()!.LastName!.Contains(search, StringComparison.CurrentCultureIgnoreCase));


                    foreach (var item in mydata)
                    {

                        ProviderRequestData request = new ProviderRequestData();
                        var patient = db.RequestClients.Where(a => a.RequestId == item.RequestId).FirstOrDefault();
                        if (patient.IntYear != null && patient.IntDate != null && patient.StrMonth != null)
                        {
                            int month = DateTime.ParseExact(patient.StrMonth, "MMMM", CultureInfo.CurrentCulture).Month;
                            request.Dob = new DateTime((int)patient.IntYear, month, (int)patient.IntDate);
                        }
                        request.status = 4;
                        request.RequestId = item.RequestId;
                        request.RequestTypeId = item.RequestTypeId;
                        request.Name = patient.FirstName + ", " + patient.LastName;
                        request.PhoneP = patient.PhoneNumber;
                        request.Email = patient.Email;
                        request.Address = patient.Street + " " + patient.City + " " + patient.State;


                        data.Add(request);
                    }
                }
               
            }
            else
            {

                if (status == 1)
                {
                   
                    var my = db.Requests.Where(a => (a.Status == 1) && (a.PhysicianId == id) && (new BitArray(1, false) == a.IsDeleted) && (a.RequestTypeId == requesttype)).Include(b => b.RequestClients).ToList();
                    var mydata = my.Where(a =>
                        search.IsNullOrEmpty() ||
                        a.RequestClients.FirstOrDefault()!.FirstName!.Contains(search, StringComparison.CurrentCultureIgnoreCase) ||
                        a.RequestClients.FirstOrDefault()!.LastName!.Contains(search, StringComparison.CurrentCultureIgnoreCase));


                    foreach (var item in mydata)
                    {

                        ProviderRequestData request = new ProviderRequestData();
                        var patient = db.RequestClients.Where(a => a.RequestId == item.RequestId).FirstOrDefault();
                        if (patient.IntYear != null && patient.IntDate != null && patient.StrMonth != null)
                        {
                            int month = DateTime.ParseExact(patient.StrMonth, "MMMM", CultureInfo.CurrentCulture).Month;
                            request.Dob = new DateTime((int)patient.IntYear, month, (int)patient.IntDate);
                        }
                        request.status = 1;
                        request.RequestId = item.RequestId;
                        request.RequestTypeId = item.RequestTypeId;
                        request.Name = patient.FirstName + " " + patient.LastName;
                        request.PhoneP = patient.PhoneNumber;
                        request.Email = patient.Email;
                        request.Address = patient.Street + " " + patient.City + " " + patient.State;


                        data.Add(request);
                    }
                }
                else if (status == 2)
                {
                    var my = db.Requests.Where(a => (a.Status == 2) && (a.PhysicianId == id) && (new BitArray(1, false) == a.IsDeleted) && (a.RequestTypeId == requesttype)).Include(b => b.RequestClients).ToList();
                    var mydata = my.Where(a =>
                        search.IsNullOrEmpty() ||
                        a.RequestClients.FirstOrDefault()!.FirstName!.Contains(search, StringComparison.CurrentCultureIgnoreCase) ||
                        a.RequestClients.FirstOrDefault()!.LastName!.Contains(search, StringComparison.CurrentCultureIgnoreCase));

                    foreach (var item in mydata)
                    {

                        ProviderRequestData request = new ProviderRequestData();
                        var patient = db.RequestClients.Where(a => a.RequestId == item.RequestId).FirstOrDefault();
                        if (patient.IntYear != null && patient.IntDate != null && patient.StrMonth != null)
                        {
                            int month = DateTime.ParseExact(patient.StrMonth, "MMMM", CultureInfo.CurrentCulture).Month;
                            request.Dob = new DateTime((int)patient.IntYear, month, (int)patient.IntDate);
                        }
                        request.status = 2;
                        request.RequestId = item.RequestId;
                        request.RequestTypeId = item.RequestTypeId;
                        request.Name = patient.FirstName + ", " + patient.LastName;
                        request.PhoneP = patient.PhoneNumber;
                        request.Email = patient.Email;
                        request.Address = patient.Street + " " + patient.City + " " + patient.State;

                        data.Add(request);
                    }
                }
                else if (status == 3)
                {
               
                    var my = db.Requests.Where(a => (a.Status == 4 || a.Status == 5) && (a.RequestTypeId == requesttype) && (new BitArray(1, false) == a.IsDeleted)).Include(b => b.RequestClients).ToList();
                    var mydata = my.Where(a =>
                        search.IsNullOrEmpty() ||
                        a.RequestClients.FirstOrDefault()!.FirstName!.Contains(search, StringComparison.CurrentCultureIgnoreCase) ||
                        a.RequestClients.FirstOrDefault()!.LastName!.Contains(search, StringComparison.CurrentCultureIgnoreCase));


                    foreach (var item in mydata)
                    {

                        ProviderRequestData request = new ProviderRequestData();
                        var patient = db.RequestClients.Where(a => a.RequestId == item.RequestId).FirstOrDefault();
                        if (patient.IntYear != null && patient.IntDate != null && patient.StrMonth != null)
                        {
                            int month = DateTime.ParseExact(patient.StrMonth, "MMMM", CultureInfo.CurrentCulture).Month;
                            request.Dob = new DateTime((int)patient.IntYear, month, (int)patient.IntDate);
                        }
                        request.status = 3;
                        request.RequestId = item.RequestId;
                        request.RequestTypeId = item.RequestTypeId;
                        request.Name = patient.FirstName + ", " + patient.LastName;
                        request.PhoneP = patient.PhoneNumber;
                        request.Email = patient.Email;
                        request.Address = patient.Street + " " + patient.City + " " + patient.State;
                        request.typeofcare = item.Status;

                        data.Add(request);
                    }
                }
                else if (status == 4)
                {
                    
                    var my = db.Requests.Where(a => (a.Status == 6) && (a.PhysicianId == id) && (new BitArray(1, false) == a.IsDeleted) && a.RequestTypeId == requesttype).Include(b => b.RequestClients).ToList();
                    var mydata = my.Where(a =>
                        search.IsNullOrEmpty() ||
                        a.RequestClients.FirstOrDefault()!.FirstName!.Contains(search, StringComparison.CurrentCultureIgnoreCase) ||
                        a.RequestClients.FirstOrDefault()!.LastName!.Contains(search, StringComparison.CurrentCultureIgnoreCase));

                    foreach (var item in mydata)
                    {

                        ProviderRequestData request = new ProviderRequestData();
                        var patient = db.RequestClients.Where(a => a.RequestId == item.RequestId).FirstOrDefault();
                        if (patient.IntYear != null && patient.IntDate != null && patient.StrMonth != null)
                        {
                            int month = DateTime.ParseExact(patient.StrMonth, "MMMM", CultureInfo.CurrentCulture).Month;
                            request.Dob = new DateTime((int)patient.IntYear, month, (int)patient.IntDate);
                        }
                        request.status = 4;
                        request.RequestId = item.RequestId;
                        request.RequestTypeId = item.RequestTypeId;
                        request.Name = patient.FirstName + ", " + patient.LastName;
                        request.PhoneP = patient.PhoneNumber;
                        request.Email = patient.Email;
                        request.Address = patient.Street + " " + patient.City + " " + patient.State;

                        data.Add(request);
                    }
                }
               

            }
            return data;
        }

    
        public void AccepRequest(int reqid, string usermail)
        {
            int id = db.Physicians.Where(a => a.Email == usermail).FirstOrDefault().PhysicianId;
            var req = db.Requests.Where(a => a.RequestId == reqid).FirstOrDefault();
            req.Status = 2;
            req.AcceptedDate = DateTime.Now;
            RequestStatusLog data = new RequestStatusLog();
            data.RequestId = reqid;
            data.Notes = "Request  accepted by provider";
            data.CreatedDate = DateTime.Now;
            data.PhysicianId = id;

            db.RequestStatusLogs.Add(data);

            db.Requests.Update(req);
            db.SaveChanges();
        }

        public void TransferReqToAdmin(int reqid, string reason,string usermail)
        {
            int id = db.Physicians.Where(a => a.Email == usermail).FirstOrDefault().PhysicianId;

            var req = db.Requests.Where(a => a.RequestId == reqid).FirstOrDefault();
            req.PhysicianId = null;
            req.Status = 1;
            RequestStatusLog rs = new RequestStatusLog()
            {
                Notes = reason,
                RequestId = reqid,
                CreatedDate = DateTime.Now,
                Status = 1,
                PhysicianId = id
            };
            db.Requests.Update(req);
            db.SaveChanges();
        }

        public void SelectTypeOfCare(int careid, int selecttype)
        {
            var req = db.Requests.Where(a => a.RequestId == careid).FirstOrDefault();
           if(selecttype == 1)
            {
                req.Status = 5;
            }
            else
            {
                req.Status = 6;

            }

           db.Requests.Update(req);
            db.SaveChanges();

        }

        public void HouseCallClick(int reqid)
        {
            var req = db.Requests.Where(a => a.RequestId == reqid).FirstOrDefault();

            req.Status = 6;
            db.Requests.Update(req);
            db.SaveChanges();


        }

        public bool IsFinalized(int reqid)
        {
            var enc = db.EncounterForms.Where(a => a.RequestId == reqid).FirstOrDefault();
            bool check = false;
            if (enc != null)
            {
                check = enc.IsFinalize;
            }
            return check;
        }

        public EncounterPDF getEncounterForm(int id)
        {
            var req = db.Requests.Where(a => a.RequestId == id).FirstOrDefault();
            var enc = db.EncounterForms.Where(a => a.RequestId == id).FirstOrDefault();
            var pat = db.RequestClients.Where(a => a.RequestId == id).FirstOrDefault();
            EncounterPDF data = new EncounterPDF();
            
            data.Patientname = pat.FirstName + " " + pat.LastName;
            if (pat.IntYear != null && pat.IntDate != null && pat.StrMonth != null)
            {
                int month = DateTime.ParseExact(pat.StrMonth, "MMMM", CultureInfo.CurrentCulture).Month;
                data.DateOfBirth = new DateTime((int)pat.IntYear, month, (int)pat.IntDate).ToShortDateString();
            }
            
            data.DateOfService = req.AcceptedDate.ToString();
            data.Phone = pat.PhoneNumber;
            data.Email = pat.Email;
            data.HistoryOfIllness = enc.HistoryOfPresentIllnessOrInjury;
            data.MedicalHistroy = enc.MedicalHistory;
            data.Medications = enc.Medications;
            data.Allergies = enc.Allergies;
            data.Temp = enc.Temp;
            data.HR = enc.Hr;
            data.RR = enc.Rr;
            data.BloodPressureDiastolic = enc.BloodPressureDiastolic;
            data.BloodPressureSystolic = enc.BloodPressureSystolic;
            data.O2 = enc.O2;
            data.Heent = enc.Heent;
            data.Pain = enc.Pain;
            data.CV = enc.Cv;
            data.Chest = enc.Chest;
            data.ABD = enc.Abd;
            data.Extremeties = enc.Extremeties;
            data.Neuro = enc.Neuro;
            data.Skin = enc.Skin;
            data.Diagnosis = enc.Diagnosis;
            data.TreatmentPlan = enc.TreatmentPlan;
            data.Procedures = enc.Procedures;
            data.FollowUp = enc.FollowUp;
            data.Other = enc.Other;
            return data;
        }

        public void fileUpload(List<IFormFile> ConcludeFiles, int concludeid)
        {
            if (ConcludeFiles != null)
            {
                //var uploads = Path.Combine(_environment.WebRootPath, "uploads/Family");
                //var filePath = Path.Combine(uploads, model.P_File.FileName);
                //var file = model.P_File;

                //file.CopyTo(new FileStream(filePath, FileMode.Create));
                //RequestWiseFile insertfile = new RequestWiseFile()
                //{
                //    Request = insertrequest,
                //    FileName = filePath,
                //    CreatedDate = DateTime.Now

                //};
                //context.RequestWiseFiles.Add(insertfile);
                foreach (var item in ConcludeFiles)
                {
                    var uploads = Path.Combine(_environment.WebRootPath, "uploads\\");
                    var filePath = Path.Combine(uploads, item.FileName);
                    var file = item;

                    file.CopyTo(new FileStream(filePath, FileMode.Create));
                    RequestWiseFile insertfile = new RequestWiseFile()
                    {
                        RequestId = concludeid,
                        FileName = filePath,
                        CreatedDate = DateTime.Now

                    };
                    db.RequestWiseFiles.Add(insertfile);
                }
            }
            db.SaveChanges();

        }
    }
}
