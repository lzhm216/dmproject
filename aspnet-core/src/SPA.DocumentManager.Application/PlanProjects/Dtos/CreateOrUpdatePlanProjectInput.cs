using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.PlanProjects;

namespace SPA.DocumentManager.PlanProjects.Dtos
{
    public class CreateOrUpdatePlanProjectInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public PlanProjectEditDto PlanProject { get; set; }

}
}