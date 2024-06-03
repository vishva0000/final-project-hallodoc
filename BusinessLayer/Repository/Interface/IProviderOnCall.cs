using DataLayer.DTO.AdminDTO;

namespace BusinessLayer.Repository.Interface
{
    public interface IProviderOnCall
    {
        List<OncallProviderData> getOnCallProviders(string region);
    }
}