using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using SPA.DocumentManager.Plans;
using SPA.DocumentManager.SubSpecialPlans;
using SPA.DocumentManager.TaskBooks;

namespace SPA.DocumentManager.SpecialPlans
{
    public class SpecialPlan: FullAuditedEntity<int>
    {
        /// <summary>
        /// 任务所属专项ID
        /// </summary>
        [Required]
        public int SpecialPlanTypeId { get; set; }

        /// <summary>
        /// 专项名称
        /// </summary>
        public SpecialPlanType SpecialPlanType { get; set; }

        /// <summary>
        /// 主要内容
        /// </summary>
        [StringLength(DocumentManagerConsts.MaxSpecialPlanMainContentLength)]
        [Required]
        public string MainContent { get; set; }

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
        /// 计划成本
        /// </summary>
        [Required]
        public double PlannedCost { get; set; }


        /// <summary>
        /// 完成时间
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime CompleteDate { get; set; }

        /// <summary>
        /// 所属年限
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy}")]
        public DateTime Year { get; set; }

        public int PlanId { get; set; }

        public Plan Plan { get; set; }
    }
}
