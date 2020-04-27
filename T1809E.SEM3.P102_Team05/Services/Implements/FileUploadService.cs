using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using T1809E.SEM3.P102_Team05.Commons;

namespace T1809E.SEM3.P102_Team05.Services.Implements
{
    public class FileUploadService
    {
      public async Task<string> FileUpload(MultipartFileData file)
      {
        try
        {
          var credentials = new StorageCredentials(Constant.AccountName, Constant.AccessKeyValue);

          var account = new CloudStorageAccount(credentials, useHttps: true);

          var client = account.CreateCloudBlobClient();

          var container = client.GetContainerReference("photos");

          container.CreateIfNotExists();

          container.SetPermissions(new BlobContainerPermissions{PublicAccess = BlobContainerPublicAccessType.Blob});

          var cloudBlockBlob = container.GetBlockBlobReference(file.Headers.ContentDisposition.FileName.Trim('\"'));
          
          await cloudBlockBlob.UploadFromStreamAsync(File.OpenRead(file.LocalFileName));
          var uri = cloudBlockBlob.Uri.AbsoluteUri;

          return uri.ToString();
        }
        catch (Exception e)
        {
          Debug.WriteLine(e);
          return e.Message;
        }
      }
    }
}