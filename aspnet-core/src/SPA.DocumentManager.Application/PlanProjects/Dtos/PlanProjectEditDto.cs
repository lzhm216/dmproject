using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.PlanProjects.Dtos.LTMAutoMapper;

namespace SPA.DocumentManager.PlanProjects.Dtos
{
    public class PlanProjectEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }
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
        public int PlanId { get; set; }
    }
}