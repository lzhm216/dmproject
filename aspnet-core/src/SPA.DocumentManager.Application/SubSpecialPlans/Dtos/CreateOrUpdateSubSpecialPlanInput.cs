using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPA.DocumentManager.SubSpecialPlans.Dtos
{
    public class CreateOrUpdateSubSpecialPlanInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public SubSpecialPlanEditDto SubSpecialPlan { get; set; }

}
}