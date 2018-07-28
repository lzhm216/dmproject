using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPA.DocumentManager.TaskBooks
{
    public class SpecialPlanType : FullAuditedEntity<int>
    {
        [MaxLength(DocumentManagerConsts.Max50Length)]
        public string SpecialPlanTypeName { get; set; }

        public ICollection<TaskBook> TaskBooks { get; set; }
    }
}
