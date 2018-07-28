using Abp.Runtime.Validation;
using SPA.DocumentManager.Dto;

namespace SPA.DocumentManager.UnitGroups.Dtos
{
    public class GetUnitGroupsInput : PagedAndSortedInputDto, IShouldNormalize
    {
        /// <summary>
        /// 模糊搜索使用的关键字
        /// </summary>
        public string Filter { get; set; }

		
		//// custom codes 
		
        //// custom codes end

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
