using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.Plans;

namespace SPA.DocumentManager.Attachments.Dtos
{
    public class CreateOrUpdateAttachmentInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public AttachmentEditDto Attachment { get; set; }

}
}