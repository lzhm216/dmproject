using AutoMapper;

namespace SPA.DocumentManager.SubSpecialPlans.Dtos.LTMAutoMapper
{
    /// <summary>
    /// 配置SubSpecialPlan的AutoMapper
    /// </summary>
    internal static class CustomerSubSpecialPlanMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //    configuration.CreateMap <SubSpecialPlan, SubSpecialPlanDto>();
            configuration.CreateMap<SubSpecialPlan, SubSpecialPlanListDto>();
            configuration.CreateMap<SubSpecialPlanEditDto, SubSpecialPlan>();
            // configuration.CreateMap<CreateSubSpecialPlanInput, SubSpecialPlan>();
            //        configuration.CreateMap<SubSpecialPlan, GetSubSpecialPlanForEditOutput>();
        }
    }
}