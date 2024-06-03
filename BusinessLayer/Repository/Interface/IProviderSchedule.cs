using DataLayer.DTO.AdminDTO;

namespace BusinessLayer.Repository.Interface
{
    public interface IProviderSchedule
    {
        void CreateShift(List<ValidShiftsData> dates, string email);
        void DeleteShift(int id);
        void EditShift(int shiftId, DateTime Startdate, TimeOnly Starttime, TimeOnly Endtime);
        List<ScheduleModel> GetShift(int month, int? regionId);
        shift GetShiftDetails(int shiftid);
        List<ValidShiftsData> isShiftValid(int Regionid, int Physicianid, DateOnly Startdate, TimeOnly Starttime, TimeOnly Endtime, int Isrepeat, int[] WeekDayForRepeat, int Repeatupto);
        List<ScheduleModel> PhysicianAll();
        List<ScheduleModel> PhysicianByRegion(int? region);
        void ReturnShift(int id);
    }
}