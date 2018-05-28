using System;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.SubSpecialPlans.Dtos.LTMAutoMapper;

namespace SPA.DocumentManager.SubSpecialPlans.Dtos
{
    public class SubSpecialPlanListDto : FullAuditedEntityDto<int>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string MainContent { get; set; }
        public double SubPlanCost { get; set; }
        public DateTime CompleteDate { get; set; }
        public string Description { get; set; }
        public int SpecialPlanId { get; set; }
    }
}