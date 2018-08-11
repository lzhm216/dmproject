using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.SpecialPlanTypes.Dtos;
using SPA.DocumentManager.TaskBooks;

namespace SPA.DocumentManager.SpecialPlanTypes
{
    /// <summary>
    /// SpecialPlanType应用层服务的接口方法
    /// </summary>
    public interface ISpecialPlanTypeAppService : IApplicationService
    {
        /// <summary>
        /// 获取SpecialPlanType的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<SpecialPlanTypeListDto>> GetPagedSpecialPlanTypes(GetSpecialPlanTypesInput input);
        /// <summary>
        /// 获取所有的SpecialPlanType信息
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<SpecialPlanTypeListDto>> GetAllSpecialPlanType();
        /// <summary>
        /// 通过指定id获取SpecialPlanTypeListDto信息
        /// </summary>
        Task<SpecialPlanTypeListDto> GetSpecialPlanTypeByIdAsync(EntityDto<int> input);


        /// <summary>
        /// 导出SpecialPlanType为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetSpecialPlanTypesToExcel();

        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetSpecialPlanTypeForEditOutput> GetSpecialPlanTypeForEdit(NullableIdDto<int> input);

        //todo:缺少Dto的生成GetSpecialPlanTypeForEditOutput


        /// <summary>
        /// 添加或者修改SpecialPlanType的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateSpecialPlanType(CreateOrUpdateSpecialPlanTypeInput input);


        /// <summary>
        /// 删除SpecialPlanType信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteSpecialPlanType(EntityDto<int> input);


        /// <summary>
        /// 批量删除SpecialPlanType
        /// </summary>
        Task BatchDeleteSpecialPlanTypesAsync(List<int> input);


		//// custom codes 
		
        //// custom codes end
    }
}
