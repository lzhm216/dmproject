using AutoMapper;

namespace SPA.DocumentManager.Plans.Dtos.LTMAutoMapper
{
    /// <summary>
    /// 配置Plan的AutoMapper
    /// </summary>
    internal static class CustomerPlanMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //    configuration.CreateMap <Plan, PlanDto>();
            configuration.CreateMap<Plan, PlanListDto>();
            configuration.CreateMap<PlanEditDto, Plan>();
            // configuration.CreateMap<CreatePlanInput, Plan>();
            //        configuration.CreateMap<Plan, GetPlanForEditOutput>();
        }
    }
}