using DataLayer.DTO.AdminDTO;

namespace BusinessLayer.Repository.Interface
{
    public interface IScheduleOfProvider
    {
        List<ScheduleModel> GetShift(int month, int? regionId, int phyid);
        List<ScheduleModel> PhysicianAll(int phyid);
        List<ScheduleModel> PhysicianByRegion(int? region, int phyid);
        void CreateShift(List<ValidShiftsData> dates, string email);
        List<ValidShiftsData> isShiftValid(int Regionid, int Physicianid, DateOnly Startdate, TimeOnly Starttime, TimeOnly Endtime, int Isrepeat, int[] WeekDayForRepeat, int Repeatupto);

    }
}