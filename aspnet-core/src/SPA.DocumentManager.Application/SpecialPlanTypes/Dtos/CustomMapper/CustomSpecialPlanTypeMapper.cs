using AutoMapper;
using SPA.DocumentManager.SpecialPlanTypes;
using SPA.DocumentManager.TaskBooks;

namespace SPA.DocumentManager.SpecialPlanTypes.Dtos
{

	/// <summary>
	/// 配置SpecialPlanType的AutoMapper
	/// </summary>
	internal static class CustomerSpecialPlanTypeMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <SpecialPlanType, SpecialPlanTypeListDto>();
            configuration.CreateMap <SpecialPlanTypeEditDto, SpecialPlanType>();
		
		    
			
		    //// custom codes 
		    
            //// custom codes end

        }
    }
}