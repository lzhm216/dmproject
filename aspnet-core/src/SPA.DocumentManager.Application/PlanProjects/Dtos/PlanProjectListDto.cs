using Abp.Application.Services.Dto;
using SPA.DocumentManager.Plans;

namespace SPA.DocumentManager.PlanProjects.Dtos
{
    public class PlanProjectListDto
    {
        public int Id { get; set; }
        public string SubProjectName { get; set; }
        public double PlannedWorkLoad { get; set; }
        public double PlannedCost { get; set; }
        public string Description { get; set; }
        public int PlanId { get; set; }
        public UnitType Unit { get; set; }
    }
}