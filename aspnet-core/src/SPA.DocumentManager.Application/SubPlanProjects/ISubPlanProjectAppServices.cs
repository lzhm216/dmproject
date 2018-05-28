using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.SubPlanProjects.Dtos;

namespace SPA.DocumentManager.SubPlanProjects
{
    /// <summary>
    /// SubPlanProject应用层服务的接口方法
    /// </summary>
    public interface ISubPlanProjectAppService : IApplicationService
    {
        /// <summary>
        /// 获取SubPlanProject的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<SubPlanProjectListDto>> GetPagedSubPlanProjects(GetSubPlanProjectsInput input);

        /// <summary>
        /// 通过指定id获取SubPlanProjectListDto信息
        /// </summary>
        Task<SubPlanProjectListDto> GetSubPlanProjectByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 导出SubPlanProject为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetSubPlanProjectsToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetSubPlanProjectForEditOutput> GetSubPlanProjectForEdit(NullableIdDto<int> input);

        //todo:缺少Dto的生成GetSubPlanProjectForEditOutput
        /// <summary>
        /// 添加或者修改SubPlanProject的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateSubPlanProject(CreateOrUpdateSubPlanProjectInput input);

        /// <summary>
        /// 删除SubPlanProject信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteSubPlanProject(EntityDto<int> input);

        /// <summary>
        /// 批量删除SubPlanProject
        /// </summary>
        Task BatchDeleteSubPlanProjectsAsync(List<int> input);
    }
}
