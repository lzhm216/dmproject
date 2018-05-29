using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.PlanProjectTypes.Dtos;
using SPA.DocumentManager.PlanProjectTypes;

namespace SPA.DocumentManager.PlanProjectTypes
{
    /// <summary>
    /// PlanProjectType应用层服务的接口方法
    /// </summary>
    public interface IPlanProjectTypeAppService : IApplicationService
    {
        /// <summary>
        /// 获取PlanProjectType的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PlanProjectTypeListDto>> GetPagedPlanProjectTypes(GetPlanProjectTypesInput input);

        /// <summary>
        /// 通过指定id获取PlanProjectTypeListDto信息
        /// </summary>
        Task<PlanProjectTypeListDto> GetPlanProjectTypeByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 导出PlanProjectType为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetPlanProjectTypesToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetPlanProjectTypeForEditOutput> GetPlanProjectTypeForEdit(NullableIdDto<int> input);

        //todo:缺少Dto的生成GetPlanProjectTypeForEditOutput
        /// <summary>
        /// 添加或者修改PlanProjectType的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdatePlanProjectType(CreateOrUpdatePlanProjectTypeInput input);

        /// <summary>
        /// 删除PlanProjectType信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeletePlanProjectType(EntityDto<int> input);

        /// <summary>
        /// 批量删除PlanProjectType
        /// </summary>
        Task BatchDeletePlanProjectTypesAsync(List<int> input);
    }
}
