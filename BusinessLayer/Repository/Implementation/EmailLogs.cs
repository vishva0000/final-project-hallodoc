using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interface;
using DataLayer.DTO;
using DataLayer.DTO.AdminDTO;
using DataLayer.Models;
using Org.BouncyCastle.Ocsp;
using Twilio.TwiML.Voice;

namespace BusinessLayer.Repository.Implementation
{
    public class EmailLogs : IEmailLogs
    {
        public HallodocContext db;

        public EmailLogs(HallodocContext db)
        {
            this.db = db;

        }
        public void addEmailLog(EmailLogDto model)
        {
            EmailLog log = new EmailLog()
            {
                EmailTemplate = model.Template,
                SubjectName = model.Subject,
                EmailId = model.EmailId,
                ConfirmationNumber = model.ConfNumber,
                RoleId = model.RoleId,
                AdminId = model.AdminId,
                RequestId = model.RequestId,
                PhysicianId = model.PhysicianId,
                CreateDate = DateTime.Now,
                SentDate = DateTime.Now,
                Action = model.Action,
                SentTries = 1
            };

            db.EmailLogs.Add(log);
            db.SaveChanges();
        }
        public List<EmailLogData> getAllMail()
        {
            List<EmailLogData> data = new();
            var emails = db.EmailLogs.ToList();

            foreach(var item in emails)
            {
                EmailLogData d = new EmailLogData()
                {
                    Email = item.EmailId,
                    Action = (int)item.Action,                   
                    CreatedDate = item.CreateDate,
                    SentDate = (DateTime)item.SentDate
                 
                    
                };
               
                if (item.SentTries != null)
                {
                    d.SentTries = 1;

                } if (item.IsEmailSent != null)
                {
                    d.EmailSent = true;

                }
                if (item.ConfirmationNumber != null)
                {
                    d.CNumber = item.ConfirmationNumber;
                }
                data.Add(d);
            }
            return data;

        }

        public List<EmailLogData> getEmailBySearch(int Role, string ReceiverName, string Email, DateTime CreatedDate, DateTime SentDate)
        {
            List<EmailLogData> data = new();
            var emails = db.EmailLogs.ToList();

            if (Role != 0)
            {
                emails = emails.Where(a => a.RoleId == Role).ToList();
            }
            if (Email != null)
            {
                emails = emails.Where(a => string.IsNullOrEmpty(Email) ||
                       a.EmailId.Contains(Email, StringComparison.CurrentCultureIgnoreCase)).ToList();

            }
            if (CreatedDate != default(DateTime))
            {
                emails = emails.Where(a => a.CreateDate.Date == CreatedDate.Date).ToList();
            }
            if (SentDate != default(DateTime))
            {
                emails = emails.Where(a => a.SentDate == SentDate.Date).ToList();
            }

            foreach (var item in emails)
            {
                EmailLogData d = new EmailLogData()
                {
                    Email = item.EmailId,
                    Action = (int)item.Action,
                    //RoleName = db.Roles.Where(a => a.RoleId == item.RoleId).FirstOrDefault().Name,
                    CreatedDate = item.CreateDate,
                    SentDate = (DateTime)item.SentDate,

                };
             
                if (item.SentTries != null)
                {
                    d.SentTries = 1;

                }
                if (item.IsEmailSent != null)
                {
                    d.EmailSent = true;

                }
                if (item.ConfirmationNumber != null)
                {
                    d.CNumber = item.ConfirmationNumber;
                }
                data.Add(d);
            }
            return data;
        }
    }
}
