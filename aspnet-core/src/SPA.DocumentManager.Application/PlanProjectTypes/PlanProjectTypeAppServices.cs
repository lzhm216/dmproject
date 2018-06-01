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

using SPA.DocumentManager.PlanProjectTypes.Dtos;
using SPA.DocumentManager.PlanProjects;

namespace SPA.DocumentManager.PlanProjectTypes
{
    /// <summary>
    /// PlanProjectType应用层服务的接口实现方法
    /// </summary>

    public class PlanProjectTypeAppService : DocumentManagerAppServiceBase, IPlanProjectTypeAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<PlanProjectType, int> _planprojecttypeRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        public PlanProjectTypeAppService(IRepository<PlanProjectType, int> planprojecttypeRepository

            )
        {
            _planprojecttypeRepository = planprojecttypeRepository;

        }

        /// <summary>
        /// 获取PlanProjectType的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<PlanProjectTypeListDto>> GetPagedPlanProjectTypes(GetPlanProjectTypesInput input)
        {

            var query = _planprojecttypeRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            var planprojecttypeCount = await query.CountAsync();

            var planprojecttypes = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            //var planprojecttypeListDtos = ObjectMapper.Map<List <PlanProjectTypeListDto>>(planprojecttypes);
            var planprojecttypeListDtos = planprojecttypes.MapTo<List<PlanProjectTypeListDto>>();

            return new PagedResultDto<PlanProjectTypeListDto>(
                planprojecttypeCount,
                planprojecttypeListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取PlanProjectTypeListDto信息
        /// </summary>
        public async Task<PlanProjectTypeListDto> GetPlanProjectTypeByIdAsync(EntityDto<int> input)
        {
            var entity = await _planprojecttypeRepository.GetAsync(input.Id);

            return entity.MapTo<PlanProjectTypeListDto>();
        }

        /// <summary>
        /// 导出PlanProjectType为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetPlanProjectTypesToExcel(){
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
        public async Task<GetPlanProjectTypeForEditOutput> GetPlanProjectTypeForEdit(NullableIdDto<int> input)
        {
            var output = new GetPlanProjectTypeForEditOutput();
            PlanProjectTypeEditDto planprojecttypeEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _planprojecttypeRepository.GetAsync(input.Id.Value);

                planprojecttypeEditDto = entity.MapTo<PlanProjectTypeEditDto>();

                //planprojecttypeEditDto = ObjectMapper.Map<List <planprojecttypeEditDto>>(entity);
            }
            else
            {
                planprojecttypeEditDto = new PlanProjectTypeEditDto();
            }

            output.PlanProjectType = planprojecttypeEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改PlanProjectType的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdatePlanProjectType(CreateOrUpdatePlanProjectTypeInput input)
        {

            if (input.PlanProjectType.Id.HasValue)
            {
                await UpdatePlanProjectTypeAsync(input.PlanProjectType);
            }
            else
            {
                await CreatePlanProjectTypeAsync(input.PlanProjectType);
            }
        }

        /// <summary>
        /// 新增PlanProjectType
        /// </summary>

        protected virtual async Task<PlanProjectTypeEditDto> CreatePlanProjectTypeAsync(PlanProjectTypeEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<PlanProjectType>(input);

            entity = await _planprojecttypeRepository.InsertAsync(entity);
            return entity.MapTo<PlanProjectTypeEditDto>();
        }

        /// <summary>
        /// 编辑PlanProjectType
        /// </summary>

        protected virtual async Task UpdatePlanProjectTypeAsync(PlanProjectTypeEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var entity = await _planprojecttypeRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _planprojecttypeRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除PlanProjectType信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task DeletePlanProjectType(EntityDto<int> input)
        {

            //TODO:删除前的逻辑判断，是否允许删除
            await _planprojecttypeRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除PlanProjectType的方法
        /// </summary>

        public async Task BatchDeletePlanProjectTypesAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _planprojecttypeRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

