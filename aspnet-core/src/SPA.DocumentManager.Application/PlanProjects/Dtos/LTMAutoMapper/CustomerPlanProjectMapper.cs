using AutoMapper;

namespace SPA.DocumentManager.PlanProjects.Dtos.LTMAutoMapper
{
    /// <summary>
    /// 配置PlanProject的AutoMapper
    /// </summary>
    internal static class CustomerPlanProjectMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //    configuration.CreateMap <PlanProject, PlanProjectDto>();
            configuration.CreateMap<PlanProject, PlanProjectListDto>();
            configuration.CreateMap<PlanProjectEditDto, PlanProject>();
            // configuration.CreateMap<CreatePlanProjectInput, PlanProject>();
            //        configuration.CreateMap<PlanProject, GetPlanProjectForEditOutput>();
        }
    }
}