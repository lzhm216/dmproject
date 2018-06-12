using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Http;
using SPA.DocumentManager.Attachments.Dtos;
using SPA.DocumentManager.Plans;

namespace SPA.DocumentManager.Attachments
{
    /// <summary>
    /// Attachment应用层服务的接口方法
    /// </summary>
    public interface IAttachmentAppService : IApplicationService
    {
        /// <summary>
        /// 获取Attachment的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<AttachmentListDto>> GetPagedAttachments(GetAttachmentsInput input);

        /// <summary>
        /// 通过指定id获取AttachmentListDto信息
        /// </summary>
        Task<AttachmentListDto> GetAttachmentByIdAsync(EntityDto<int> input);
        

        Task<PagedResultDto<AttachmentListDto>> GetPagedAttachmentsByPlanId(GetAttachmentsInput input);
        /// <summary>
        /// 导出Attachment为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetAttachmentsToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetAttachmentForEditOutput> GetAttachmentForEdit(NullableIdDto<int> input);

        Task<AttachmentListDto> Download(AttachmentDownloadInput input);

        Task<AttachmentEditDto> Upload(int planId, IFormFile file);

        //todo:缺少Dto的生成GetAttachmentForEditOutput
        /// <summary>
        /// 添加或者修改Attachment的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateAttachment(CreateOrUpdateAttachmentInput input);

        /// <summary>
        /// 删除Attachment信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteAttachment(EntityDto<int> input);

        /// <summary>
        /// 批量删除Attachment
        /// </summary>
        Task BatchDeleteAttachmentsAsync(List<int> input);
    }
}
