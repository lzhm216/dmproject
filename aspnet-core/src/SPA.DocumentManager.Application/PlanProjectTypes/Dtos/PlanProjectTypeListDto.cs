using System;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.PlanProjectTypes.Dtos.LTMAutoMapper;
using SPA.DocumentManager.PlanProjectTypes;

namespace SPA.DocumentManager.PlanProjectTypes.Dtos
{
    public class PlanProjectTypeListDto : FullAuditedEntityDto<int>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string PlanProjectTypeName { get; set; }
    }
}