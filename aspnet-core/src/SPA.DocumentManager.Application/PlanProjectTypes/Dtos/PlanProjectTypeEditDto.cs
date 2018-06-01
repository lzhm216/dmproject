using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.PlanProjectTypes.Dtos.LTMAutoMapper;
using SPA.DocumentManager.PlanProjects;

namespace SPA.DocumentManager.PlanProjectTypes.Dtos
{
    public class PlanProjectTypeEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }

        [MaxLength(DocumentManagerConsts.MaxPlanProjectTypeNameLength)]
        public string PlanProjectTypeName { get; set; }
    }
}