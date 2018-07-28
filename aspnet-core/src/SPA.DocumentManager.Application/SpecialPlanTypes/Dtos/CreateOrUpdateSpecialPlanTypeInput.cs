using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.TaskBooks;

namespace SPA.DocumentManager.SpecialPlanTypes.Dtos
{
    public class CreateOrUpdateSpecialPlanTypeInput
    {
        [Required]
        public SpecialPlanTypeEditDto SpecialPlanType { get; set; }


		
		//// custom codes 
		
        //// custom codes end
    }
}