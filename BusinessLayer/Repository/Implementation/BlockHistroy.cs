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

namespace BusinessLayer.Repository.Implementation
{
    public class BlockHistroy: IBlockHistroy
    {
        public HallodocContext db;

        public BlockHistroy(HallodocContext db)
        {

            this.db = db;

        }

        public List<BlockHistroyData> getAllRequest()
        {
            List<BlockHistroyData> data = new();
            var list = db.BlockRequests.Where(a=> new BitArray(1, true) == a.IsActive).ToList();

            foreach(var item in list)
            {
                int id = int.Parse(item.RequestId);
                var patient = db.RequestClients.Where(a => a.RequestId == id).FirstOrDefault();
                
                BlockHistroyData obj = new BlockHistroyData()
                {
                    RequestId = id,
                    Name = patient.FirstName +" "+patient.LastName,
                    Phone = item.PhoneNumber,
                    Email = item.Email,
                    CreatedDate = (DateTime)item.CreatedDate,
                    Notes = item.Reason,
                    isActive = item.IsActive[0]

                };
                data.Add(obj);
            }
            return data;


        }

        public List<BlockHistroyData> getBlockRequestBySearch(string FirstName, DateTime Date, string Email, string Phone)
        {
            List<BlockHistroyData> data = new();
            var list = db.BlockRequests.Where(a => new BitArray(1, true) == a.IsActive).ToList();

            list = list.Where(a => string.IsNullOrEmpty(Email) ||
                        a.Email.Contains(Email, StringComparison.CurrentCultureIgnoreCase)).ToList();

             list = list.Where(a => string.IsNullOrEmpty(Phone) ||
                        a.PhoneNumber.Contains(Phone, StringComparison.CurrentCultureIgnoreCase)).ToList();

            //list = list.Where(a => a.CreatedDate.Date == Date.Date).ToList();

            foreach (var item in list)
            {
                int id = int.Parse(item.RequestId);
                var patient = db.RequestClients.Where(a => a.RequestId == id).FirstOrDefault();

                BlockHistroyData obj = new BlockHistroyData()
                {
                    RequestId = id,
                    Name = patient.FirstName + " " + patient.LastName,
                    Phone = item.PhoneNumber,
                    Email = item.Email,
                    CreatedDate = (DateTime)item.CreatedDate,
                    Notes = item.Reason,
                    isActive = false

                };
                data.Add(obj);

            }

            return data;
        }

        public void unblockRequest(string reqid)
        {
            var req = db.BlockRequests.Where(a => a.RequestId == reqid).FirstOrDefault();
            req.IsActive = new BitArray(1, false);
            int id = int.Parse(reqid);
            var requesttable = db.Requests.Where(a => a.RequestId == id).FirstOrDefault();
            requesttable.Status = 1;
            db.BlockRequests.Update(req);
            db.Requests.Update(requesttable);
            db.SaveChanges();
        }
    }
}
