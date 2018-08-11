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
using SPA.DocumentManager.UnitGroups.Authorization;
using SPA.DocumentManager.UnitGroups.DomainServices;
using SPA.DocumentManager.UnitGroups.Dtos;
using SPA.DocumentManager.UnitGroups;

namespace SPA.DocumentManager.UnitGroups
{
    /// <summary>
    /// UnitGroup应用层服务的接口实现方法
    /// </summary>
	[AbpAuthorize(UnitGroupAppPermissions.UnitGroup)]
    public class UnitGroupAppService : DocumentManagerAppServiceBase, IUnitGroupAppService
    {
		private readonly IRepository<UnitGroup, int> _unitgroupRepository;

		private readonly IUnitGroupManager _unitgroupManager;
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public UnitGroupAppService(
			IRepository<UnitGroup, int> unitgroupRepository
			,IUnitGroupManager unitgroupManager
		)
		{
			_unitgroupRepository = unitgroupRepository;
			 _unitgroupManager=unitgroupManager;
		}
		
		
		/// <summary>
		/// 获取UnitGroup的分页列表信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public  async  Task<PagedResultDto<UnitGroupListDto>> GetPagedUnitGroups(GetUnitGroupsInput input)
		{
		    
		    var query = _unitgroupRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
		
			var unitgroupCount = await query.CountAsync();
		
			var unitgroups = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();
		
				// var unitgroupListDtos = ObjectMapper.Map<List <UnitGroupListDto>>(unitgroups);
				var unitgroupListDtos =unitgroups.MapTo<List<UnitGroupListDto>>();
		
				return new PagedResultDto<UnitGroupListDto>(
							unitgroupCount,
							unitgroupListDtos
					);
		}
		

		/// <summary>
		/// 通过指定id获取UnitGroupListDto信息
		/// </summary>
		public async Task<UnitGroupListDto> GetUnitGroupByIdAsync(EntityDto<int> input)
		{
			var entity = await _unitgroupRepository.GetAsync(input.Id);
		
		    return entity.MapTo<UnitGroupListDto>();
		}
		
		/// <summary>
		/// MPA版本才会用到的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async  Task<GetUnitGroupForEditOutput> GetUnitGroupForEdit(NullableIdDto<int> input)
		{
			var output = new GetUnitGroupForEditOutput();
			UnitGroupEditDto unitgroupEditDto;
		
			if (input.Id.HasValue)
			{
				var entity = await _unitgroupRepository.GetAsync(input.Id.Value);
		
				unitgroupEditDto = entity.MapTo<UnitGroupEditDto>();
		
				//unitgroupEditDto = ObjectMapper.Map<List <unitgroupEditDto>>(entity);
			}
			else
			{
				unitgroupEditDto = new UnitGroupEditDto();
			}
		
			output.UnitGroup = unitgroupEditDto;
			return output;
		}
		
		
		/// <summary>
		/// 添加或者修改UnitGroup的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async Task CreateOrUpdateUnitGroup(CreateOrUpdateUnitGroupInput input)
		{
		    
			if (input.UnitGroup.Id.HasValue)
			{
				await UpdateUnitGroupAsync(input.UnitGroup);
			}
			else
			{
				await CreateUnitGroupAsync(input.UnitGroup);
			}
		}
		

		/// <summary>
		/// 新增UnitGroup
		/// </summary>
		[AbpAuthorize(UnitGroupAppPermissions.UnitGroup_CreateUnitGroup)]
		protected virtual async Task<UnitGroupEditDto> CreateUnitGroupAsync(UnitGroupEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增
		
			var entity = ObjectMapper.Map <UnitGroup>(input);
		
			entity = await _unitgroupRepository.InsertAsync(entity);
			return entity.MapTo<UnitGroupEditDto>();
		}
		
		/// <summary>
		/// 编辑UnitGroup
		/// </summary>
		[AbpAuthorize(UnitGroupAppPermissions.UnitGroup_EditUnitGroup)]
		protected virtual async Task UpdateUnitGroupAsync(UnitGroupEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新
		
			var entity = await _unitgroupRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);
		
			// ObjectMapper.Map(input, entity);
		    await _unitgroupRepository.UpdateAsync(entity);
		}
		

		
		/// <summary>
		/// 删除UnitGroup信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(UnitGroupAppPermissions.UnitGroup_DeleteUnitGroup)]
		public async Task DeleteUnitGroup(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _unitgroupRepository.DeleteAsync(input.Id);
		}
		
		
		
		/// <summary>
		/// 批量删除UnitGroup的方法
		/// </summary>
		[AbpAuthorize(UnitGroupAppPermissions.UnitGroup_BatchDeleteUnitGroups)]
		public async Task BatchDeleteUnitGroupsAsync(List<int> input)
		{
			//TODO:批量删除前的逻辑判断，是否允许删除
			await _unitgroupRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        public async Task<ListResultDto<UnitGroupListDto>> GetAllUnitGroups()
        {

            var unitGroups = await _unitgroupRepository.GetAllListAsync();

            return new ListResultDto<UnitGroupListDto>(unitGroups.MapTo<List<UnitGroupListDto>>());
        }

        /// <summary>
        /// 导出UnitGroup为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetUnitGroupsToExcel()
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


 