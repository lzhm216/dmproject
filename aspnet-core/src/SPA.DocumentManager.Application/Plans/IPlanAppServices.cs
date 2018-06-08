using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.Plans.Dtos;

namespace SPA.DocumentManager.Plans
{
    /// <summary>
    /// Plan应用层服务的接口方法
    /// </summary>
    public interface IPlanAppService : IApplicationService
    {
        /// <summary>
        /// 获取Plan的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PlanListDto>> GetPagedPlans(GetPlansInput input);

        /// <summary>
        /// 通过指定id获取PlanListDto信息
        /// </summary>
        Task<PlanListDto> GetPlanByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 导出Plan为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetPlansToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetPlanForEditOutput> GetPlanForEdit(NullableIdDto<int> input);

        //todo:缺少Dto的生成GetPlanForEditOutput
        /// <summary>
        /// 添加或者修改Plan的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PlanEditDto> CreateOrUpdatePlan(CreateOrUpdatePlanInput input);

        /// <summary>
        /// 删除Plan信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeletePlan(EntityDto<int> input);

        /// <summary>
        /// 批量删除Plan
        /// </summary>
        Task BatchDeletePlansAsync(List<int> input);
    }
}
