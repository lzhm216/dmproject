using AutoMapper;

namespace SPA.DocumentManager.TaskBooks.Dtos.LTMAutoMapper
{
    using SPA.DocumentManager.TaskBooks;

    /// <summary>
    /// 配置TaskBook的AutoMapper
    /// </summary>
    internal static class CustomerTaskBookMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //    configuration.CreateMap <TaskBook, TaskBookDto>();
            configuration.CreateMap<TaskBook, TaskBookListDto>();
            configuration.CreateMap<TaskBookEditDto, TaskBook>();
            // configuration.CreateMap<CreateTaskBookInput, TaskBook>();
            //        configuration.CreateMap<TaskBook, GetTaskBookForEditOutput>();
        }
    }
}