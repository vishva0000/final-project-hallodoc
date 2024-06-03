using DataLayer.DTO.AdminDTO;

namespace BusinessLayer.Repository.Interface
{
    public interface ISMSLog
    {
        void AddSMSLog(int phyid, int adminid, string msg);
        List<SMSLogData> getAllSMS();
        List<SMSLogData> getSMSBySearch(int Role, string ReceiverName, string Mobile, DateTime CreatedDate, DateTime SentDate);
    }
}