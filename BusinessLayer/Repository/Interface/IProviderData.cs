using BusinessLayer.Repository.Implementation;
using DataLayer.DTO.AdminDTO;

namespace BusinessLayer.Repository.Interface
{
    public interface IProviderData
    {
        void ChangeinNotification(int phyid, bool ischeck);
        List<ProviderDetails> getProviderData(string search);
    }
}