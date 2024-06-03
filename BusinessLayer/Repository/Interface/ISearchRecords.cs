using DataLayer.DTO.AdminDTO;

namespace BusinessLayer.Repository.Interface
{
    public interface ISearchRecords
    {
        void DeleteRequest(int reqid);
        List<SearchRecordData> getAllRequests();
        List<SearchRecordData> getRecordBySearch(int RequestStatus, string PatientName, int RequestType, DateTime? FromDateOfService, DateTime? ToDateOfService, string ProviderName, string Email, string Phone);
    }
}