using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModules.GeneralModule
{
    public class SaveImage : ISaveImage
    {
        public async Task<string> SaveImageAsync(IFormFile? Image, string folderPath)
        {
            
            if (Image != null && Image.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(Image.FileName)}";
                var filePath = Path.Combine("wwwroot", folderPath, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }

                return $"{folderPath}/{fileName}";
            }
            return null;
        }
    }
}
