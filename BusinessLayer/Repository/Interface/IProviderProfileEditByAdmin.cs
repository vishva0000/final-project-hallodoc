using DataLayer.DTO.AdminDTO;

namespace BusinessLayer.Repository.Interface
{
    public interface IProviderProfileEditByAdmin
    {
        void deleteAccount(int id);
        void EditPhysicianInfo(ProviderProfileData model);
        void EditAccountInfo(ProviderProfileData model);
        void EditPhyMailInfo(ProviderProfileData model);
        void EditPhyProfileInfo(ProviderProfileData model);
        void EditDocs(ProviderProfileData model);
        ProviderProfileData getProviderProfileData(int Providerid);
    }
}