using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPA.DocumentManager.Attachments.Dtos
{
    public class AttachmentUploadInput
    {
        [Required]
        public int PlanId { get; set; }

        public IFormFile File { get; set; }
    }
}
