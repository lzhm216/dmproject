using System;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.TaskBooks.Dtos.LTMAutoMapper;
using SPA.DocumentManager.TaskBooks;

namespace SPA.DocumentManager.TaskBooks.Dtos
{
    public class TaskBookListDto : FullAuditedEntityDto<int>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string TaskName { get; set; }
        public string TaskMainContent { get; set; }
    }
}