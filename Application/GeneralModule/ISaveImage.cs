using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModules.GeneralModule
{
    public interface ISaveImage
    {
        Task<string> SaveImageAsync(IFormFile? Image, string folderPath);
    }
}
