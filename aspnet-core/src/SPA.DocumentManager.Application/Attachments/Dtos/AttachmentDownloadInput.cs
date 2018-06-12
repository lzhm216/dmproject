using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPA.DocumentManager.Attachments.Dtos
{
    public class AttachmentDownloadInput
    {
        [Required]
        public int PlanId { get; set; }

        [Required]
        public string FileName { get; set; }
    }
}
