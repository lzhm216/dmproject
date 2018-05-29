using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.PlanProjectTypes;

namespace SPA.DocumentManager.PlanProjectTypes.Dtos
{
    public class CreateOrUpdatePlanProjectTypeInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public PlanProjectTypeEditDto PlanProjectType { get; set; }

}
}