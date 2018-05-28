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
using SPA.DocumentManager.SpecialPlans.Authorization;
using SPA.DocumentManager.SpecialPlans.Dtos;
using SPA.DocumentManager.SpecialPlans.DomainServices;

namespace SPA.DocumentManager.SpecialPlans
{
    /// <summary>
    /// SpecialPlan应用层服务的接口实现方法
    /// </summary>
    [AbpAuthorize(SpecialPlanAppPermissions.SpecialPlan)]
    public class SpecialPlanAppService : DocumentManagerAppServiceBase, ISpecialPlanAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<SpecialPlan, int> _specialplanRepository;
        private readonly ISpecialPlanManager _specialplanManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SpecialPlanAppService(IRepository<SpecialPlan, int> specialplanRepository
      , ISpecialPlanManager specialplanManager
        )
        {
            _specialplanRepository = specialplanRepository;
            _specialplanManager = specialplanManager;
        }

        /// <summary>
        /// 获取SpecialPlan的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<SpecialPlanListDto>> GetPagedSpecialPlans(GetSpecialPlansInput input)
        {

            var query = _specialplanRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            var specialplanCount = await query.CountAsync();

            var specialplans = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            //var specialplanListDtos = ObjectMapper.Map<List <SpecialPlanListDto>>(specialplans);
            var specialplanListDtos = specialplans.MapTo<List<SpecialPlanListDto>>();

            return new PagedResultDto<SpecialPlanListDto>(
                specialplanCount,
                specialplanListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取SpecialPlanListDto信息
        /// </summary>
        public async Task<SpecialPlanListDto> GetSpecialPlanByIdAsync(EntityDto<int> input)
        {
            var entity = await _specialplanRepository.GetAsync(input.Id);

            return entity.MapTo<SpecialPlanListDto>();
        }

        /// <summary>
        /// 导出SpecialPlan为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetSpecialPlansToExcel(){
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
        public async Task<GetSpecialPlanForEditOutput> GetSpecialPlanForEdit(NullableIdDto<int> input)
        {
            var output = new GetSpecialPlanForEditOutput();
            SpecialPlanEditDto specialplanEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _specialplanRepository.GetAsync(input.Id.Value);

                specialplanEditDto = entity.MapTo<SpecialPlanEditDto>();

                //specialplanEditDto = ObjectMapper.Map<List <specialplanEditDto>>(entity);
            }
            else
            {
                specialplanEditDto = new SpecialPlanEditDto();
            }

            output.SpecialPlan = specialplanEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改SpecialPlan的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateSpecialPlan(CreateOrUpdateSpecialPlanInput input)
        {

            if (input.SpecialPlan.Id.HasValue)
            {
                await UpdateSpecialPlanAsync(input.SpecialPlan);
            }
            else
            {
                await CreateSpecialPlanAsync(input.SpecialPlan);
            }
        }

        /// <summary>
        /// 新增SpecialPlan
        /// </summary>
        [AbpAuthorize(SpecialPlanAppPermissions.SpecialPlan_CreateSpecialPlan)]
        protected virtual async Task<SpecialPlanEditDto> CreateSpecialPlanAsync(SpecialPlanEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<SpecialPlan>(input);

            entity = await _specialplanRepository.InsertAsync(entity);
            return entity.MapTo<SpecialPlanEditDto>();
        }

        /// <summary>
        /// 编辑SpecialPlan
        /// </summary>
        [AbpAuthorize(SpecialPlanAppPermissions.SpecialPlan_EditSpecialPlan)]
        protected virtual async Task UpdateSpecialPlanAsync(SpecialPlanEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var entity = await _specialplanRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _specialplanRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除SpecialPlan信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(SpecialPlanAppPermissions.SpecialPlan_DeleteSpecialPlan)]
        public async Task DeleteSpecialPlan(EntityDto<int> input)
        {

            //TODO:删除前的逻辑判断，是否允许删除
            await _specialplanRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除SpecialPlan的方法
        /// </summary>
        [AbpAuthorize(SpecialPlanAppPermissions.SpecialPlan_BatchDeleteSpecialPlans)]
        public async Task BatchDeleteSpecialPlansAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _specialplanRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

