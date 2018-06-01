using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPA.DocumentManager.PlanProjectTypes
{
    public class PlanProjectType : FullAuditedEntity<int>
    {

        [MaxLength(DocumentManagerConsts.MaxPlanProjectTypeNameLength)]
        public string PlanProjectTypeName { get; set; }
    }
}
