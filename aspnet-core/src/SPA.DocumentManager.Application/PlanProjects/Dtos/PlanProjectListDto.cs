using System;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.PlanProjects.Dtos.LTMAutoMapper;

namespace SPA.DocumentManager.PlanProjects.Dtos
{
    public class PlanProjectListDto : FullAuditedEntityDto<int>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string ProjectName { get; set; }
        public double PlannedCost { get; set; }
        public int PlanId { get; set; }
    }
}