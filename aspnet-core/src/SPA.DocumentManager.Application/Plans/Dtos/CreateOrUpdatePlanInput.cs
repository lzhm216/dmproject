using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPA.DocumentManager.Plans.Dtos
{
    public class CreateOrUpdatePlanInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public PlanEditDto Plan { get; set; }

}
}