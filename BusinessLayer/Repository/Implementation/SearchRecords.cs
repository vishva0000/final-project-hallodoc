using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interface;
using DataLayer.DTO.AdminDTO;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementation
{
    public class SearchRecords: ISearchRecords
    {
        public HallodocContext db;

        public SearchRecords(HallodocContext db)
        {
            this.db = db;
        }

        public List<SearchRecordData> getAllRequests()
        {
            List<SearchRecordData> data = new();
            var request = db.Requests.Where(a=>new BitArray(1, false) == a.IsDeleted).Include(a => a.RequestClients).Include(a => a.Physician).Include(a => a.RequestStatusLogs).ToList();

            foreach(var item in request)
            {
                SearchRecordData obj = new SearchRecordData()
                {
                    RequestId = item.RequestId,
                    PatientName = item.RequestClients.FirstOrDefault().FirstName + " "+ item.RequestClients.FirstOrDefault().LastName,
                    Requestor = item.FirstName + " " +item.LastName,
                    Email = item.RequestClients.FirstOrDefault().Email,
                    PhoneNumber = item.RequestClients.FirstOrDefault().PhoneNumber,
                    Address = item.RequestClients.FirstOrDefault().Address,
                    zip = item.RequestClients.FirstOrDefault().ZipCode,
                    RequestStatus = item.Status,                  

                };
                if (item.PhysicianId != null)
                {
                    obj.Physician = item.Physician.FirstName + " " + item.Physician.LastName;
                }
                data.Add(obj);
            }

            return data;
        }

        public void DeleteRequest(int reqid)
        {
            var req = db.Requests.Where(a => a.RequestId == reqid).FirstOrDefault();
            req.IsDeleted = new BitArray(new bool[1] { true });

            db.Requests.Update(req);
            db.SaveChanges();
        }

        public List<SearchRecordData> getRecordBySearch(int RequestStatus,string PatientName, int RequestType, DateTime? FromDateOfService, DateTime? ToDateOfService, string ProviderName, string Email, string Phone)
        {
            List<SearchRecordData> requests = new();
            var req = db.Requests.Where(a => (new BitArray(1, false) == a.IsDeleted)).Include(a => a.RequestClients).Include(a => a.Physician).Include(a => a.RequestStatusLogs).ToList();

            if (RequestStatus != 0)
            {
                if(RequestStatus ==1 || RequestStatus ==2)
                {
                    req = req.Where(a => a.Status == RequestStatus).ToList();
                }
                else if (RequestStatus == 3)
                {
                    req = req.Where(a =>( a.Status == 4) || (a.Status == 5)).ToList();

                }
                else if (RequestStatus == 5)
                {
                    req = req.Where(a =>( a.Status == 3) || (a.Status == 7) || (a.Status == 8)).ToList();

                }
                else if (RequestStatus == 4)
                {
                    req = req.Where(a => a.Status == 6).ToList();

                }
                else if (RequestStatus == 6)
                {
                    req = req.Where(a => a.Status == 9).ToList();

                }
                else
                {
                    req = req.Where(a => a.Status == 10).ToList();

                }

            }
            req = req.Where(a => string.IsNullOrEmpty(PatientName) ||
                        a.RequestClients.FirstOrDefault()!.FirstName!.Contains(PatientName, StringComparison.CurrentCultureIgnoreCase) ||
                        a.RequestClients.FirstOrDefault()!.LastName!.Contains(PatientName, StringComparison.CurrentCultureIgnoreCase)).ToList();

            if (RequestType != 0)
            {
                req = req.Where(a => a.RequestTypeId == RequestType).ToList();

            }
            if (ProviderName != null)
            {
                req = req.Where(a => a.PhysicianId != null).Where(a => string.IsNullOrEmpty(ProviderName) ||
                                     a.Physician.FirstName!.Contains(ProviderName, StringComparison.CurrentCultureIgnoreCase) ||
                                     a.Physician.LastName!.Contains(ProviderName, StringComparison.CurrentCultureIgnoreCase)).ToList();

            }
            if (Email != null)
            {
                req = req.Where(a => string.IsNullOrEmpty(Email) ||
                      a.RequestClients.FirstOrDefault()!.Email!.Contains(Email, StringComparison.CurrentCultureIgnoreCase)).ToList();

            }

            if (FromDateOfService != default(DateTime))
            {
                req = req.Where(a => a.AcceptedDate.HasValue && a.AcceptedDate.Value.Date >= FromDateOfService.Value.Date).ToList();
            }
            if (ToDateOfService != default(DateTime))
            {
                req = req.Where(a => a.AcceptedDate.HasValue && a.AcceptedDate.Value.Date <= ToDateOfService.Value.Date).ToList();
            }
            if (Phone != null)
            {
                req = req.Where(a => string.IsNullOrEmpty(Phone) ||
                     a.RequestClients.FirstOrDefault()!.PhoneNumber!.Contains(Phone, StringComparison.CurrentCultureIgnoreCase)).ToList();

            }
           

            foreach(var item in req)
            {
                SearchRecordData obj = new SearchRecordData()
                {
                    RequestId = item.RequestId,
                    PatientName = item.RequestClients.FirstOrDefault().FirstName + " " + item.RequestClients.FirstOrDefault().LastName,
                    Requestor = item.FirstName + " " + item.LastName,
                    Email = item.RequestClients.FirstOrDefault().Email,
                    PhoneNumber = item.RequestClients.FirstOrDefault().PhoneNumber,
                    Address = item.RequestClients.FirstOrDefault().Address,
                    zip = item.RequestClients.FirstOrDefault().ZipCode,
                    RequestStatus = item.Status,

                };
                if (item.PhysicianId != null)
                {
                    obj.Physician = item.Physician.FirstName + " " + item.Physician.LastName;
                }
                requests.Add(obj);
            }
            return requests;
        }
    }
}
