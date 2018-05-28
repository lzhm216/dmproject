using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.SpecialPlans.Dtos.LTMAutoMapper;

namespace SPA.DocumentManager.SpecialPlans.Dtos
{
    public class SpecialPlanEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }
        /// <summary>
        /// 专项名称
        /// </summary>
        [StringLength(DocumentManagerConsts.MaxSpecialPlanNameLength)]
        [Required]
        public string SpecialPlanName { get; set; }


        /// <summary>
        /// 计划成本
        /// </summary>
        [Required]
        public double PlannedCost { get; set; }
        public int PlanId { get; set; }
    }
}