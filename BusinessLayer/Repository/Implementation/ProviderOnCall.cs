using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interface;
using DataLayer.DTO.AdminDTO;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementation
{
    public class ProviderOnCall: IProviderOnCall
    {
        public HallodocContext db;

        public ProviderOnCall(HallodocContext db)
        {

            this.db = db;

        }

        public List<OncallProviderData> getOnCallProviders(string region)
        {
            int regid = int.Parse(region);
            DateTime curr = DateTime.Now;
            List<OncallProviderData> data = new();

            if (regid == 0)
            {
                var physician = db.ShiftDetails.Where(a => a.ShiftDate.Date == curr.Date && (a.StartTime.ToTimeSpan() <= curr.TimeOfDay) && (a.EndTime.ToTimeSpan() >= curr.TimeOfDay))
              .Include(a => a.Shift)
              .ThenInclude(a => a.Physician)
              .ToList().Where(a => !a.IsDeleted.Get(0)).ToList();

                var provider = db.Physicians.ToList();


                foreach (var item in physician)
                {
                    var phy = item.Shift.Physician;
                    OncallProviderData d = new OncallProviderData()
                    {
                        ProviderId = phy.PhysicianId,
                        Name = phy.FirstName + " " + phy.LastName,
                        status = 1
                    };
                    if (phy.Photo != null)
                    {
                        d.Photo = phy.Photo.Split('\\').Last();
                    }
                    provider.RemoveAll(a => a.PhysicianId == phy.PhysicianId);
                    data.Add(d);
                }

                foreach (var item in provider)
                {
                    OncallProviderData d = new OncallProviderData()
                    {
                        ProviderId = item.PhysicianId,
                        Name = item.FirstName + " " + item.LastName,
                        status = 2,
                        //Photo = item.Photo
                    };
                    if (item.Photo != null)
                    {
                        d.Photo = item.Photo.Split('\\').Last();
                    }
                    data.Add(d);

                }
            }
            else
            {
                var physician = db.ShiftDetails.Where(a => a.ShiftDate.Date == curr.Date 
                && (a.StartTime.ToTimeSpan() <= curr.TimeOfDay) 
                && (a.EndTime.ToTimeSpan() >= curr.TimeOfDay)
                && (a.RegionId == regid))
              .Include(a => a.Shift)
              .ThenInclude(a => a.Physician)
              .ToList().Where(a => !a.IsDeleted.Get(0)).ToList();

                var provider = db.Physicians.Include(a=>a.PhysicianRegions).Where(a=>a.PhysicianRegions.Any(a=>a.RegionId==regid)).ToList();


                foreach (var item in physician)
                {
                    var phy = item.Shift.Physician;
                    OncallProviderData d = new OncallProviderData()
                    {
                        ProviderId = phy.PhysicianId,
                        Name = phy.FirstName + " " + phy.LastName,
                        status = 1,
                    };
                    if (phy.Photo != null)
                    {
                        d.Photo = phy.Photo.Split('\\').Last();
                    }
                    provider.RemoveAll(a => a.PhysicianId == phy.PhysicianId);
                    data.Add(d);
                }

                foreach (var item in provider)
                {
                  

                    OncallProviderData d = new OncallProviderData()
                    {
                        ProviderId = item.PhysicianId,
                        Name = item.FirstName + " " + item.LastName,
                        status = 2,
                    };
                    if (item.Photo != null)
                    {
                        d.Photo = item.Photo.Split('\\').Last();
                    }
                    data.Add(d);

                }
            }
          
            return data.DistinctBy(a=>a.ProviderId).ToList();
        }
    }
}
