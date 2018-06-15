using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

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

        [JsonIgnore]
        public virtual Plan Plan { get; set; }
    }
}
