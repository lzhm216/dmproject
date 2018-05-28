using System;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.Plans;
using SPA.DocumentManager.SubPlanProjects.Dtos.LTMAutoMapper;

namespace SPA.DocumentManager.SubPlanProjects.Dtos
{
    public class SubPlanProjectListDto : FullAuditedEntityDto<int>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string SubProjectName { get; set; }
        public UnitType Unit { get; set; }
        public double PlannedWorkLoad { get; set; }
        public double PlannedCost { get; set; }
        public string Description { get; set; }
        public int PlanProjectId { get; set; }
    }
}