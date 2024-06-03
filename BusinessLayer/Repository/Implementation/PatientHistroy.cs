using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interface;
using DataLayer.DTO.AdminDTO;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using static NPOI.HSSF.Util.HSSFColor;

namespace BusinessLayer.Repository.Implementation
{
    public class PatientHistroy : IPatientHistroy
    {
        public HallodocContext db;

        public PatientHistroy(HallodocContext db)
        {
            this.db = db;

        }

        public List<PatientHistroyData> getAllUsers()
        {
            List < PatientHistroyData > data = new();

            var users = db.Users.ToList();
            foreach (var item in users)
            {
                PatientHistroyData obj = new PatientHistroyData()
                {
                    UserId = item.UserId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    PhoneNumber = item.Mobile,
                    Address = item.Street + " " + item.City + " " + item.State
                };

                data.Add(obj);
            }

            return data;
        }

        public List<PatientHistroyData> getUsersBySearch(string FirstName, string LastName, string Email, string Phone)
        {
            List<PatientHistroyData> data = new();

            var users = db.Users.ToList();
            users = users.Where(a => string.IsNullOrEmpty(FirstName) ||
                        a.FirstName.Contains(FirstName, StringComparison.CurrentCultureIgnoreCase)).ToList();

              users = users.Where(a => string.IsNullOrEmpty(LastName) ||
                        a.LastName.Contains(LastName, StringComparison.CurrentCultureIgnoreCase)).ToList();

              users = users.Where(a => string.IsNullOrEmpty(Email) ||
                        a.Email.Contains(Email, StringComparison.CurrentCultureIgnoreCase)).ToList();

              users = users.Where(a => string.IsNullOrEmpty(Phone) ||
                        a.Mobile.Contains(Phone, StringComparison.CurrentCultureIgnoreCase)).ToList();




            foreach (var item in users)
            {
                PatientHistroyData obj = new PatientHistroyData()
                {
                    UserId = item.UserId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    PhoneNumber = item.Mobile,
                    Address = item.Street + " " + item.City + " " + item.State
                };

                data.Add(obj);
            }

            return data;
        }

        public List<PatientRecordData> getPatientRecord(int Userid)
        {
            List<PatientRecordData> data = new();

            var record = db.Requests.Where(a =>(a.UserId==Userid) && (new BitArray(1, false) == a.IsDeleted)).Include(a => a.RequestClients).Include(a => a.Physician).Include(a => a.RequestStatusLogs).ToList();
            
            foreach (var item in record)
            {
                PatientRecordData obj = new PatientRecordData()
                {
                    requestId = item.RequestId,
                    Name = item.RequestClients.Where(a => a.RequestId == item.RequestId).FirstOrDefault().FirstName + "," + item.RequestClients.Where(a => a.RequestId == item.RequestId).FirstOrDefault().LastName,
                    CreatedDate = item.CreatedDate,
                    ConfirmationNumber = item.ConfirmationNumber,
                    Status = item.Status,
                    DocCount = db.RequestWiseFiles.Where(a => a.RequestId == item.RequestId).ToList().Count()

                };
                if (item.PhysicianId != null)
                {
                    obj.ProviderName = item.Physician.FirstName + " " + item.Physician.LastName;
                }

                data.Add(obj);
            }

            return data;
        }
    }
}
