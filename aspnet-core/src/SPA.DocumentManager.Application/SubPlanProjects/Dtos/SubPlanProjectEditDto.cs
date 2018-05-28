using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.Plans;
using SPA.DocumentManager.SubPlanProjects.Dtos.LTMAutoMapper;

namespace SPA.DocumentManager.SubPlanProjects.Dtos
{
    public class SubPlanProjectEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }
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
        public int PlanProjectId { get; set; }
    }
}