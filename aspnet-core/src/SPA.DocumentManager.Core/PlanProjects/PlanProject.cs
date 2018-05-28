using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using SPA.DocumentManager.Plans;
using SPA.DocumentManager.SubPlanProjects;

namespace SPA.DocumentManager.PlanProjects
{
    /// <summary>
    /// 计划测绘项目
    /// </summary>
    public class PlanProject : FullAuditedEntity<int>
    {
        /// <summary>
        /// 测绘项目名称
        /// </summary>
        [Required]
        [MaxLength(DocumentManagerConsts.MaxProjectNameLength)]
        public string ProjectName { get; set; }

        /// <summary>
        /// 计划总成本
        /// </summary>
        [Required]
        public double PlannedCost { get; set; }

        public ICollection<SubPlanProject> SubPlanProjects { get; set; }

        public int PlanId { get; set; }

        public Plan Plan { get; set; }
    }
}
