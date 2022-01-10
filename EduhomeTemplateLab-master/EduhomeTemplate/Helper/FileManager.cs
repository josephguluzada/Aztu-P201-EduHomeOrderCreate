using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.Helper
{
    public class FileManager
    {
        public static string Save(string rootPath, string folder, IFormFile file)
        {
            string filename = file.FileName;
            filename = filename.Length <= 64 ? filename : (filename.Substring(filename.Length - 64, 64));
            filename = Guid.NewGuid().ToString() + filename;

            string path = Path.Combine(rootPath, folder, filename);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return filename;
        }
        public static bool Delete(string rootPath, string folder, string filename)
        {
            string path = Path.Combine(rootPath, folder, filename);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return true;
            }
            return false;
        }
    }
}
