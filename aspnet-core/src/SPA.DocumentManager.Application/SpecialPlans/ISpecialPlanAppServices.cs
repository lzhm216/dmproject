using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.SpecialPlans.Dtos;

namespace SPA.DocumentManager.SpecialPlans
{
    /// <summary>
    /// SpecialPlan应用层服务的接口方法
    /// </summary>
    public interface ISpecialPlanAppService : IApplicationService
    {
        /// <summary>
        /// 获取SpecialPlan的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<SpecialPlanListDto>> GetPagedSpecialPlans(GetSpecialPlansInput input);

        /// <summary>
        /// 通过指定id获取SpecialPlanListDto信息
        /// </summary>
        Task<SpecialPlanListDto> GetSpecialPlanByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 导出SpecialPlan为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetSpecialPlansToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetSpecialPlanForEditOutput> GetSpecialPlanForEdit(NullableIdDto<int> input);

        //todo:缺少Dto的生成GetSpecialPlanForEditOutput
        /// <summary>
        /// 添加或者修改SpecialPlan的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateSpecialPlan(CreateOrUpdateSpecialPlanInput input);

        /// <summary>
        /// 删除SpecialPlan信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteSpecialPlan(EntityDto<int> input);

        /// <summary>
        /// 批量删除SpecialPlan
        /// </summary>
        Task BatchDeleteSpecialPlansAsync(List<int> input);
    }
}
