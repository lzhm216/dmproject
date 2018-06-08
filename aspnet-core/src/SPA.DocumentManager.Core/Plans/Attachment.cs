using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPA.DocumentManager.Plans
{
    public class Attachment : FullAuditedEntity<int>
    {
        [Required]
        [StringLength(DocumentManagerConsts.MaxNewFileNameLength)]
        public string NewFileName { get; set; }

        [Required]
        [StringLength(DocumentManagerConsts.MaxFileNameLength)]
        public string FileName { get; set; }

        [Required]
        [StringLength(DocumentManagerConsts.MaxFileFormatLength)]
        public string FileFormat { get; set; }

        [Required]
        public long Length { get; set; }

        public int PlanId { get; set; }

        public Plan Plan { get; set; }
    }
}
