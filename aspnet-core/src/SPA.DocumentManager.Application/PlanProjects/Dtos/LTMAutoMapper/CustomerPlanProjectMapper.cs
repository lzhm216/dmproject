using AutoMapper;

namespace SPA.DocumentManager.PlanProjects.Dtos.LTMAutoMapper
{
    using SPA.DocumentManager.PlanProjects;

    /// <summary>
    /// 配置PlanProject的AutoMapper
    /// </summary>
    internal static class CustomerPlanProjectMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //    configuration.CreateMap <PlanProject, PlanProjectDto>();
            configuration.CreateMap<PlanProject, PlanProjectListDto>()
                .ForMember(dest => dest.PlanProjectTypeName,
                    opt => opt.MapFrom(src => src.PlanProjectType.PlanProjectTypeName))
                .ForMember(dest => dest.PlanName, 
                    opt => opt.MapFrom(src => src.Plan.PlanName));

            configuration.CreateMap<PlanProjectEditDto, PlanProject>();
            // configuration.CreateMap<CreatePlanProjectInput, PlanProject>();
            //        configuration.CreateMap<PlanProject, GetPlanProjectForEditOutput>();
        }
    }
}