using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;

using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using SPA.DocumentManager.SubPlanProjects.Authorization;
using SPA.DocumentManager.SubPlanProjects.Dtos;
using SPA.DocumentManager.SubPlanProjects.DomainServices;

namespace SPA.DocumentManager.SubPlanProjects
{
    /// <summary>
    /// SubPlanProject应用层服务的接口实现方法
    /// </summary>
    [AbpAuthorize(SubPlanProjectAppPermissions.SubPlanProject)]
    public class SubPlanProjectAppService : DocumentManagerAppServiceBase, ISubPlanProjectAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<SubPlanProject, int> _subplanprojectRepository;
        private readonly ISubPlanProjectManager _subplanprojectManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SubPlanProjectAppService(IRepository<SubPlanProject, int> subplanprojectRepository
      , ISubPlanProjectManager subplanprojectManager
        )
        {
            _subplanprojectRepository = subplanprojectRepository;
            _subplanprojectManager = subplanprojectManager;
        }

        /// <summary>
        /// 获取SubPlanProject的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<SubPlanProjectListDto>> GetPagedSubPlanProjects(GetSubPlanProjectsInput input)
        {

            var query = _subplanprojectRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            var subplanprojectCount = await query.CountAsync();

            var subplanprojects = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            //var subplanprojectListDtos = ObjectMapper.Map<List <SubPlanProjectListDto>>(subplanprojects);
            var subplanprojectListDtos = subplanprojects.MapTo<List<SubPlanProjectListDto>>();

            return new PagedResultDto<SubPlanProjectListDto>(
                subplanprojectCount,
                subplanprojectListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取SubPlanProjectListDto信息
        /// </summary>
        public async Task<SubPlanProjectListDto> GetSubPlanProjectByIdAsync(EntityDto<int> input)
        {
            var entity = await _subplanprojectRepository.GetAsync(input.Id);

            return entity.MapTo<SubPlanProjectListDto>();
        }

        /// <summary>
        /// 导出SubPlanProject为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetSubPlanProjectsToExcel(){
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
        public async Task<GetSubPlanProjectForEditOutput> GetSubPlanProjectForEdit(NullableIdDto<int> input)
        {
            var output = new GetSubPlanProjectForEditOutput();
            SubPlanProjectEditDto subplanprojectEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _subplanprojectRepository.GetAsync(input.Id.Value);

                subplanprojectEditDto = entity.MapTo<SubPlanProjectEditDto>();

                //subplanprojectEditDto = ObjectMapper.Map<List <subplanprojectEditDto>>(entity);
            }
            else
            {
                subplanprojectEditDto = new SubPlanProjectEditDto();
            }

            output.SubPlanProject = subplanprojectEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改SubPlanProject的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateSubPlanProject(CreateOrUpdateSubPlanProjectInput input)
        {

            if (input.SubPlanProject.Id.HasValue)
            {
                await UpdateSubPlanProjectAsync(input.SubPlanProject);
            }
            else
            {
                await CreateSubPlanProjectAsync(input.SubPlanProject);
            }
        }

        /// <summary>
        /// 新增SubPlanProject
        /// </summary>
        [AbpAuthorize(SubPlanProjectAppPermissions.SubPlanProject_CreateSubPlanProject)]
        protected virtual async Task<SubPlanProjectEditDto> CreateSubPlanProjectAsync(SubPlanProjectEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<SubPlanProject>(input);

            entity = await _subplanprojectRepository.InsertAsync(entity);
            return entity.MapTo<SubPlanProjectEditDto>();
        }

        /// <summary>
        /// 编辑SubPlanProject
        /// </summary>
        [AbpAuthorize(SubPlanProjectAppPermissions.SubPlanProject_EditSubPlanProject)]
        protected virtual async Task UpdateSubPlanProjectAsync(SubPlanProjectEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var entity = await _subplanprojectRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _subplanprojectRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除SubPlanProject信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(SubPlanProjectAppPermissions.SubPlanProject_DeleteSubPlanProject)]
        public async Task DeleteSubPlanProject(EntityDto<int> input)
        {

            //TODO:删除前的逻辑判断，是否允许删除
            await _subplanprojectRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除SubPlanProject的方法
        /// </summary>
        [AbpAuthorize(SubPlanProjectAppPermissions.SubPlanProject_BatchDeleteSubPlanProjects)]
        public async Task BatchDeleteSubPlanProjectsAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _subplanprojectRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

