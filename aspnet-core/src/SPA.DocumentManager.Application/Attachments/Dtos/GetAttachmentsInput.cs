using Abp.Runtime.Validation;
using SPA.DocumentManager.Dto;
using SPA.DocumentManager.Plans;

namespace SPA.DocumentManager.Attachments.Dtos
{
    public class GetAttachmentsInput : PagedAndSortedInputDto, IShouldNormalize
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
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

        public int? PlanId { get; set; }
    }
}
