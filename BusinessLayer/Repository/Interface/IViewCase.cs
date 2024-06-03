using DataLayer.DTO.AdminDTO;

namespace BusinessLayer.Repository.Interface
{
    public interface IViewCase
    {
        void AddAdminNotes(string Additional, int reqid);
        void AddPhysicianNote(string Additional, int reqid);
        void AddOrders(OrderData model, int reqid);
        ViewCaseData GetCaseData(int reqId);
        ViewNotesData GetNotes(int Requestid);
        void UpdateCaseData(ViewCaseData model, int reqId);
    }
}