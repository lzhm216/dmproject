using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace SPA.DocumentManager.TaskBooks
{
    public class TaskBook : FullAuditedEntity<int>
    {
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
