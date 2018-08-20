

using AutoMapper;
using SPA.DocumentManager.SpecialPlans;

namespace SPA.DocumentManager.SpecialPlans.Dtos.CustomMapper
{

    /// <summary>
    /// 配置SpecialPlan的AutoMapper
    ///</summary>
    internal static class CustomerSpecialPlanMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<SpecialPlan, SpecialPlanListDto>
    ().ForMember(dest => dest.SpecialPlanTypeName,
                    opt => opt.MapFrom(src => src.SpecialPlanType.SpecialPlanTypeName))
                .ForMember(dest => dest.PlanName,
                    opt => opt.MapFrom(src => src.Plan.PlanName)); 

            configuration.CreateMap<SpecialPlanEditDto, SpecialPlan>
                ();



            //// custom codes

            //// custom codes end

        }
    }
}
