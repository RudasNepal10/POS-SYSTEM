using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAIM_Alumni_APP.Helpers
{
    public interface IFileHelper
    {
        string saveImageAndGetFileName(IFormFile file, string file_prefix = "");
        string saveAudioAndGetFileName(IFormFile file, string file_prefix = "", string file_path = "");
        bool isImageValid(string file_name);
        bool isExcelFileValid(string file_name);

        string getUploadDirectory(string file_path, string file_type);
    }
}
