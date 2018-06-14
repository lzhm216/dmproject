using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;

using System.Linq.Dynamic.Core;
using Abp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

using SPA.DocumentManager.Attachments.Dtos;
using SPA.DocumentManager.Plans;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Net;
using Abp.Extensions;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using SPA.DocumentManager.Net.MimeTypes;

namespace SPA.DocumentManager.Attachments
{
    /// <summary>
    /// Attachment应用层服务的接口实现方法
    /// </summary>

    public class AttachmentAppService : DocumentManagerAppServiceBase, IAttachmentAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<Attachment, int> _attachmentRepository;
        private readonly IRepository<Plan, int> _planRepository;
        //private readonly IHostingEnvironment _host;
        private readonly IAppFolders _appFolders;
        /// <summary>
        /// 构造函数
        /// </summary>
        public AttachmentAppService(IAppFolders appFolders, IRepository<Attachment, int> attachmentRepository, IRepository<Plan, int> planRepository

            )
        {
            _appFolders = appFolders;
            _attachmentRepository = attachmentRepository;
            _planRepository = planRepository;
        }

        /// <summary>
        /// 获取Attachment的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<AttachmentListDto>> GetPagedAttachments(GetAttachmentsInput input)
        {

            var query = _attachmentRepository.GetAll();

            var attachmentCount = await query.CountAsync();

            var attachments = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            //var attachmentListDtos = ObjectMapper.Map<List <AttachmentListDto>>(attachments);
            var attachmentListDtos = attachments.MapTo<List<AttachmentListDto>>();

            return new PagedResultDto<AttachmentListDto>(
                attachmentCount,
                attachmentListDtos
                );

        }
        public async Task<PagedResultDto<AttachmentListDto>> GetPagedAttachmentsByPlanId(GetAttachmentsInput input)
        {

            var query = _attachmentRepository.GetAll().Include(t=>t.Plan).WhereIf(input.PlanId != null, t => t.PlanId == input.PlanId);
            
            var attachmentCount = await query.CountAsync();

            var attachments = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            //var attachmentListDtos = ObjectMapper.Map<List <AttachmentListDto>>(attachments);
            var attachmentListDtos = attachments.MapTo<List<AttachmentListDto>>();

            return new PagedResultDto<AttachmentListDto>(
                attachmentCount,
                attachmentListDtos
            );

        }
        /// <summary>
        /// 通过指定id获取AttachmentListDto信息
        /// </summary>
        public async Task<AttachmentListDto> GetAttachmentByIdAsync(EntityDto<int> input)
        {
            var entity = await _attachmentRepository.GetAsync(input.Id);

            return entity.MapTo<AttachmentListDto>();
        }

        /// <summary>
        /// 导出Attachment为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetAttachmentsToExcel(){
        //var users = await UserManager.Users.ToListAsync();
        //var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
        //await FillRoleNames(userListDtos);
        //return _userListExcelExporter.ExportToFile(userListDtos);
        //}
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetAttachmentForEditOutput> GetAttachmentForEdit(NullableIdDto<int> input)
        {
            var output = new GetAttachmentForEditOutput();
            AttachmentEditDto attachmentEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _attachmentRepository.GetAsync(input.Id.Value);

                attachmentEditDto = entity.MapTo<AttachmentEditDto>();

                //attachmentEditDto = ObjectMapper.Map<List <attachmentEditDto>>(entity);
            }
            else
            {
                attachmentEditDto = new AttachmentEditDto();
            }

            output.Attachment = attachmentEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改Attachment的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateAttachment(CreateOrUpdateAttachmentInput input)
        {

            if (input.Attachment.Id.HasValue)
            {
                await UpdateAttachmentAsync(input.Attachment);
            }
            else
            {
                await CreateAttachmentAsync(input.Attachment);
            }
        }


        public async Task<AttachmentListDto> Upload(int planId, IFormFile file)
        {
            if (file == null)
            {
                throw new ArgumentNullException();
            }

            var plan = await _planRepository.GetAll().Where(a => a.Id == planId).Include(a=>a.Attachments).FirstAsync();
            if (plan == null)
            {
                throw new EntityNotFoundException();
            }

            if (plan.Attachments.Count(t => t.FileName.Equals(file.FileName)) > 0)
            {
                throw new Exception("该附件已经存在");
            }

            var uploadsFolderPath = _appFolders.TempFileDownloadFolder;
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            Attachment attachment = new Attachment
            {
                FileFormat = Path.GetExtension(file.FileName),
                FileName = file.FileName,
                Length = file.Length,
                NewFileName = fileName,
                PlanId = planId
            };

            var entity = await _attachmentRepository.InsertAsync(attachment);
            //var entity = await _attachmentRepository.GetAsync(attId);

            if (plan.Attachments == null)
            {
                plan.Attachments = new List<Attachment>();
            }
            plan.Attachments.Add(entity);

            return entity.MapTo<AttachmentListDto>();
        }

        public virtual async Task<AttachmentListDto> Download(AttachmentDownloadInput input)
        {
            var attachment = await _attachmentRepository.GetAll().Where(t => t.PlanId == input.PlanId)
                .WhereIf(!input.FileName.IsNullOrEmpty(), t => t.FileName.Equals(input.FileName)).FirstOrDefaultAsync();

            var path = Path.Combine(_appFolders.TempFileDownloadFolder, attachment.NewFileName);
            var fileExtensionName = Path.GetExtension(path);

            var mimeType = GetMimeType(fileExtensionName);

            var zipFileDto = new AttachmentListDto(attachment.NewFileName, mimeType);

            return zipFileDto;
        }

        private string GetMimeType(string fileExtensionName)
        {
            string mimeTypes = "";
            switch (fileExtensionName.ToLower())
            {
                case ".docx":
                    mimeTypes = MimeTypeNames.ApplicationVndOpenxmlformatsOfficedocumentWordprocessingmlDocument;
                    break;
                case ".doc":
                    mimeTypes = MimeTypeNames.ApplicationMsword;
                    break;
                case ".pdf":
                    mimeTypes = MimeTypeNames.ApplicationPdf;
                    break;
                case ".xls":
                    mimeTypes = MimeTypeNames.ApplicationVndMsExcel;
                    break;
                case ".xlsx":
                    mimeTypes = MimeTypeNames.ApplicationVndOpenxmlformatsOfficedocumentSpreadsheetmlSheet;
                    break;
                case ".gif":
                    mimeTypes = MimeTypeNames.ImageGif;
                    break;
                case ".jpg":
                    mimeTypes = MimeTypeNames.ImageJpeg;
                    break;
                case ".jpeg":
                    mimeTypes = MimeTypeNames.ImageJpeg;
                    break;
                case "png":
                    mimeTypes = MimeTypeNames.ImagePng;
                    break;
                case ".tiff":
                    mimeTypes = MimeTypeNames.ImageTiff;
                    break;
                case ".txt":
                    mimeTypes = MimeTypeNames.TextPlain;
                    break;
                case ".csv":
                    mimeTypes = MimeTypeNames.TextCsv;
                    break;
            }

            return mimeTypes;
        }

        /// <summary>
        /// 新增Attachment
        /// </summary>

        protected virtual async Task<AttachmentEditDto> CreateAttachmentAsync(AttachmentEditDto input)
        {
            var plan = await _planRepository.GetAsync(input.PlanId);
            if (plan == null)
            {
                throw new EntityNotFoundException();
            }

            var entity = ObjectMapper.Map<Attachment>(input);

            entity = await _attachmentRepository.InsertAsync(entity);

            plan.Attachments.Add(entity);

            return entity.MapTo<AttachmentEditDto>();
        }

        /// <summary>
        /// 编辑Attachment
        /// </summary>

        protected virtual async Task UpdateAttachmentAsync(AttachmentEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var entity = await _attachmentRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _attachmentRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除Attachment信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task DeleteAttachment(EntityDto<int> input)
        {
            //删除对应的文件
           var attachment = await _attachmentRepository.GetAsync(input.Id);
            string filePath = Path.Combine(_appFolders.TempFileDownloadFolder, attachment.NewFileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            await _attachmentRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除Attachment的方法
        /// </summary>

        public async Task BatchDeleteAttachmentsAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _attachmentRepository.DeleteAsync(s => input.Contains(s.Id));
        }
    }
}

