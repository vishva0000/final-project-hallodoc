using DataLayer.DTO.AdminDTO;

namespace BusinessLayer.Repository.Interface
{
    public interface IBlockHistroy
    {
        List<BlockHistroyData> getAllRequest();
        List<BlockHistroyData> getBlockRequestBySearch(string FirstName, DateTime Date, string Email, string Phone);
        void unblockRequest(string reqid);
    }
}