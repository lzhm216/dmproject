using AutoMapper;

namespace SPA.DocumentManager.SubPlanProjects.Dtos.LTMAutoMapper
{
    /// <summary>
    /// 配置SubPlanProject的AutoMapper
    /// </summary>
    internal static class CustomerSubPlanProjectMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //    configuration.CreateMap <SubPlanProject, SubPlanProjectDto>();
            configuration.CreateMap<SubPlanProject, SubPlanProjectListDto>();
            configuration.CreateMap<SubPlanProjectEditDto, SubPlanProject>();
            // configuration.CreateMap<CreateSubPlanProjectInput, SubPlanProject>();
            //        configuration.CreateMap<SubPlanProject, GetSubPlanProjectForEditOutput>();
        }
    }
}