using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.Attachments.Dtos.LTMAutoMapper;
using SPA.DocumentManager.Plans;
using System.Collections.Generic;

namespace SPA.DocumentManager.Attachments.Dtos
{
    public class AttachmentEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }
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

        /// <summary>
        /// 规划与计划ID
        /// </summary>
        public int PlanId { get; set; }
    }
}