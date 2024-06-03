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
using Newtonsoft.Json.Serialization;

namespace BusinessLayer.Repository.Implementation
{
    public class RequestedShifts: IRequestedShifts
    {
        public HallodocContext db;

        public RequestedShifts(HallodocContext db)
        {

            this.db = db;

        }

        public List<ShiftTableData> GetPendingShifts(string search , bool? month)
        {
            int regid = int.Parse(search);
            List<ShiftTableData> data = new();
            if(month== false)
            {
                if (regid != 0)
                {
                    var shifts = db.ShiftDetails.Where(a => a.Status == 0 && (a.IsDeleted != new BitArray(1, true)) && (a.RegionId == regid)).Include(a => a.Shift).ThenInclude(a => a.Physician).ToList();
                    var regions = db.Regions.ToList();
                    foreach (var item in shifts)
                    {
                        var s = item.StartTime;
                        var e = item.EndTime;
                        ShiftTableData d = new ShiftTableData()
                        {
                            shiftId = item.ShiftDetailId,
                            phyName = item.Shift.Physician.FirstName + " " + item.Shift.Physician.LastName,
                            shiftDate = item.ShiftDate,
                            startTime = s,
                            endTime = e,
                            region = regions.Where(a => a.RegionId == item.RegionId).FirstOrDefault().Name.ToString(),

                        };
                        data.Add(d);
                    }
                    return data;

                }
                else
                {
                    var shifts = db.ShiftDetails.Where(a => a.Status == 0 && (a.IsDeleted != new BitArray(1, true))).Include(a => a.Shift).ThenInclude(a => a.Physician).ToList();
                    var regions = db.Regions.ToList();
                    foreach (var item in shifts)
                    {
                        var s = item.StartTime;
                        var e = item.EndTime;
                        ShiftTableData d = new ShiftTableData()
                        {
                            shiftId = item.ShiftDetailId,
                            phyName = item.Shift.Physician.FirstName + " " + item.Shift.Physician.LastName,
                            shiftDate = item.ShiftDate,
                            startTime = s,
                            endTime = e,
                            region = regions.Where(a => a.RegionId == item.RegionId).FirstOrDefault().Name.ToString(),

                        };
                        data.Add(d);
                    }
                    return data;
                }
            }
            else
            {
                if (regid != 0)
                {
                    DateTime curr = DateTime.Now;
                    var shifts = db.ShiftDetails.Where(a => a.Status == 0 && (a.IsDeleted != new BitArray(1, true)) && (a.RegionId == regid) && (a.ShiftDate.Month==curr.Month)).Include(a => a.Shift).ThenInclude(a => a.Physician).ToList();
                    var regions = db.Regions.ToList();
                    foreach (var item in shifts)
                    {
                        var s = item.StartTime;
                        var e = item.EndTime;
                        ShiftTableData d = new ShiftTableData()
                        {

                            shiftId = item.ShiftDetailId,
                            phyName = item.Shift.Physician.FirstName + " " + item.Shift.Physician.LastName,
                            shiftDate = item.ShiftDate,
                            startTime = s,
                            endTime = e,
                            region = regions.Where(a => a.RegionId == item.RegionId).FirstOrDefault().Name.ToString(),

                        };
                        data.Add(d);
                    }
                    return data;
                }
                else
                {
                    DateTime curr = DateTime.Now;
                    var shifts = db.ShiftDetails.Where(a => a.Status == 0 && (a.IsDeleted != new BitArray(1, true)) && (a.ShiftDate.Month == curr.Month)).Include(a => a.Shift).ThenInclude(a => a.Physician).ToList();
                    var regions = db.Regions.ToList();
                    foreach (var item in shifts)
                    {
                        var s = item.StartTime;
                        var e = item.EndTime;
                        ShiftTableData d = new ShiftTableData()
                        {

                            shiftId = item.ShiftDetailId,
                            phyName = item.Shift.Physician.FirstName + " " + item.Shift.Physician.LastName,
                            shiftDate = item.ShiftDate,
                            startTime = s,
                            endTime = e,
                            region = regions.Where(a => a.RegionId == item.RegionId).FirstOrDefault().Name.ToString(),

                        };
                        data.Add(d);
                    }
                    return data;

                }
            }
          
           
        }

        public void ApproveShifts(int[] shifts)
        {
            foreach(var item in shifts)
            {
                if(item != 0)
                {
                    var shift = db.ShiftDetails.Where(a => a.ShiftDetailId == item).FirstOrDefault();
                    shift.Status = 1;

                    db.ShiftDetails.Update(shift);
                }
              
            }

            db.SaveChanges();
        }
        
        public void DeleteShift(int[] shifts)
        {
            foreach(var item in shifts)
            {
                if(item != 0)
                {
                    var shift = db.ShiftDetails.Where(a => a.ShiftDetailId == item).FirstOrDefault();
                    shift.IsDeleted = new BitArray(1, true);

                    db.ShiftDetails.Update(shift);
                }
              
            }

            db.SaveChanges();
        }
    }
}
