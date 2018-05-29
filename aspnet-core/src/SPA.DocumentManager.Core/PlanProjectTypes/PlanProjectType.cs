using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.DocumentManager.PlanProjectTypes
{
    public class PlanProjectType : FullAuditedEntity<int>
    {
        public string PlanProjectTypeName { get; set; }
    }
}
