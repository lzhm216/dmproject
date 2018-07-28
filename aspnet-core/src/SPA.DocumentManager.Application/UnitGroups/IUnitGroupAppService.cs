using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.UnitGroups.Dtos;
using SPA.DocumentManager.UnitGroups;

namespace SPA.DocumentManager.UnitGroups
{
    /// <summary>
    /// UnitGroup应用层服务的接口方法
    /// </summary>
    public interface IUnitGroupAppService : IApplicationService
    {
        /// <summary>
        /// 获取UnitGroup的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<UnitGroupListDto>> GetPagedUnitGroups(GetUnitGroupsInput input);

		/// <summary>
		/// 通过指定id获取UnitGroupListDto信息
		/// </summary>
		Task<UnitGroupListDto> GetUnitGroupByIdAsync(EntityDto<int> input);


        /// <summary>
        /// 导出UnitGroup为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetUnitGroupsToExcel();

        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetUnitGroupForEditOutput> GetUnitGroupForEdit(NullableIdDto<int> input);

        //todo:缺少Dto的生成GetUnitGroupForEditOutput


        /// <summary>
        /// 添加或者修改UnitGroup的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateUnitGroup(CreateOrUpdateUnitGroupInput input);


        /// <summary>
        /// 删除UnitGroup信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteUnitGroup(EntityDto<int> input);


        /// <summary>
        /// 批量删除UnitGroup
        /// </summary>
        Task BatchDeleteUnitGroupsAsync(List<int> input);


		//// custom codes 
		
        //// custom codes end
    }
}
