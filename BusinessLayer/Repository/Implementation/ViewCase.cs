using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using BusinessLayer.Repository.Interface;
using DataLayer.DTO.AdminDTO;
using DataLayer.Models;

namespace BusinessLayer.Repository.Implementation
{
    public class ViewCase : IViewCase
    {
        public HallodocContext db;

        public ViewCase(HallodocContext context)
        {
            this.db = context;

        }

        public ViewNotesData GetNotes(int Requestid)
        {
            var data = db.RequestNotes.Where(a => a.RequestId == Requestid).FirstOrDefault();

            var statustrans = db.RequestStatusLogs.Where(a => a.RequestId == Requestid && a.Status == 2).ToList();

            List<string> tnotes = new();

            foreach (var item in statustrans)
            {

                string phy = db.Physicians.Where(a => a.PhysicianId == item.PhysicianId).FirstOrDefault().FirstName + " " + db.Physicians.Where(a => a.PhysicianId == item.PhysicianId).FirstOrDefault().LastName;
                string assnote = item.Notes;
                string note = "Request is assigned to " + phy + ": " + assnote;
                tnotes.Add(note);
            }

            ViewNotesData notes = new ViewNotesData();
            if (data != null)
            {
                notes.transfernote = tnotes;
                notes.physicianNotes = data.PhysicianNotes;
                notes.adminNotes = data.AdminNotes;
            }

            return notes;
        }

        public void AddAdminNotes(string Additional, int reqid)
        {
            var data = db.RequestNotes.Where(a => a.RequestId == reqid).FirstOrDefault();
            if (data != null)
            {
                data.AdminNotes = Additional;
                db.RequestNotes.Update(data);
            }
            else
            {
                RequestNote reqnote = new RequestNote();
                reqnote.RequestId = reqid;
                reqnote.CreatedBy = "admin";
                reqnote.CreatedDate = DateTime.Now;
                reqnote.AdminNotes = Additional;
                db.RequestNotes.Add(reqnote);
            }
            db.SaveChanges();
        } 
        
        public void AddPhysicianNote(string Additional, int reqid)
        {
            var data = db.RequestNotes.Where(a => a.RequestId == reqid).FirstOrDefault();
            if (data != null)
            {
                data.PhysicianNotes = Additional;
                db.RequestNotes.Update(data);
            }
            else
            {
                RequestNote reqnote = new RequestNote();
                reqnote.RequestId = reqid;
                reqnote.CreatedBy = "physician";
                reqnote.CreatedDate = DateTime.Now;
                reqnote.PhysicianNotes = Additional;
                db.RequestNotes.Add(reqnote);
            }
            db.SaveChanges();
        }

        public ViewCaseData GetCaseData(int reqId)
        {
            var request = db.Requests.Where(a => a.RequestId == reqId).FirstOrDefault();
            var data = db.RequestClients.Where(a => a.RequestId == reqId).FirstOrDefault();

            ViewCaseData details = new ViewCaseData();

            if (data.IntYear != null && data.IntDate != null && data.StrMonth != null)
            {
                int month = DateTime.ParseExact(data.StrMonth, "MMMM", CultureInfo.CurrentCulture).Month;
                details.Dob = new DateTime((int)data.IntYear, month, (int)data.IntDate);
            }
            details.RequestTypeId = request.RequestTypeId;
            details.RequestId = request.RequestId;
            details.Symp = data.Notes;
            details.Firstname = data.FirstName;
            details.Lastname = data.LastName;
            details.Email = data.Email;
            details.Phone = data.PhoneNumber;
            details.Street = data.Street;
            details.City = data.City;
            details.State = data.State;
            details.Room = data.Location;
            details.status = request.Status;

            return details;
        }

        public void UpdateCaseData(ViewCaseData model, int reqId)
        {
            var data = db.RequestClients.Where(a => a.RequestId == reqId).FirstOrDefault();

            data.Notes = model.Symp;
            data.Street = model.Street;
            data.PhoneNumber = model.Phone;
            data.City = model.City;
            data.State = model.State;
            data.FirstName = model.Firstname;
            data.LastName = model.Lastname;
            data.Email = model.Email;
            data.Location = model.Room;

            db.RequestClients.Update(data);
            db.SaveChanges();

        }

        public void AddOrders(OrderData model, int reqid)
        {
            OrderDetail data = new OrderDetail();

            data.VendorId = model.VendorId;
            data.RequestId = reqid;
            data.FaxNumber = model.Fax;
            data.Email = model.Email;
            data.BusinessContact = model.Contact;
            data.Prescription = model.Prescription;
            data.CreatedDate = DateTime.Now;
            data.NoOfRefill = int.Parse(model.NoOfRefill);

            db.OrderDetails.Add(data);
            db.SaveChanges();
        }
    }
}
