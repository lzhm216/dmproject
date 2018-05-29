using System;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.PlanProjects.Dtos.LTMAutoMapper;
using SPA.DocumentManager.PlanProjects;

namespace SPA.DocumentManager.PlanProjects.Dtos
{
    public class PlanProjectListDto : FullAuditedEntityDto<int>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string SubProjectName { get; set; }
        public double PlannedWorkLoad { get; set; }
        public double PlannedCost { get; set; }
        public string Description { get; set; }
        public int PlanId { get; set; }
    }
}