using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;

using System.Linq.Dynamic.Core;
using Abp;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using SPA.DocumentManager.Plans.Authorization;
using SPA.DocumentManager.Plans.Dtos;
using SPA.DocumentManager.Plans.DomainServices;
using SPA.DocumentManager.PlanProjects;

namespace SPA.DocumentManager.Plans
{
    /// <summary>
    /// Plan应用层服务的接口实现方法
    /// </summary>
    //[AbpAuthorize(PlanAppPermissions.Plan)]
    public class PlanAppService : DocumentManagerAppServiceBase, IPlanAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<Plan, int> _planRepository;
        private readonly IRepository<PlanProjectType, int> _planProjectTypeRepository;
        private readonly IPlanManager _planManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        public PlanAppService(IRepository<Plan, int> planRepository, 
            IRepository<PlanProjectType, int> planProjectTypeRepository
      , IPlanManager planManager
        )
        {
            _planRepository = planRepository;
            _planManager = planManager;
            _planProjectTypeRepository = planProjectTypeRepository;
        }

        /// <summary>
        /// 获取Plan的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<PlanListDto>> GetPagedPlans(GetPlansInput input)
        {

            var query = _planRepository.GetAll();

            query = query.WhereIf(!string.IsNullOrEmpty(input.Filter), t => t.PlanName.Contains(input.Filter)
             || t.MainContent.Contains(input.Filter) || t.FileNo.Contains(input.Filter));
            
            var planCount = await query.CountAsync();

            var plans = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            //var planListDtos = ObjectMapper.Map<List <PlanListDto>>(plans);
            var planListDtos = plans.MapTo<List<PlanListDto>>();

            return new PagedResultDto<PlanListDto>(
                planCount,
                planListDtos
                );

        }

        public async Task<List<PlanListDto>> GetPlanList(GetPlansInput input)
        {
            var query = _planRepository.GetAll();

            var plans = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();
            
            var planListDtos = plans.MapTo<List<PlanListDto>>();

            return new List<PlanListDto>(
                planListDtos
            );

        }

        public async Task<PagedResultDto<PlanListWithProjectDto>> GetPagedPlansWithProject(GetPlansInput input)
        {
            try
            {
                var query = _planRepository.GetAll().Include(t => t.PlanProjects)
                    .WhereIf(!input.Filter.IsNullOrEmpty(),
                        t => t.PlanName.Contains(input.Filter)
                             || t.FileNo.Contains(input.Filter)
                             || t.MainContent.Contains(input.Filter));

                var planCount = await query.CountAsync();

                var plans = await query
                    .OrderByDescending(t => t.PlanYear).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

                var projectTypes = _planProjectTypeRepository.GetAll();

                foreach (var plan in plans)
                {
                    foreach (var planProject in plan.PlanProjects)
                    {
                        planProject.PlanProjectType = projectTypes.First(t => t.Id == planProject.PlanProjectTypeId);
                    }
                }
                //var planListDtos = ObjectMapper.Map<List <PlanListDto>>(plans);
                var planListDtos = plans.MapTo<List<PlanListWithProjectDto>>();

                return new PagedResultDto<PlanListWithProjectDto>(
                    planCount,
                    planListDtos
                );
            }
            catch (Exception ex)
            {

                return new PagedResultDto<PlanListWithProjectDto>(
                    0,
                    null
                );
            }
           
        }

        /// <summary>
        /// 通过指定id获取PlanListDto信息
        /// </summary>
        public async Task<PlanListDto> GetPlanByIdAsync(EntityDto<int> input)
        {
            var entity = await _planRepository.GetAsync(input.Id);

            var planListDto = entity.MapTo<PlanListDto>();

            return planListDto;
        }

        /// <summary>
        /// 获取Plans的数量
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<int> GetPlansCount(GetPlansCountInput input)
        {

            var query = _planRepository.GetAll();

            query = query.WhereIf(!string.IsNullOrEmpty(input.Filter), t => t.PlanName.Contains(input.Filter)
             || t.MainContent.Contains(input.Filter) || t.FileNo.Contains(input.Filter));

            var planCount = await query.CountAsync();

            return planCount;
        }
            /// <summary>
            /// 导出Plan为excel表
            /// </summary>
            /// <returns></returns>
            //public async Task<FileDto> GetPlansToExcel(){
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
            public async Task<GetPlanForEditOutput> GetPlanForEdit(NullableIdDto<int> input)
        {
            var output = new GetPlanForEditOutput();
            PlanEditDto planEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _planRepository.GetAsync(input.Id.Value);

                planEditDto = entity.MapTo<PlanEditDto>();

                //planEditDto = ObjectMapper.Map<List <planEditDto>>(entity);
            }
            else
            {
                planEditDto = new PlanEditDto();
            }

            output.Plan = planEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改Plan的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PlanEditDto> CreateOrUpdatePlan(CreateOrUpdatePlanInput input)
        {

            if (input.Plan.Id.HasValue)
            {
               return await UpdatePlanAsync(input.Plan);
            }
            else
            {
                return await CreatePlanAsync(input.Plan);
            }
        }

        /// <summary>
        /// 新增Plan
        /// </summary>
        //[AbpAuthorize(PlanAppPermissions.Plan_CreatePlan)]
        protected virtual async Task<PlanEditDto> CreatePlanAsync(PlanEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<Plan>(input);

            int id = await _planRepository.InsertAndGetIdAsync(entity);
            entity.Id = id;
            return entity.MapTo<PlanEditDto>();
        }

        /// <summary>
        /// 编辑Plan
        /// </summary>
        //[AbpAuthorize(PlanAppPermissions.Plan_EditPlan)]
        protected virtual async Task<PlanEditDto> UpdatePlanAsync(PlanEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var entity = await _planRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _planRepository.UpdateAsync(entity);

            return entity.MapTo<PlanEditDto>();
        }

        /// <summary>
        /// 删除Plan信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(PlanAppPermissions.Plan_DeletePlan)]
        public async Task DeletePlan(EntityDto<int> input)
        {

            //TODO:删除前的逻辑判断，是否允许删除
            await _planRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除Plan的方法
        /// </summary>
        [AbpAuthorize(PlanAppPermissions.Plan_BatchDeletePlans)]
        public async Task BatchDeletePlansAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _planRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

