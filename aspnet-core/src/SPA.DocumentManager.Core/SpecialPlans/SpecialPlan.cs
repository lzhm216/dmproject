using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using SPA.DocumentManager.Plans;
using SPA.DocumentManager.SubSpecialPlans;

namespace SPA.DocumentManager.SpecialPlans
{
    public class SpecialPlan: FullAuditedEntity<int>
    {
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

        public ICollection<SubSpecialPlan> SubSpecialPlans { get; set; }

        public int PlanId { get; set; }

        public Plan Plan { get; set; }
    }
}
