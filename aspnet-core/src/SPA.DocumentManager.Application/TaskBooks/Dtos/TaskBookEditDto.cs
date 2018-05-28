using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.TaskBooks.Dtos.LTMAutoMapper;
using SPA.DocumentManager.TaskBooks;

namespace SPA.DocumentManager.TaskBooks.Dtos
{
    public class TaskBookEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        [Required]
        [StringLength(DocumentManagerConsts.MaxTaskNameLength)]
        public string TaskName { get; set; }


        /// <summary>
        /// 主要任务内容
        /// </summary>
        [Required]
        [StringLength(DocumentManagerConsts.MaxTaskMainContentLength)]
        public string TaskMainContent { get; set; }
    }
}