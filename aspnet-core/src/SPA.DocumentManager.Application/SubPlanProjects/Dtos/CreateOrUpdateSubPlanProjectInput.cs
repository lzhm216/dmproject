using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPA.DocumentManager.SubPlanProjects.Dtos
{
    public class CreateOrUpdateSubPlanProjectInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public SubPlanProjectEditDto SubPlanProject { get; set; }

}
}