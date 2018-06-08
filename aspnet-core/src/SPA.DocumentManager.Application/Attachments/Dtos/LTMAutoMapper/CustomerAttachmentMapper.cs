using AutoMapper;

namespace SPA.DocumentManager.Attachments.Dtos.LTMAutoMapper
{
    using SPA.DocumentManager.Plans;

    /// <summary>
    /// 配置Attachment的AutoMapper
    /// </summary>
    internal static class CustomerAttachmentMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Attachment, AttachmentListDto>();
            configuration.CreateMap<AttachmentEditDto, Attachment>();
        }
    }
}