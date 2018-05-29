using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.PlanProjects.Dtos.LTMAutoMapper;
using SPA.DocumentManager.PlanProjects;

namespace SPA.DocumentManager.PlanProjects.Dtos
{
    public class PlanProjectEditDto
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
    }
}