using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;


namespace SG.Domain.Helpers
{
    public class FileHelper : IFileHelper
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public FileHelper(IHostingEnvironment _hostingEnvironment)
        {
            hostingEnvironment = _hostingEnvironment;
        }

        public async Task<string> saveImageAndGetFileName(IFormFile file, string destination_folder, string file_prefix = "")
        {
            string file_name = "";
            //generate random id for file GUID 
            file_name = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var filePath = getUploadDirectory(destination_folder);
            filePath = Path.Combine(filePath, file_name);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
              await  file.CopyToAsync(stream);
            }
            return file_name;
        }

       

        public string getUploadDirectory(string filePath)
        {
            return Path.Combine(hostingEnvironment.ContentRootPath+"\\wwwroot", $"{filePath}");
        }
    }
}
