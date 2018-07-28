using AutoMapper;
using SPA.DocumentManager.TaskBooks;
using SPA.DocumentManager.TaskBooks;

namespace SPA.DocumentManager.TaskBooks.Dtos
{

	/// <summary>
	/// 配置TaskBook的AutoMapper
	/// </summary>
	internal static class CustomerTaskBookMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <TaskBook, TaskBookListDto>();
            configuration.CreateMap <TaskBookEditDto, TaskBook>();
		
		    
			
		    //// custom codes 
		    
            //// custom codes end

        }
    }
}