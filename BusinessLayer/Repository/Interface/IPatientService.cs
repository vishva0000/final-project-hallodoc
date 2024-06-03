using DataLayer.DTO;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Repository.Interface
{
    public interface IPatientService
    {
        void ResetPassword(string mail, string password);
        bool IsPatientPresent(string email);
        void CreatePatient(CreatePatient model);
        List<PatientDashboard> GetPatientDashboardData(string email);
        PatientProfile GetPatientProfile(string email);
        void EditPatientProfile(string email, PatientProfile model);
        ViewDocumentList GetDocuments(int RequestID);
        string GetFilePath(int id);
        void UploadFile(IFormFile file, int reqid);
        int GetUserId(int id);
        int GetUserIdByMail(string email);
        int GetReqStatus(int id);
        void Agree(int reqid);
        void CancelAgreement(string cancelnote, int reqid);
        void RequestForElse(RequestForSomeoneElse model);
        AspNetUser GetAspNetUser(string email);
        AspNetUser GetUserType(string email, string role);
        Physician GetPhysician(string id);
        Admin GetAdmin(string id);
        User GetUser(string id);
    }
}