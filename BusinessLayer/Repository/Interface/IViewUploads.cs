using DataLayer.DTO.AdminDTO;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Repository.Interface
{
    public interface IViewUploads
    {
        void AddFiles(List<IFormFile> file, int reqid);
        void DeleteFile(int fileid);
        string GetFilepath(int docid);
        ViewUploadsModel Uploadedfilesdata(int viewid);
    }
}