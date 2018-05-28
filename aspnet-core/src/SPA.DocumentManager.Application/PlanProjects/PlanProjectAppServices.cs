using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;

using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using SPA.DocumentManager.PlanProjects.Authorization;
using SPA.DocumentManager.PlanProjects.Dtos;
using SPA.DocumentManager.PlanProjects.DomainServices;

namespace SPA.DocumentManager.PlanProjects
{
    /// <summary>
    /// PlanProject应用层服务的接口实现方法
    /// </summary>
    [AbpAuthorize(PlanProjectAppPermissions.PlanProject)]
    public class PlanProjectAppService : DocumentManagerAppServiceBase, IPlanProjectAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<PlanProject, int> _planprojectRepository;
        private readonly IPlanProjectManager _planprojectManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        public PlanProjectAppService(IRepository<PlanProject, int> planprojectRepository
      , IPlanProjectManager planprojectManager
        )
        {
            _planprojectRepository = planprojectRepository;
            _planprojectManager = planprojectManager;
        }

        /// <summary>
        /// 获取PlanProject的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<PlanProjectListDto>> GetPagedPlanProjects(GetPlanProjectsInput input)
        {

            var query = _planprojectRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            var planprojectCount = await query.CountAsync();

            var planprojects = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            //var planprojectListDtos = ObjectMapper.Map<List <PlanProjectListDto>>(planprojects);
            var planprojectListDtos = planprojects.MapTo<List<PlanProjectListDto>>();

            return new PagedResultDto<PlanProjectListDto>(
                planprojectCount,
                planprojectListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取PlanProjectListDto信息
        /// </summary>
        public async Task<PlanProjectListDto> GetPlanProjectByIdAsync(EntityDto<int> input)
        {
            var entity = await _planprojectRepository.GetAsync(input.Id);

            return entity.MapTo<PlanProjectListDto>();
        }

        /// <summary>
        /// 导出PlanProject为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetPlanProjectsToExcel(){
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
        public async Task<GetPlanProjectForEditOutput> GetPlanProjectForEdit(NullableIdDto<int> input)
        {
            var output = new GetPlanProjectForEditOutput();
            PlanProjectEditDto planprojectEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _planprojectRepository.GetAsync(input.Id.Value);

                planprojectEditDto = entity.MapTo<PlanProjectEditDto>();

                //planprojectEditDto = ObjectMapper.Map<List <planprojectEditDto>>(entity);
            }
            else
            {
                planprojectEditDto = new PlanProjectEditDto();
            }

            output.PlanProject = planprojectEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改PlanProject的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdatePlanProject(CreateOrUpdatePlanProjectInput input)
        {

            if (input.PlanProject.Id.HasValue)
            {
                await UpdatePlanProjectAsync(input.PlanProject);
            }
            else
            {
                await CreatePlanProjectAsync(input.PlanProject);
            }
        }

        /// <summary>
        /// 新增PlanProject
        /// </summary>
        [AbpAuthorize(PlanProjectAppPermissions.PlanProject_CreatePlanProject)]
        protected virtual async Task<PlanProjectEditDto> CreatePlanProjectAsync(PlanProjectEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<PlanProject>(input);

            entity = await _planprojectRepository.InsertAsync(entity);
            return entity.MapTo<PlanProjectEditDto>();
        }

        /// <summary>
        /// 编辑PlanProject
        /// </summary>
        [AbpAuthorize(PlanProjectAppPermissions.PlanProject_EditPlanProject)]
        protected virtual async Task UpdatePlanProjectAsync(PlanProjectEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var entity = await _planprojectRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _planprojectRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除PlanProject信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(PlanProjectAppPermissions.PlanProject_DeletePlanProject)]
        public async Task DeletePlanProject(EntityDto<int> input)
        {

            //TODO:删除前的逻辑判断，是否允许删除
            await _planprojectRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除PlanProject的方法
        /// </summary>
        [AbpAuthorize(PlanProjectAppPermissions.PlanProject_BatchDeletePlanProjects)]
        public async Task BatchDeletePlanProjectsAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _planprojectRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

