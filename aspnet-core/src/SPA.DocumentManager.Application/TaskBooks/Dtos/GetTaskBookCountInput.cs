using Abp.Runtime.Validation;
using SPA.DocumentManager.Dto;

namespace SPA.DocumentManager.TaskBooks.Dtos
{
    public class GetTaskBookCountInput 
    {
        /// <summary>
        /// 模糊搜索使用的关键字
        /// </summary>
        public string Filter { get; set; }

        public int FilterUnitGroupId { get; set; }
		
        public string FilterYear { get; set; }

        public int FilterSpecialPlanTypeId { get; set; }

    }
}
