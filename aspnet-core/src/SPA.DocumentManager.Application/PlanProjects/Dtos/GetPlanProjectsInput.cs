using Abp.Runtime.Validation;
using SPA.DocumentManager.Dto;
using SPA.DocumentManager.PlanProjects;

namespace SPA.DocumentManager.PlanProjects.Dtos
{
    public class GetPlanProjectsInput : PagedAndSortedInputDto, IShouldNormalize
    {
        /// <summary>
        /// 模糊搜索使用的关键字
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

    }
}
