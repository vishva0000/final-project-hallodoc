using DataLayer.DTO.AdminDTO;

namespace BusinessLayer.Repository.Interface
{
    public interface IProviderLocation
    {
        List<ProviderLocationData> getProviderLocation();
    }
}