using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace guac_storage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
    
        // GET api/file/upload
        [HttpGet("upload")]
        public ActionResult<string> Upload()
        {
            return "value";
        }

        // GET api/file/downlaod
        [HttpGet("download/{id}")]
        public IActionResult Download(string id)
        {
            string path = @"C:\guac\" + id;
            string[] files;

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
