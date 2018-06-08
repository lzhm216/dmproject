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
            configuration.CreateMap<Attachment, AttachmentListDto>()
                .ForMember(dest => dest.PlanName,
                    opt => opt.MapFrom(src => src.Plan.PlanName));
            configuration.CreateMap<AttachmentEditDto, Attachment>();
        }
    }
}