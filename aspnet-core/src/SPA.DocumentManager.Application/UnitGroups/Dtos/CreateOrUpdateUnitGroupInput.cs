using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.UnitGroups;

namespace SPA.DocumentManager.UnitGroups.Dtos
{
    public class CreateOrUpdateUnitGroupInput
    {
        [Required]
        public UnitGroupEditDto UnitGroup { get; set; }


		
		//// custom codes 
		
        //// custom codes end
    }
}