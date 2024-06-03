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
    public class ProviderLocation:IProviderLocation
    {
        public HallodocContext db;

        public ProviderLocation(HallodocContext db)
        {
            this.db = db;

        }

        public List<ProviderLocationData> getProviderLocation()
        {
            List<ProviderLocationData> data = new List<ProviderLocationData>();
            var phylist = db.PhysicianLocations.ToList();
            foreach (var phy in phylist)
            {
                ProviderLocationData d = new ProviderLocationData();
                d.latitude = (decimal)phy.Latitude;
                d.Longitude = (decimal)phy.Longitude;
                d.PhyName = phy.PhysicianName;

                data.Add(d);
            }
            return data;
        }
    }
}
