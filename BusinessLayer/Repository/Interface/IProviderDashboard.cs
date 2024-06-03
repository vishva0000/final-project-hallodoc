using DataLayer.DTO.ProviderDTO;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Repository.Interface
{
    public interface IProviderDashboard
    {
        void AccepRequest(int reqid, string usermail);
        ProviderDashboardData Count(string usermail);
        EncounterPDF getEncounterForm(int id);
        List<ProviderRequestData> getRequestsForPhysician(int status, int requesttype, string search, string usermail);
        void HouseCallClick(int reqid);
        bool IsFinalized(int reqid);
        void SelectTypeOfCare(int careid, int selecttype);
        void TransferReqToAdmin(int reqid, string reason, string usermail);
        
        void fileUpload(List<IFormFile> ConcludeFiles, int concludeid);
    }
}