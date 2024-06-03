using DataLayer.DTO;
using DataLayer.DTO.AdminDTO;

namespace BusinessLayer.Utility
{
    public interface IFetchData
    {
        List<FetchDTO> FetchBusiness(int businessid);
        List<BusinessDetails> FetchBusinessDetails(int businessid);
        List<FetchDTO> FetchPhysician();
        List<FetchDTO> FetchPhysicianByRegion(int regid);
        List<FetchDTO> FetchProfession();
        List<FetchDTO> FetchRegions();
        List<FetchDTO> FetchRoles();
        List<FetchDTO> GetMenus(int AcType);
        List<SelectedMenus> GetSelectedMenu(int type, int roleid);
        List<FetchDTO> RegionsOfPhy(int phyid);
    }
}