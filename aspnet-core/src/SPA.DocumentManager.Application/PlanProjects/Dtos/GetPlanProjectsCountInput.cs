using Abp.Runtime.Validation;
using SPA.DocumentManager.Dto;
using SPA.DocumentManager.PlanProjects;

namespace SPA.DocumentManager.PlanProjects.Dtos
{
    public class GetPlanProjectsCountInput
    {
        /// <summary>
        /// 模糊搜索使用的关键字
        /// </summary>
        public string Filter { get; set; }
    }
}
