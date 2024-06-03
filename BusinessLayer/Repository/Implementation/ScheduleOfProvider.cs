using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interface;
using DataLayer.DTO.AdminDTO;
using DataLayer.Models;

namespace BusinessLayer.Repository.Implementation
{
    public class ScheduleOfProvider: IScheduleOfProvider
    {
        public HallodocContext _context;

        public ScheduleOfProvider(HallodocContext context)
        {
            _context = context;

        }

        public List<ScheduleModel> GetShift(int month, int? regionId, int phyid)
        {
            List<ScheduleModel> ScheduleDetails = new List<ScheduleModel>();

            var uniqueDates = _context.ShiftDetails.ToList()
                            .Where(sd => sd.ShiftDate.Month == month && !sd.IsDeleted[0] && (regionId == null || regionId == 0 || sd.RegionId == regionId))
                            .Select(sd => sd.ShiftDate.Date) // Select the date part of Shiftdate
                            .Distinct() // Get distinct dates
                            .ToList();


            foreach (DateTime schedule in uniqueDates)
            {
                List<ScheduleModel> ss = (from s in _context.Shifts
                                          join pd in _context.Physicians
                                          on s.PhysicianId equals pd.PhysicianId
                                          join sd in _context.ShiftDetails
                                          on s.ShiftId equals sd.ShiftId into shiftGroup
                                          from sd in shiftGroup.DefaultIfEmpty()
                                          where sd.ShiftDate == schedule && sd.IsDeleted != new BitArray(new[] { true })
                                          select new ScheduleModel
                                          {
                                              Shiftid = sd.ShiftDetailId,
                                              Status = sd.Status,
                                              Starttime = sd.StartTime,
                                              Endtime = sd.EndTime,
                                              PhysicianName = pd.FirstName + ' ' + pd.LastName,
                                              Physicianid = pd.PhysicianId
                                          }).ToList();

                ss = ss.Where(a => a.Physicianid == phyid).ToList();

                ScheduleModel temp = new ScheduleModel();
                temp.Shiftdate = schedule;
                temp.DayList = ss;

                ScheduleDetails.Add(temp);
            }
            
            return ScheduleDetails;

        }

        public List<ScheduleModel> PhysicianAll(int phyid)
        {

            List<ScheduleModel> ScheduleDetails = new List<ScheduleModel>();

            var phys = _context.Physicians.ToList();

            List<ProviderProfileData> proList = new();
            foreach (var item in phys)
            {
                ProviderProfileData d = new ProviderProfileData()
                {
                    Createddate = item.CreatedDate,
                    ProviderId = item.PhysicianId,
                    Address1 = item.Address1,
                    Address2 = item.Address2,
                    MailPhone = item.AltPhone,
                    BusinessName = item.BusinessName,
                    BusinessWebsite = item.BusinessWebsite,
                    City = item.City,
                    Firstname = item.FirstName,
                    Lastname = item.LastName,
                    Roleid = (int?)item.RoleId,
                    regionName = _context.Regions.FirstOrDefault(r => r.RegionId == (int)r.RegionId).Name,
                    Status = item.Status,
                    Email = item.Email,
                    PhotoPath = item.Photo,
                    AdminNote = item.AdminNotes,


                };
                proList.Add(d);
            }


            foreach (ProviderProfileData schedule in proList)
            {

                List<ScheduleModel> ss = (from s in _context.Shifts
                                          join pd in _context.Physicians
                                          on s.PhysicianId equals pd.PhysicianId
                                          join sd in _context.ShiftDetails
                                          on s.ShiftId equals sd.ShiftId into shiftGroup
                                          from sd in shiftGroup.DefaultIfEmpty()
                                          join rg in _context.Regions
                                          on sd.RegionId equals rg.RegionId
                                          where s.PhysicianId == schedule.ProviderId && sd.IsDeleted != new BitArray(new[] { true })
                                          select new ScheduleModel
                                          {
                                              RegionName = rg.Name,
                                              Shiftid = sd.ShiftDetailId,
                                              Status = sd.Status,
                                              Starttime = sd.StartTime,
                                              Shiftdate = sd.ShiftDate,
                                              Endtime = sd.EndTime,
                                              PhysicianName = pd.FirstName + ' ' + pd.LastName,

                                          }).ToList();

                ss = ss.Where(a => a.Physicianid == phyid).ToList();


                ScheduleModel temp = new ScheduleModel();
                temp.PhysicianName = schedule.Firstname + ' ' + schedule.Lastname;
                if (schedule.PhotoPath != null)
                {
                    temp.PhysicianPhoto = schedule.PhotoPath.Split('\\').Last();

                }
                temp.Physicianid = (int)schedule.ProviderId;
                temp.RegionName = schedule.regionName;
                temp.DayList = ss;
                ScheduleDetails.Add(temp);
            }


            //ScheduleDetails.RemoveAll(a => a.Physicianid != phyid);
            return ScheduleDetails;


        }

        public List<ScheduleModel> PhysicianByRegion(int? region, int phyid)
        {
            List<ScheduleModel> ScheduleDetails = new List<ScheduleModel>();

            var phys = _context.Physicians.Where(a => a.RegionId == region).ToList();

            List<ProviderProfileData> proList = new();
            foreach (var item in phys)
            {
                ProviderProfileData d = new ProviderProfileData()
                {
                    Createddate = item.CreatedDate,
                    ProviderId = item.PhysicianId,
                    Address1 = item.Address1,
                    Address2 = item.Address2,
                    MailPhone = item.AltPhone,
                    BusinessName = item.BusinessName,
                    BusinessWebsite = item.BusinessWebsite,
                    City = item.City,
                    Firstname = item.FirstName,
                    Lastname = item.LastName,
                    Roleid = (int?)item.RoleId,
                    regionName = _context.Regions.FirstOrDefault(r => r.RegionId == (int)r.RegionId).Name,

                    Status = item.Status,
                    Email = item.Email,
                    PhotoPath = item.Photo,
                    AdminNote = item.AdminNotes,


                };
                proList.Add(d);
            }



            foreach (ProviderProfileData schedule in proList)
            {
                List<ScheduleModel> ss = (from s in _context.Shifts
                                          join pd in _context.Physicians
                                          on s.PhysicianId equals pd.PhysicianId
                                          join sd in _context.ShiftDetails
                                          on s.ShiftId equals sd.ShiftId into shiftGroup
                                          from sd in shiftGroup.DefaultIfEmpty()
                                          join rg in _context.Regions
                                          on sd.RegionId equals rg.RegionId
                                          where s.PhysicianId == schedule.ProviderId && sd.IsDeleted != new BitArray(new[] { true })
                                          select new ScheduleModel
                                          {
                                              RegionName = rg.Abbreviation,
                                              Shiftid = sd.ShiftDetailId,
                                              Status = sd.Status,
                                              Starttime = sd.StartTime,
                                              Shiftdate = sd.ShiftDate,
                                              Endtime = sd.EndTime,
                                              PhysicianName = pd.FirstName + ' ' + pd.LastName,
                                          }).ToList();
                ss = ss.Where(a => a.Physicianid == phyid).ToList();

                ScheduleModel temp = new ScheduleModel();
                temp.PhysicianName = schedule.Firstname + ' ' + schedule.Lastname;
                if (schedule.PhotoPath != null)
                {
                    temp.PhysicianPhoto = schedule.PhotoPath.Split('\\').Last();

                }
                temp.Physicianid = (int)schedule.ProviderId;
                temp.RegionName = schedule.regionName;

                temp.DayList = ss;
                ScheduleDetails.Add(temp);
            }


            return ScheduleDetails;

        }

        public List<ValidShiftsData> isShiftValid(int Regionid, int Physicianid, DateOnly Startdate, TimeOnly Starttime, TimeOnly Endtime, int Isrepeat, int[] WeekDayForRepeat, int Repeatupto)
        {
            var shifts = _context.ShiftDetails.Where(a => (a.Shift.PhysicianId == Physicianid) && (new BitArray(1, false) == a.IsDeleted)).ToList();
            List<DateOnly> dates = new();
            List<ValidShiftsData> validdates = new();
            dates.Add(Startdate);
            List<DateOnly> newlist = new();

            if (Repeatupto != 0)
            {


                for (int i = 1; i <= Repeatupto; i++)
                {

                    if (WeekDayForRepeat.Count() != 0)
                    {
                        for (int j = 0; j < WeekDayForRepeat.Length; j++)
                        {
                            DayOfWeek desiredDayOfWeek = (DayOfWeek)WeekDayForRepeat[j];
                            DateOnly date = Startdate;

                            int start = (int)date.DayOfWeek;
                            int target = (int)desiredDayOfWeek;
                            if (target <= start)
                            {
                                target += 7;
                                date = date.AddDays(target - start);

                            }
                            else
                            {
                                date = date.AddDays(target - start);

                            }
                            dates.Add(date);
                        }
                        Startdate = Startdate.AddDays(7);

                    }

                }
            }



            foreach (var d in dates)
            {
                var pd = shifts.Where(a => a.ShiftDate.Date == d.ToDateTime(new TimeOnly())).ToList().Where(a => !a.IsDeleted.Get(0)).ToList();
                bool isValid = true;
                if (pd != null)
                {
                    foreach (var i in pd)
                    {
                        if (Starttime >= i.StartTime && Starttime <= i.EndTime)
                        {
                            isValid = false;
                        }
                        else if (Endtime >= i.StartTime && Endtime <= i.EndTime)
                        {
                            isValid = false;
                        }

                    }
                }
                if (isValid)
                    newlist.Add(d);
            }

            if (newlist.Count > 0)
            {

                foreach (var item in newlist)
                {
                    ValidShiftsData obj = new ValidShiftsData()
                    {
                        providerid = Physicianid,
                        shiftdate = item.ToDateTime(new TimeOnly()),
                        starttime = Starttime,
                        endtime = Endtime,
                        repeatupto = Repeatupto,
                        regionid = Regionid
                    };
                    validdates.Add(obj);
                }
            }


            return validdates;
        }

        public void CreateShift(List<ValidShiftsData> dates, string email)
        {
            string aspid = _context.AspNetUsers.Where(a => a.Email == email).FirstOrDefault().Id;
            if (dates.Count > 0)
            {
                dates.OrderBy(a => a.shiftdate).ToList();

                Shift s = new Shift()
                {
                    PhysicianId = dates[0].providerid,
                    StartDate = DateOnly.FromDateTime(dates[0].shiftdate),
                    IsRepeat = new BitArray(new bool[1] { true }),
                    RepeatUpto = dates[0].repeatupto,
                    CreatedBy = aspid,
                    CreatedDate = DateTime.Now

                };
                _context.Shifts.Add(s);
                foreach (var item in dates)
                {
                    ShiftDetail sd = new ShiftDetail()
                    {
                        Shift = s,
                        ShiftDate = item.shiftdate,
                        StartTime = item.starttime,
                        EndTime = item.endtime,
                        Status = 0,
                        IsDeleted = new BitArray(new bool[1] { false }),
                        RegionId = item.regionid
                    };
                    _context.ShiftDetails.Add(sd);
                }
            }
            _context.SaveChanges();
        }
    }
}
