using BusinessLayer.Repository.Interface;
using DataLayer.DTO;
using DataLayer.DTO.AdminDTO;
using DataLayer.Models;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Utility
{
    public class FetchData : IFetchData
    {
        public HallodocContext db;

        public FetchData(HallodocContext context)
        {
            this.db = context;

        }

        public List<FetchDTO> RegionsOfPhy(int phyid)
        {
            var preg = db.PhysicianRegions.Where(a => a.PhysicianId == phyid).ToList();
            var reg = db.Regions.ToList();
            List<FetchDTO> data = new();
            foreach (var item in preg)
            {
                FetchDTO obj = new FetchDTO()
                {
                    Name = reg.Where(a => a.RegionId == item.RegionId).FirstOrDefault().Name,
                    Id = item.RegionId
                };
                data.Add(obj);
            }

            return data;

        }

        public List<FetchDTO> FetchRoles()
        {
            List<FetchDTO> data = new();
            var role = db.Roles.ToList();
            foreach (var item in role)
            {
                FetchDTO obj = new();
                obj.Name = item.Name;
                obj.Id = item.RoleId;
                data.Add(obj);

            }
            return data;
        }

        public List<FetchDTO> FetchRegions()
        {
            List<FetchDTO> data = new();
            var reg = db.Regions.ToList();
            foreach (var item in reg)
            {
                FetchDTO obj = new();
                obj.Name = item.Name;
                obj.Id = item.RegionId;
                data.Add(obj);

            }
            return data;
        }

        public List<FetchDTO> FetchProfession()
        {
            List<FetchDTO> data = new();
            var profession = db.HealthProfessionalTypes.ToList();
            foreach (var item in profession)
            {
                FetchDTO obj = new();
                obj.Name = item.ProfessionName;
                obj.Id = item.HealthProfessionalId;
                data.Add(obj);

            }
            return data;
        }

        public List<FetchDTO> FetchPhysician()
        {
            List<FetchDTO> data = new();
            var physician = db.Physicians.ToList();
            foreach (var item in physician)
            {
                FetchDTO obj = new();
                obj.Name = item.FirstName +" " +item.LastName;
                obj.Id = item.PhysicianId;
                data.Add(obj);

            }
            return data;
        }
        public List<FetchDTO> FetchPhysicianByRegion(int regid)
        {
            List<FetchDTO> data = new();
            var physician = db.PhysicianRegions.Where(a=>a.RegionId == regid).ToList();
            foreach (var item in physician)
            {
                var phy = db.Physicians.Where(a => a.PhysicianId == item.PhysicianId).FirstOrDefault();
                FetchDTO obj = new();
                obj.Name = phy.FirstName +" " +phy.LastName;
                obj.Id = item.PhysicianId;
                data.Add(obj);

            }
            return data;
        }
         public List<FetchDTO> FetchBusiness(int businessid)
        {
            List<FetchDTO> data = new();
            var profession = db.HealthProfessionals.Where(r => r.Profession == businessid).ToList();
            foreach (var item in profession)
            {
                FetchDTO obj = new();
                obj.Name = item.VendorName;
                obj.Id = item.VendorId;
                data.Add(obj);

            }
            return data;
        } 
        public List<BusinessDetails> FetchBusinessDetails(int businessid)
        {
            List<BusinessDetails> data = new();
            var profession = db.HealthProfessionals.Where(r => r.Profession == businessid).ToList();
            foreach (var item in profession)
            {
                BusinessDetails obj = new();
                obj.Name = item.VendorName;
                obj.Businessid = item.VendorId;
                obj.BusinessContact = item.BusinessContact;
                obj.Email = item.Email;
                obj.FaxNumber = item.FaxNumber;
                data.Add(obj);

            }
            return data;
        }

        public List<FetchDTO> GetMenus(int AcType)
        {
            List<FetchDTO> data = new();

            if(AcType == 0)
            {
                var menu = db.Menus.ToList();
                foreach (var item in menu)
                {
                    FetchDTO obj = new();
                    obj.Id = item.MenuId;
                    obj.Name = item.Name;

                    data.Add(obj);

                }
            }
            else
            {
                var menu = db.Menus.Where(a=>a.AccountType == AcType).ToList();
                foreach (var item in menu)
                {
                    FetchDTO obj = new();
                    obj.Id = item.MenuId;
                    obj.Name = item.Name;

                    data.Add(obj);

                }
            }
           
            return data;
        }

        public List<SelectedMenus> GetSelectedMenu(int type, int roleid)
        {
            List<SelectedMenus> data = new();

            var avimenus = db.RoleMenus.Where(a => a.RoleId == roleid).ToList();

            var allmenu = db.Menus.Where(a => a.AccountType == type).ToList();

            foreach(var item in allmenu)
            {
                SelectedMenus obj = new SelectedMenus()
                {
                    id = item.MenuId,
                    name = item.Name,
                    isSelected = avimenus.Any(b => b.MenuId == item.MenuId)
                };
                data.Add(obj);
            }

            return data;
        }

        
    }
}
