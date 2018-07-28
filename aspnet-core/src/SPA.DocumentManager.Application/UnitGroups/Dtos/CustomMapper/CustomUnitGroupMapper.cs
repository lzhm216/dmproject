using AutoMapper;
using SPA.DocumentManager.UnitGroups;
using SPA.DocumentManager.UnitGroups;

namespace SPA.DocumentManager.UnitGroups.Dtos
{

	/// <summary>
	/// 配置UnitGroup的AutoMapper
	/// </summary>
	internal static class CustomerUnitGroupMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <UnitGroup, UnitGroupListDto>();
            configuration.CreateMap <UnitGroupEditDto, UnitGroup>();
		
		    
			
		    //// custom codes 
		    
            //// custom codes end

        }
    }
}