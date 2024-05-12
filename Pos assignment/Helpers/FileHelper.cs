using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace SAIM_Alumni_APP.Helpers
{
    public class FileHelper : IFileHelper
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public FileHelper(Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment)
        {
            hostingEnvironment = _hostingEnvironment;
        }

        public bool isImageValid(string fileName)
        {
            var allowedExtensions = new[] {".jpeg", ".png", ".jpg",".mp3",".wav"};
            var extension = Path.GetExtension(fileName).ToLower();
            if (!allowedExtensions.Contains(extension))
                return false;
            return true;
        }

        public bool isExcelFileValid(string fileName)
        {
            var allowedExtensions = new[] {".xlsx", ".xls"};
            var extension = Path.GetExtension(fileName).ToLower();
            return allowedExtensions.Contains(extension);
        }

        public string saveImageAndGetFileName(IFormFile file, string file_prefix = "")
        {
            if (!isImageValid(file.FileName))
            {
                throw new Exception("invalid Document format. Document must be an image.");
            }
            Random random = new Random();

            string file_name = "";
            if (string.IsNullOrWhiteSpace(file_prefix))
            {
                file_name = Path.GetFileNameWithoutExtension(file.FileName) + random.Next(1, 1232384943) + Path.GetExtension(file.FileName);
            }
            else
            {
                file_name = file_prefix + random.Next(1, 1232384943) + Path.GetExtension(file.FileName);
            }
            var filePath = getUploadDirectory(file_prefix);
            filePath = Path.Combine(filePath, file_name);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return file_name;
        }

        private static string getFileName(IFormFile file, string file_prefix)
        {
            Random random = new Random();

            var fileName = "";
            if (string.IsNullOrWhiteSpace(file_prefix))
            {
                fileName = Path.GetFileNameWithoutExtension(file.FileName) + random.Next(1, 1232384943) +
                           Path.GetExtension(file.FileName);
            }
            else
            {
                fileName = file_prefix + random.Next(1, 1232384943) + Path.GetExtension(file.FileName);
            }

            return fileName;
        }

        public string saveAudioAndGetFileName(IFormFile audioFile, string filePrefix = "", string file_path = "")
        {
            var fileName = getFileName(audioFile, filePrefix);
            var filePath = getUploadDirectory(file_path, "audio");
            filePath = Path.Combine(filePath, fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            audioFile.CopyTo(stream);
            return fileName;
        }

        public string getUploadDirectory(string filePath, string fileType = "image")
        {
            return Path.Combine(hostingEnvironment.WebRootPath, $"{fileType}/{filePath}");
        }
    }
}