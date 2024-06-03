using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interface;
using DataLayer.Models;
using DataLayer.DTO.AdminDTO;
using System.Collections;

namespace BusinessLayer.Repository.Implementation
{
    public class AdminDashboard : IAdminDashboard
    {
        public HallodocContext db;
        public AdminDashboard(HallodocContext context)
        {
            this.db = context;
        }
        public AdminDashboarddata countrequest()
        {
            AdminDashboarddata data = new AdminDashboarddata();
            data.New = db.Requests.Where(a => (a.Status == 1) && (new BitArray(1, false) == a.IsDeleted)).Count();
            data.Pending = db.Requests.Where(a => (a.Status == 2) && (new BitArray(1, false) == a.IsDeleted)).Count();
            data.Active = db.Requests.Where(a =>( a.Status == 5 || a.Status == 4) && (new BitArray(1, false) == a.IsDeleted)).Count();
            data.Conclude = db.Requests.Where(a => (a.Status == 6) && (new BitArray(1, false) == a.IsDeleted)).Count();
            data.ToClose = db.Requests.Where(a => (a.Status == 7 || a.Status == 3 || a.Status == 8) && (new BitArray(1, false) == a.IsDeleted)).Count();
            data.UnPaid = db.Requests.Where(a => (a.Status == 9) && (new BitArray(1, false) == a.IsDeleted)).Count();
            return data;

        }

    }
}
