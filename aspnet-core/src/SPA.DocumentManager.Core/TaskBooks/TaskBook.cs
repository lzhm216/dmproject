using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using SPA.DocumentManager.UnitGroups;

namespace SPA.DocumentManager.TaskBooks
{
    public class TaskBook : FullAuditedEntity<int>
    {
        /// <summary>
        /// 任务所属专项ID
        /// </summary>
        [Required]
        public int SpecialPlanTypeId { get; set; }


        public SpecialPlanType SpecialPlanType { get; set; }

        /// <summary>
        /// 任务书编号
        /// </summary>
        [Required]
        [StringLength(DocumentManagerConsts.Max50Length)]
        public string TaskBookNo { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        [Required]
        [StringLength(DocumentManagerConsts.Max100Length)]
        public string TaskName { get; set; }

        /// <summary>
        /// 经费
        /// </summary>
        [Required]
        public double Funds { get; set; }
        
        [DisplayFormat(DataFormatString = "yyyy")]
        public DateTime Year { get; set; }
        /// <summary>
        /// 承担单位ID
        /// </summary>
        [Required(ErrorMessage = "UndertakingUnitGroupId不能为空")]
        public int UndertakingUnitGroupId { get; set; }
        /// <summary>
        /// 承担单位
        /// </summary>
        [Required]
        public UnitGroup UndertakingUnitGroup { get; set; }

        /// <summary>
        /// 签订日期
        /// </summary>
        [Required]
        public DateTime SignDate { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        [Required]
        public DateTime CompleteDate { get; set; }
        
        [StringLength(DocumentManagerConsts.Max500Length, ErrorMessage = "输入内容长度不能超过250字")]
        public string TaskContent { get; set; }

        [StringLength(DocumentManagerConsts.Max500Length, ErrorMessage = "输入内容长度不能超过250字")]
        public string Description { get; set; }
    }
}
