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
        [HttpGet("download")]
        public HttpResponseMessage Download()
        {
            string path = @"C:\guac\";
            string[] files;

            files = Directory.GetFiles(path);
            if (System.IO.File.Exists(files[0]))
            {

                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                var fileStream = new FileStream(files[0], FileMode.Open);
                response.Content = new StreamContent(fileStream);
                //response.Content = new StreamContent(fileStream);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                //response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                //response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                //response.Content.Headers.ContentDisposition.FileName = "yeet";

                fileStream.Close();
                return response;
            }

            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            }

           
        }

    }
}
