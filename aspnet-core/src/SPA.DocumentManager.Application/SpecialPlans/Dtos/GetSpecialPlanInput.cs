

using Abp.Runtime.Validation;
using SPA.DocumentManager.Dto;

namespace SPA.DocumentManager.SpecialPlans.Dtos
{
    public class GetSpecialPlansInput : PagedAndSortedInputDto, IShouldNormalize
    {
          /// <summary>
		 /// 模糊搜索使用的关键字
		 ///</summary>
        public string Filter { get; set; }

        public int FilterSpecialPlanTypeId { get; set; }

        public string FilterYear { get; set; }

        //// custom codes

        //// custom codes end

        /// <summary>
        /// 正常化排序使用
        ///</summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }


    }
}
