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


using SPA.DocumentManager.SpecialPlanTypes.Dtos;
using SPA.DocumentManager.TaskBooks;

namespace SPA.DocumentManager.SpecialPlanTypes
{
    /// <summary>
    /// SpecialPlanType应用层服务的接口实现方法
    /// </summary>
	
    public class SpecialPlanTypeAppService : DocumentManagerAppServiceBase, ISpecialPlanTypeAppService
    {
		private readonly IRepository<SpecialPlanType, int> _specialplantypeRepository;

		
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public SpecialPlanTypeAppService(
			IRepository<SpecialPlanType, int> specialplantypeRepository
			
		)
		{
			_specialplantypeRepository = specialplantypeRepository;
			
		}
		
		
		/// <summary>
		/// 获取SpecialPlanType的分页列表信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public  async  Task<PagedResultDto<SpecialPlanTypeListDto>> GetPagedSpecialPlanTypes(GetSpecialPlanTypesInput input)
		{
		    
		    var query = _specialplantypeRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
		
			var specialplantypeCount = await query.CountAsync();
		
			var specialplantypes = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();
		
				// var specialplantypeListDtos = ObjectMapper.Map<List <SpecialPlanTypeListDto>>(specialplantypes);
				var specialplantypeListDtos =specialplantypes.MapTo<List<SpecialPlanTypeListDto>>();
		
				return new PagedResultDto<SpecialPlanTypeListDto>(
							specialplantypeCount,
							specialplantypeListDtos
					);
		}
		

		/// <summary>
		/// 通过指定id获取SpecialPlanTypeListDto信息
		/// </summary>
		public async Task<SpecialPlanTypeListDto> GetSpecialPlanTypeByIdAsync(EntityDto<int> input)
		{
			var entity = await _specialplantypeRepository.GetAsync(input.Id);
		
		    return entity.MapTo<SpecialPlanTypeListDto>();
		}
		
		/// <summary>
		/// MPA版本才会用到的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async  Task<GetSpecialPlanTypeForEditOutput> GetSpecialPlanTypeForEdit(NullableIdDto<int> input)
		{
			var output = new GetSpecialPlanTypeForEditOutput();
			SpecialPlanTypeEditDto specialplantypeEditDto;
		
			if (input.Id.HasValue)
			{
				var entity = await _specialplantypeRepository.GetAsync(input.Id.Value);
		
				specialplantypeEditDto = entity.MapTo<SpecialPlanTypeEditDto>();
		
				//specialplantypeEditDto = ObjectMapper.Map<List <specialplantypeEditDto>>(entity);
			}
			else
			{
				specialplantypeEditDto = new SpecialPlanTypeEditDto();
			}
		
			output.SpecialPlanType = specialplantypeEditDto;
			return output;
		}
		
		
		/// <summary>
		/// 添加或者修改SpecialPlanType的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async Task CreateOrUpdateSpecialPlanType(CreateOrUpdateSpecialPlanTypeInput input)
		{
		    
			if (input.SpecialPlanType.Id.HasValue)
			{
				await UpdateSpecialPlanTypeAsync(input.SpecialPlanType);
			}
			else
			{
				await CreateSpecialPlanTypeAsync(input.SpecialPlanType);
			}
		}
		

		/// <summary>
		/// 新增SpecialPlanType
		/// </summary>
		
		protected virtual async Task<SpecialPlanTypeEditDto> CreateSpecialPlanTypeAsync(SpecialPlanTypeEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增
		
			var entity = ObjectMapper.Map <SpecialPlanType>(input);
		
			entity = await _specialplantypeRepository.InsertAsync(entity);
			return entity.MapTo<SpecialPlanTypeEditDto>();
		}
		
		/// <summary>
		/// 编辑SpecialPlanType
		/// </summary>
		
		protected virtual async Task UpdateSpecialPlanTypeAsync(SpecialPlanTypeEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新
		
			var entity = await _specialplantypeRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);
		
			// ObjectMapper.Map(input, entity);
		    await _specialplantypeRepository.UpdateAsync(entity);
		}
		

		
		/// <summary>
		/// 删除SpecialPlanType信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task DeleteSpecialPlanType(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _specialplantypeRepository.DeleteAsync(input.Id);
		}
		
		
		
		/// <summary>
		/// 批量删除SpecialPlanType的方法
		/// </summary>
		
		public async Task BatchDeleteSpecialPlanTypesAsync(List<int> input)
		{
			//TODO:批量删除前的逻辑判断，是否允许删除
			await _specialplantypeRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        public async Task<ListResultDto<SpecialPlanTypeListDto>> GetAllSpecialPlanType()
        {
            var specialPlanTypes = await _specialplantypeRepository.GetAllListAsync();

            return new ListResultDto<SpecialPlanTypeListDto>(specialPlanTypes.MapTo<List<SpecialPlanTypeListDto>>());
        }

        /// <summary>
        /// 导出SpecialPlanType为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetSpecialPlanTypesToExcel()
        //{
        //	var users = await UserManager.Users.ToListAsync();
        //	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
        //	await FillRoleNames(userListDtos);
        //	return _userListExcelExporter.ExportToFile(userListDtos);
        //}



        //// custom codes 

        //// custom codes end

    }
}


 