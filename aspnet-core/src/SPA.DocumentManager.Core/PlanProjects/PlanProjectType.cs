using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace SPA.DocumentManager.PlanProjects
{
    public class PlanProjectType : FullAuditedEntity<int>
    {

        [MaxLength(DocumentManagerConsts.MaxPlanProjectTypeNameLength)]
        public string PlanProjectTypeName { get; set; }

        public ICollection<PlanProject> PlanProjects { get; set; }
    }
}
