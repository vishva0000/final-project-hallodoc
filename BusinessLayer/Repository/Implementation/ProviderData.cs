using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interface;
using DataLayer.DTO.AdminDTO;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLayer.Repository.Implementation
{
    public class ProviderData: IProviderData
    {
        public HallodocContext db;

        public ProviderData(HallodocContext context) 
        {
            this.db = context;

        }

        public List<ProviderDetails> getProviderData(string search)
        {
                int seid = int.Parse(search);

            var providers = db.Physicians.Where(a => new BitArray(1, false) == a.IsDeleted).ToList();
            var providersInRegion = db.PhysicianRegions.Where(a=>a.RegionId==seid).ToList();
            var notification = db.PhysicianNotifications.ToList();
            List<ProviderDetails> data = new();

            if (seid == 0)
            {
                foreach (var item in providers)
                {
                    ProviderDetails dto = new ProviderDetails();
                    dto.Phyid = item.PhysicianId;
                    dto.ProviderName = item.FirstName + " " + item.LastName;
                    dto.Role = "Provider";
                    dto.OnCallStatus = "Not Available";
                    dto.Status = "Pending";
                    dto.IsNotificationStopped = notification.Where(a => a.PhysicianId == item.PhysicianId).FirstOrDefault().IsNotificationStopped[0];
                   
                    data.Add(dto);
                }


               
            }
            else
            {
                //var providerselect = providers.Where(a =>
                //     search.IsNullOrEmpty() ||
                //     a.RegionId == seid);
                foreach (var item in providersInRegion)
                {
                    ProviderDetails dto = new ProviderDetails();
                    dto.Phyid = item.PhysicianId;
                    dto.ProviderName = item.Physician.FirstName + " " + item.Physician.LastName;
                    dto.Role = "Provider";
                    dto.OnCallStatus = "Not Available";
                    dto.Status = "Pending";
                    dto.IsNotificationStopped = notification.Where(a => a.PhysicianId == item.PhysicianId).FirstOrDefault().IsNotificationStopped[0];
                    //dto.IsNotificationStopped = item.Physician.PhysicianNotifications.Where(a=>a.PhysicianId==item.PhysicianId);

                    data.Add(dto);
                }
            }       
                                 
            return data;
        }

        public void ChangeinNotification(int phyid, bool ischeck)
        {
            var phy = db.PhysicianNotifications.Where(a => a.PhysicianId == phyid).FirstOrDefault();
            if (ischeck == true)
            {
                phy.IsNotificationStopped = new BitArray(new bool[1] { true });
            }
            else
            {
                phy.IsNotificationStopped = new BitArray(new bool[1] { false });

            }   
            db.PhysicianNotifications.Update(phy);
            db.SaveChanges();
        }
    }
}
