using AutoMapper;

namespace SPA.DocumentManager.PlanProjectTypes.Dtos.LTMAutoMapper
{
    using SPA.DocumentManager.PlanProjectTypes;

    /// <summary>
    /// 配置PlanProjectType的AutoMapper
    /// </summary>
    internal static class CustomerPlanProjectTypeMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //    configuration.CreateMap <PlanProjectType, PlanProjectTypeDto>();
            configuration.CreateMap<PlanProjectType, PlanProjectTypeListDto>();
            configuration.CreateMap<PlanProjectTypeEditDto, PlanProjectType>();
            // configuration.CreateMap<CreatePlanProjectTypeInput, PlanProjectType>();
            //        configuration.CreateMap<PlanProjectType, GetPlanProjectTypeForEditOutput>();
        }
    }
}