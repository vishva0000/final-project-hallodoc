using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interface;
using DataLayer.DTO.AdminDTO;
using DataLayer.Models;
using static DataLayer.DTO.AdminDTO.ProviderProfileData;

namespace BusinessLayer.Repository.Implementation
{
    public class ProviderProfile : IProviderProfile
    {
        public HallodocContext db;

        public ProviderProfile(HallodocContext context)
        {
            this.db = context;

        }

      public int phyid(string usermail)
        {
            int Providerid = db.Physicians.Where(a => a.Email == usermail).FirstOrDefault().PhysicianId;
            return Providerid;
        }

        public void ResetPassword(int id, string pass)
        {
            var aspid = db.Physicians.Where(a => a.PhysicianId == id).FirstOrDefault().AspNetUserId;
            var asp = db.AspNetUsers.Where(a => a.Id == aspid).FirstOrDefault();
            asp.PasswordHash = pass;
            db.AspNetUsers.Update(asp);
            db.SaveChanges();

        }
    }
}
