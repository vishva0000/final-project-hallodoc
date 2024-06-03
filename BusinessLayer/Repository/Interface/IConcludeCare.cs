using DataLayer.DTO.ProviderDTO;

namespace BusinessLayer.Repository.Interface
{
    public interface IConcludeCare
    {
        void concludetherequest(int reqid, string usermail, string note);
        ConcludeCareData getData(int reqid);
    }
}