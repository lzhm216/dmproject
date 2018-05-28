using System;
using System.ComponentModel.DataAnnotations;

namespace SPA.DocumentManager.SubSpecialPlans.Dtos
{
    public class SubSpecialPlanEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }
        /// <summary>
        /// 主要内容
        /// </summary>
        [StringLength(DocumentManagerConsts.MaxSpecialPlanMainContentLength)]
        [Required]
        public string MainContent { get; set; }


        /// <summary>
        /// 分项成本
        /// </summary>
        [Required]
        public double SubPlanCost { get; set; }


        /// <summary>
        /// 完成时间
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
        public DateTime CompleteDate { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(DocumentManagerConsts.MaxProjectDescriptionLength)]
        public string Description { get; set; }
        public int SpecialPlanId { get; set; }
    }
}