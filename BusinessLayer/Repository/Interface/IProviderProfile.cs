namespace BusinessLayer.Repository.Interface
{
    public interface IProviderProfile
    {
        int phyid(string usermail);
        void ResetPassword(int id, string pass);
    }
}