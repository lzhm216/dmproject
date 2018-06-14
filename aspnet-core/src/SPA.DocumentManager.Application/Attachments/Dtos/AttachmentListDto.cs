using System;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.Attachments.Dtos.LTMAutoMapper;
using SPA.DocumentManager.Plans;
using System.Collections.Generic;

namespace SPA.DocumentManager.Attachments.Dtos
{
    public class AttachmentListDto
    {
        public AttachmentListDto(string newFileName, string fileFormat)
        {
            NewFileName = newFileName;
            FileFormat = fileFormat;
        }

        public int Id { get; set; }
        public string NewFileName { get; set; }
        public string FileName { get; set; }
        public string FileFormat { get; set; }
        public long Length { get; set; }
        public int PlanId { get; set; }
    }
}