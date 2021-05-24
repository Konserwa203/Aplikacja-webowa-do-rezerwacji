using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RezerwacjaPOLLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaPOL
{
    public static class ImageTool
    {
        //This class is created as a demonstration of the facade design pattern.
        public static string SaveImage(IFormFile image, IHostingEnvironment _environment)
        {
            if (image.Length > 0)
            {
                string wwwrootPath = _environment.WebRootPath;
                string fileExtension = Path.GetExtension(image.FileName);
                var guid = Guid.NewGuid().ToString().Substring(0, 4);
                string filePathLocal = guid + fileExtension;
                var filePathRoot = Path.Combine(wwwrootPath + "\\Files\\" + filePathLocal);

                using (var stream = System.IO.File.Create(filePathRoot))
                {
                    image.CopyTo(stream);
                    return filePathLocal;
                }
            }
            else return "default.png";
        }
    }
}
