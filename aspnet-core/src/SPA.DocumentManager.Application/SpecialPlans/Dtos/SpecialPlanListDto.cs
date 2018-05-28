using System;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.SpecialPlans.Dtos.LTMAutoMapper;

namespace SPA.DocumentManager.SpecialPlans.Dtos
{
    public class SpecialPlanListDto : FullAuditedEntityDto<int>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string SpecialPlanName { get; set; }
        public double PlannedCost { get; set; }
        public int PlanId { get; set; }
    }
}