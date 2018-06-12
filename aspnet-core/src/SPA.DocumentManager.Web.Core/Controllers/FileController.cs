using Abp.Auditing;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using SPA.DocumentManager.Attachments.Dtos;
using SPA.DocumentManager.Dto;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace SPA.DocumentManager.Controllers
{
    public class FileController : DocumentManagerControllerBase
    {
        private readonly IAppFolders _appFolders;

        public FileController(IAppFolders appFolders)
        {
            _appFolders = appFolders;
        }

        [DisableAuditing]
        public ActionResult DownloadTempFile(string filename)
        {
            var filePath = Path.Combine(_appFolders.TempFileDownloadFolder, filename);
            if (!System.IO.File.Exists(filePath))
            {
                throw new UserFriendlyException(L("RequestedFileDoesNotExists"));
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            //System.IO.File.Delete(filePath);
            return File(fileBytes, GetContentType(filePath), filename);
        }

        private string GetContentType(string path)

        {

            var types = GetMimeTypes();

            var ext = Path.GetExtension(path).ToLowerInvariant();

            return types[ext];

        }

        private Dictionary<string, string> GetMimeTypes()

        {

            return new
                Dictionary<string, string>

                {

                    {
                        ".txt", "text/plain"
                    },

                    {
                        ".pdf", "application/pdf"
                    },

                    {
                        ".doc", "application/vnd.ms-word"
                    },

                    {
                        ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                    },

                    {
                        ".xls", "application/vnd.ms-excel"
                    },

                    {
                        ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                    },
                    {
                        ".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"
                    },
                    {
                        ".png", "image/png"
                    },

                    {
                        ".jpg", "image/jpeg"
                    },

                    {
                        ".jpeg", "image/jpeg"
                    },

                    {
                        ".gif", "image/gif"
                    },

                    {
                        ".csv", "text/csv"
                    }

                };

        }
    }
}