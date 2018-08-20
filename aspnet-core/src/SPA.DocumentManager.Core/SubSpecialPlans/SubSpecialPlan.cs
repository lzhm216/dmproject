using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using SPA.DocumentManager.Plans;
using SPA.DocumentManager.SpecialPlans;

namespace SPA.DocumentManager.SubSpecialPlans
{
    public class SubSpecialPlan: FullAuditedEntity<int>
    {
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
        /// 分项成本
        /// </summary>
        [Required]
        public double SubPlanCost { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CompleteDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(DocumentManagerConsts.MaxProjectDescriptionLength)]
        public string Description { get; set; }

        public int SpecialPlanId { get; set; }

        public SpecialPlan SpecialPlan { get; set; }
    }
}
