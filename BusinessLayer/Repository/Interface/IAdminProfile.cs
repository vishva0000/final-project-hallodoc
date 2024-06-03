using DataLayer.DTO.AdminDTO;

namespace BusinessLayer.Repository.Interface
{
    public interface IAdminProfile
    {
        ProfileData AdminProfileDetails(int id);
        public void editMail(ProfileData model);
        public void adminDetailsEdit(ProfileData model);
        public void resetAdminPass(string Username, string Password);
        int getAdminId(string email);
    }
}