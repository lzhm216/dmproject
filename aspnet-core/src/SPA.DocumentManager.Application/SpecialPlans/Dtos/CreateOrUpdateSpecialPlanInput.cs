using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPA.DocumentManager.SpecialPlans.Dtos
{
    public class CreateOrUpdateSpecialPlanInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public SpecialPlanEditDto SpecialPlan { get; set; }

}
}