using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interface;
using DataLayer.DTO.AdminDTO;
using DataLayer.Models;

namespace BusinessLayer.Repository.Implementation
{
    public class SMSLog : ISMSLog
    {
        public HallodocContext db;

        public SMSLog(HallodocContext db)
        {
            this.db = db;

        }

        public List<SMSLogData> getAllSMS()
        {
            List<SMSLogData> data = new();
            var sms = db.Smslogs.ToList();

            foreach(var item in sms)
            {
                SMSLogData obj = new SMSLogData()
                {
                    Mobile = item.Mobilenumber,
                    Action = (int)item.Action,
                    SMSSent = (bool)item.Issmssent,
                    SentTries = (int)item.Senttries,
                    CreatedDate = item.Createdate,
                    SentDate = (DateTime)item.Sentdate,
                };
                if (item.Roleid != null)
                {
                    obj.RoleName = db.Roles.Where(a => a.RoleId == item.Roleid).FirstOrDefault().Name;

                }
                if (item.Confirmationnumber != null)
                {
                    obj.CNumber = item.Confirmationnumber;

                }
                data.Add(obj);

            }

            return data;
        }

        public List<SMSLogData> getSMSBySearch(int Role, string ReceiverName, string Mobile, DateTime CreatedDate, DateTime SentDate)
        {
            List<SMSLogData> data = new();
            var sms = db.Smslogs.ToList();
            if (Role != 0)
            {
                sms = sms.Where(a => a.Roleid == Role).ToList();
            }
            sms = sms.Where(a => string.IsNullOrEmpty(Mobile) ||
                        a.Mobilenumber.Contains(Mobile, StringComparison.CurrentCultureIgnoreCase)).ToList();
            if (CreatedDate != default(DateTime))
            {
                sms = sms.Where(a => a.Createdate.Date == CreatedDate.Date).ToList();
            } 
            if (SentDate != default(DateTime))
            {
                sms = sms.Where(a =>a.Sentdate == SentDate.Date).ToList();
            }
            if (sms.Count > 0)
            {
                foreach (var item in sms)
                {
                    SMSLogData obj = new SMSLogData()
                    {
                        Mobile = item.Mobilenumber,
                        Action = (int)item.Action,
                        SMSSent = (bool)item.Issmssent,
                        SentTries = (int)item.Senttries,
                        CreatedDate = item.Createdate,
                        SentDate = (DateTime)item.Sentdate,
                    };
                    if (item.Roleid != null)
                    {
                        obj.RoleName = db.Roles.Where(a => a.RoleId == item.Roleid).FirstOrDefault().Name;

                    }
                    if (item.Confirmationnumber != null)
                    {
                        obj.CNumber = item.Confirmationnumber;

                    }

                    data.Add(obj);

                }
            }
            

            return data;
        }

        public void AddSMSLog(int phyid, int adminid, string msg)
        {
            Smslog sms = new Smslog()
            {
                Mobilenumber = db.Physicians.Where(a=>a.PhysicianId == phyid).FirstOrDefault().Mobile,
                Smstemplate = msg,
                Physicianid = phyid,
                Adminid = adminid,
                Createdate = DateTime.Now,
                Sentdate = DateTime.Now,
                Issmssent = true,
                Senttries = 1,
                Action = 0

            };
            db.Smslogs.Add(sms);
            db.SaveChanges();

        }
       
    }
}
