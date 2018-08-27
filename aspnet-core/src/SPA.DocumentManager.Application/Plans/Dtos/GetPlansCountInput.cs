using Abp.Runtime.Validation;
using SPA.DocumentManager.Dto;

namespace SPA.DocumentManager.Plans.Dtos
{
    public class GetPlansCountInput 
    {
        /// <summary>
        /// 模糊搜索使用的关键字
        /// </summary>
        public string Filter { get; set; }


    }
}
