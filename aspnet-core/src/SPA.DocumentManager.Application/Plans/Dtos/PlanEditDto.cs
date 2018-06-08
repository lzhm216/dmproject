using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.Plans.Dtos.LTMAutoMapper;

namespace SPA.DocumentManager.Plans.Dtos
{
    public class PlanEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(DocumentManagerConsts.MaxPlanNameLength)]
        public string PlanName { get; set; }


        /// <summary>
        /// 所属年度
        /// </summary>
        [Required]
        [StringLength(DocumentManagerConsts.MaxPlanYearLength)]
        public string PlanYear { get; set; }


        /// <summary>
        /// 文件编号
        /// </summary>
        [Required]
        [StringLength(DocumentManagerConsts.MaxFileNoLength)]
        public string FileNo { get; set; }


        /// <summary>
        /// 印发时间
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
        public DateTime PublishDate { get; set; }


        /// <summary>
        /// 编制依据
        /// </summary>
        [StringLength(DocumentManagerConsts.MaxCompilationBasisLength)]
        public string CompilationBasis { get; set; }


        /// <summary>
        /// 主要内容
        /// </summary>
        [StringLength(DocumentManagerConsts.MaxMainContentLength)]
        public string MainContent { get; set; }


        /// <summary>
        /// 预算经费
        /// </summary>
        [Required]
        public double FundBudget { get; set; }


        /// <summary>
        /// 经费来源
        /// </summary>
        [StringLength(DocumentManagerConsts.MaxFinancialSourceLength)]
        public string FinancialSource { get; set; }


        public ICollection<Attachment> Attachments { get; set; }
    }
}