using Microsoft.AspNetCore.Mvc;
using TravelDesk.Models;
namespace Teavel_Desk_Project.Controllers
{
    public class FileController : Controller
    {
        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile([FromForm] FileUploadModel fileUploadModel)
        {
            if (fileUploadModel == null)
            {
                return BadRequest("Invalid File");
            }
            var folderName = Path.Combine("Resources", "AllFiles");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(),folderName);
            if(!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);  
            }
             var fileName = fileUploadModel.File.FileName;
             var fullPath = Path.Combine(pathToSave,fileName);
             var dbPath  =   Path.Combine(pathToSave,fileName);
            
            using(var stream=new FileStream(fullPath,FileMode.Create)) 
                {
                fileUploadModel.File.CopyTo(stream);
                }
             
            return Ok(new {dbPath});        }
    }

}
