using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using SPA.DocumentManager.PlanProjectTypes;
using SPA.DocumentManager.Plans;

namespace SPA.DocumentManager.PlanProjects
{
    /// <summary>
    /// 计划测绘项目
    /// </summary>
    public class PlanProject : FullAuditedEntity<int>
    {
        /// <summary>
        /// 测绘项目名称ID
        /// </summary>
        public int ProjectTypeId { get; set; }
        /// <summary>
        /// 测绘项目名称
        /// </summary>
        public PlanProjectType PlanProjectType { get; set; }

        /// <summary>
        /// 综合工序及成果成图
        /// </summary>
        [Required]
        [MaxLength(DocumentManagerConsts.MaxSubProjectNameLength)]
        public string SubProjectName { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        [Required]
        public UnitType Unit { get; set; }

        /// <summary>
        /// 计划工作量
        /// </summary>
        [Required]
        public double PlannedWorkLoad { get; set; }

        /// <summary>
        /// 计划总成本
        /// </summary>
        [Required]
        public double PlannedCost { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(DocumentManagerConsts.MaxProjectDescriptionLength)]
        public string Description { get; set; }

        public int PlanId { get; set; }

        public Plan Plan { get; set; }
    }
}
