using AutoMapper;

namespace SPA.DocumentManager.SpecialPlans.Dtos.LTMAutoMapper
{
    /// <summary>
    /// 配置SpecialPlan的AutoMapper
    /// </summary>
    internal static class CustomerSpecialPlanMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //    configuration.CreateMap <SpecialPlan, SpecialPlanDto>();
            configuration.CreateMap<SpecialPlan, SpecialPlanListDto>();
            configuration.CreateMap<SpecialPlanEditDto, SpecialPlan>();
            // configuration.CreateMap<CreateSpecialPlanInput, SpecialPlan>();
            //        configuration.CreateMap<SpecialPlan, GetSpecialPlanForEditOutput>();
        }
    }
}