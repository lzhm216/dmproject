using Abp.Application.Services.Dto;
using SPA.DocumentManager.Enums.Extensions;
using SPA.DocumentManager.PlanProjectTypes;
using SPA.DocumentManager.PlanProjectTypes.Dtos;
using SPA.DocumentManager.Plans;
using SPA.DocumentManager.Plans.Dtos;

namespace SPA.DocumentManager.PlanProjects.Dtos
{
    public class PlanProjectListDto
    {
        public int ProjectTypeId { get; set; }
        public string ProjectTypeName { get; set; }
        public int Id { get; set; }
        public string SubProjectName { get; set; }
        public double PlannedWorkLoad { get; set; }
        public double PlannedCost { get; set; }
        public string Description { get; set; }
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public UnitType Unit { get; set; }
        public string UnitTypeDescription => Unit.ToDescription();

        //public PlanProjectTypeListDto PlanProjectType { get; set; }
        //public PlanListDto Plan { get; set; }
    }
}