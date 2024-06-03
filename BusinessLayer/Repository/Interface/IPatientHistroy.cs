using DataLayer.DTO.AdminDTO;

namespace BusinessLayer.Repository.Interface
{
    public interface IPatientHistroy
    {
        List<PatientHistroyData> getAllUsers();
        List<PatientRecordData> getPatientRecord(int Userid);
        List<PatientHistroyData> getUsersBySearch(string FirstName, string LastName, string Email, string Phone);
    }
}