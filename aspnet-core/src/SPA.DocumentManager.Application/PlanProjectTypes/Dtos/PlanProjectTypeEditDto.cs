using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.PlanProjectTypes.Dtos.LTMAutoMapper;
using SPA.DocumentManager.PlanProjectTypes;

namespace SPA.DocumentManager.PlanProjectTypes.Dtos
{
    public class PlanProjectTypeEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }
        public string PlanProjectTypeName { get; set; }
    }
}