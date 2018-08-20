

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.SpecialPlans;

namespace SPA.DocumentManager.SpecialPlans.Dtos
{
    public class CreateOrUpdateSpecialPlanInput
    {
        [Required]
        public SpecialPlanEditDto SpecialPlan { get; set; }



		//// custom codes
 
        //// custom codes end
    }
}