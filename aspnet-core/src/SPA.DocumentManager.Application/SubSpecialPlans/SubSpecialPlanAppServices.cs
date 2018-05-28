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
using SPA.DocumentManager.SubSpecialPlans.Authorization;
using SPA.DocumentManager.SubSpecialPlans.Dtos;
using SPA.DocumentManager.SubSpecialPlans.DomainServices;

namespace SPA.DocumentManager.SubSpecialPlans
{
    /// <summary>
    /// SubSpecialPlan应用层服务的接口实现方法
    /// </summary>
    [AbpAuthorize(SubSpecialPlanAppPermissions.SubSpecialPlan)]
    public class SubSpecialPlanAppService : DocumentManagerAppServiceBase, ISubSpecialPlanAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<SubSpecialPlan, int> _subspecialplanRepository;
        private readonly ISubSpecialPlanManager _subspecialplanManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SubSpecialPlanAppService(IRepository<SubSpecialPlan, int> subspecialplanRepository
      , ISubSpecialPlanManager subspecialplanManager
        )
        {
            _subspecialplanRepository = subspecialplanRepository;
            _subspecialplanManager = subspecialplanManager;
        }

        /// <summary>
        /// 获取SubSpecialPlan的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<SubSpecialPlanListDto>> GetPagedSubSpecialPlans(GetSubSpecialPlansInput input)
        {

            var query = _subspecialplanRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            var subspecialplanCount = await query.CountAsync();

            var subspecialplans = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            //var subspecialplanListDtos = ObjectMapper.Map<List <SubSpecialPlanListDto>>(subspecialplans);
            var subspecialplanListDtos = subspecialplans.MapTo<List<SubSpecialPlanListDto>>();

            return new PagedResultDto<SubSpecialPlanListDto>(
                subspecialplanCount,
                subspecialplanListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取SubSpecialPlanListDto信息
        /// </summary>
        public async Task<SubSpecialPlanListDto> GetSubSpecialPlanByIdAsync(EntityDto<int> input)
        {
            var entity = await _subspecialplanRepository.GetAsync(input.Id);

            return entity.MapTo<SubSpecialPlanListDto>();
        }

        /// <summary>
        /// 导出SubSpecialPlan为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetSubSpecialPlansToExcel(){
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
        public async Task<GetSubSpecialPlanForEditOutput> GetSubSpecialPlanForEdit(NullableIdDto<int> input)
        {
            var output = new GetSubSpecialPlanForEditOutput();
            SubSpecialPlanEditDto subspecialplanEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _subspecialplanRepository.GetAsync(input.Id.Value);

                subspecialplanEditDto = entity.MapTo<SubSpecialPlanEditDto>();

                //subspecialplanEditDto = ObjectMapper.Map<List <subspecialplanEditDto>>(entity);
            }
            else
            {
                subspecialplanEditDto = new SubSpecialPlanEditDto();
            }

            output.SubSpecialPlan = subspecialplanEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改SubSpecialPlan的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateSubSpecialPlan(CreateOrUpdateSubSpecialPlanInput input)
        {

            if (input.SubSpecialPlan.Id.HasValue)
            {
                await UpdateSubSpecialPlanAsync(input.SubSpecialPlan);
            }
            else
            {
                await CreateSubSpecialPlanAsync(input.SubSpecialPlan);
            }
        }

        /// <summary>
        /// 新增SubSpecialPlan
        /// </summary>
        [AbpAuthorize(SubSpecialPlanAppPermissions.SubSpecialPlan_CreateSubSpecialPlan)]
        protected virtual async Task<SubSpecialPlanEditDto> CreateSubSpecialPlanAsync(SubSpecialPlanEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<SubSpecialPlan>(input);

            entity = await _subspecialplanRepository.InsertAsync(entity);
            return entity.MapTo<SubSpecialPlanEditDto>();
        }

        /// <summary>
        /// 编辑SubSpecialPlan
        /// </summary>
        [AbpAuthorize(SubSpecialPlanAppPermissions.SubSpecialPlan_EditSubSpecialPlan)]
        protected virtual async Task UpdateSubSpecialPlanAsync(SubSpecialPlanEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var entity = await _subspecialplanRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _subspecialplanRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除SubSpecialPlan信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(SubSpecialPlanAppPermissions.SubSpecialPlan_DeleteSubSpecialPlan)]
        public async Task DeleteSubSpecialPlan(EntityDto<int> input)
        {

            //TODO:删除前的逻辑判断，是否允许删除
            await _subspecialplanRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除SubSpecialPlan的方法
        /// </summary>
        [AbpAuthorize(SubSpecialPlanAppPermissions.SubSpecialPlan_BatchDeleteSubSpecialPlans)]
        public async Task BatchDeleteSubSpecialPlansAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _subspecialplanRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

