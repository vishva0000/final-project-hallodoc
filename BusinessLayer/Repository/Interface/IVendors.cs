using DataLayer.DTO.AdminDTO;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer.Repository.Interface
{
    public interface IVendors
    {
        void CreateBusiness(CreateBusinessData model);
        void DeleteVendor(int id);
        CreateBusinessData getDataOfVendor(int id);
        List<VendorsData> GetVendors(string profId, string search);
        void UpdateVendorData(CreateBusinessData model);
    }
}