using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SG.Domain.Helpers
{
    public interface IFileHelper
    {
        Task<string> saveImageAndGetFileName(IFormFile file,string destination_folder,string file_prefix="");
    }
}
