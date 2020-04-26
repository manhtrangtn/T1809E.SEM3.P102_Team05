using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using T1809E.SEM3.P102_Team05.Services.Implements;

namespace T1809E.SEM3.P102_Team05.Controllers
{
    public class FileUploadController : ApiController
    {
      private readonly FileUploadService _fileUploadService = new FileUploadService();
      [Route("api/UploadImage")]
      public async Task<IHttpActionResult> UploadImages()
      {
        string fileUrls = "";
        var context = HttpContext.Current;
        var root = context.Server.MapPath("~/App_Data");
        var provider = new MultipartFormDataStreamProvider(root);
        try
        {
          await Request.Content.ReadAsMultipartAsync(provider);
          foreach (var file in provider.FileData)
          {
            var url = await _fileUploadService.FileUpload(file);
            
            fileUrls += url;
            fileUrls += ";";
          }
          return Ok(fileUrls);
        }
        catch (Exception e)
        {
          return BadRequest(e.Message);
        }
      }
    }
}
