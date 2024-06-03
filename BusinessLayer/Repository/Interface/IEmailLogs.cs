using DataLayer.DTO;
using DataLayer.DTO.AdminDTO;

namespace BusinessLayer.Repository.Interface
{
    public interface IEmailLogs
    {
        void addEmailLog(EmailLogDto model);
        List<EmailLogData> getAllMail();
        List<EmailLogData> getEmailBySearch(int Role, string ReceiverName, string Email, DateTime CreatedDate, DateTime SentDate);
    }
}