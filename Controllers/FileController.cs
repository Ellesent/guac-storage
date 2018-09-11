using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace guac_storage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
    
        // GET api/file/upload
        [HttpPost("upload")]
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            // get size 
            long size = file.Length;
        
            // Get user's temp folder, and use a random file name
            var filePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            // Create new File
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                //copy the contents of the specified file to the newly created file 
                await file.CopyToAsync(stream);
            }

            //DEBUG: Write file path to console
            Console.WriteLine("filepath:" + filePath);

            return Ok(new { size, filePath });
        }

        // GET api/file/downlaod
        [HttpGet("download/{id}")]
        public IActionResult Download(string id)
        {
            string path = @"C:\guac\" + id;

            //files = Directory.GetFiles(path);
            if (System.IO.File.Exists(path))
            {

                // Get all bytes of file and return file 
                byte[] b = System.IO.File.ReadAllBytes(path);         
                return File(b, "application/octet-stream");
            }

            else
            {
                //return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
                return Ok();
            }

           
        }

    }
}
