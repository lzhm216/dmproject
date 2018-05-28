using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.SubSpecialPlans.Dtos;

namespace SPA.DocumentManager.SubSpecialPlans
{
    /// <summary>
    /// SubSpecialPlan应用层服务的接口方法
    /// </summary>
    public interface ISubSpecialPlanAppService : IApplicationService
    {
        /// <summary>
        /// 获取SubSpecialPlan的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<SubSpecialPlanListDto>> GetPagedSubSpecialPlans(GetSubSpecialPlansInput input);

        /// <summary>
        /// 通过指定id获取SubSpecialPlanListDto信息
        /// </summary>
        Task<SubSpecialPlanListDto> GetSubSpecialPlanByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 导出SubSpecialPlan为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetSubSpecialPlansToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetSubSpecialPlanForEditOutput> GetSubSpecialPlanForEdit(NullableIdDto<int> input);

        //todo:缺少Dto的生成GetSubSpecialPlanForEditOutput
        /// <summary>
        /// 添加或者修改SubSpecialPlan的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateSubSpecialPlan(CreateOrUpdateSubSpecialPlanInput input);

        /// <summary>
        /// 删除SubSpecialPlan信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteSubSpecialPlan(EntityDto<int> input);

        /// <summary>
        /// 批量删除SubSpecialPlan
        /// </summary>
        Task BatchDeleteSubSpecialPlansAsync(List<int> input);
    }
}
