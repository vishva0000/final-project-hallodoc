using DataLayer.DTO.AdminDTO;

namespace BusinessLayer.Repository.Interface
{
    public interface IRequestedShifts
    {
        void ApproveShifts(int[] shifts);
        void DeleteShift(int[] shifts);
        List<ShiftTableData> GetPendingShifts(string search, bool? month);
    }
}