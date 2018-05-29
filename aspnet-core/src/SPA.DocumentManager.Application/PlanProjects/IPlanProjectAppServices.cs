using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.PlanProjects.Dtos;
using SPA.DocumentManager.PlanProjects;

namespace SPA.DocumentManager.PlanProjects
{
    /// <summary>
    /// PlanProject应用层服务的接口方法
    /// </summary>
    public interface IPlanProjectAppService : IApplicationService
    {
        /// <summary>
        /// 获取PlanProject的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PlanProjectListDto>> GetPagedPlanProjects(GetPlanProjectsInput input);

        /// <summary>
        /// 通过指定id获取PlanProjectListDto信息
        /// </summary>
        Task<PlanProjectListDto> GetPlanProjectByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 导出PlanProject为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetPlanProjectsToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetPlanProjectForEditOutput> GetPlanProjectForEdit(NullableIdDto<int> input);

        //todo:缺少Dto的生成GetPlanProjectForEditOutput
        /// <summary>
        /// 添加或者修改PlanProject的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdatePlanProject(CreateOrUpdatePlanProjectInput input);

        /// <summary>
        /// 删除PlanProject信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeletePlanProject(EntityDto<int> input);

        /// <summary>
        /// 批量删除PlanProject
        /// </summary>
        Task BatchDeletePlanProjectsAsync(List<int> input);
    }
}
