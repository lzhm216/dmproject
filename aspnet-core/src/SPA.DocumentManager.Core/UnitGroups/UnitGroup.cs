using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace SPA.DocumentManager.UnitGroups
{
    public class UnitGroup : FullAuditedEntity<int>
    {
        /// <summary>
        /// 单位名称
        /// </summary>
        [Required]
        [StringLength(DocumentManagerConsts.Max50Length)]
        public string UnitGroupName { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [Required]
        [StringLength(DocumentManagerConsts.Max50Length)]
        public string Contact { get; set; }


        /// <summary>
        /// 联系电话
        /// </summary>
        [Required]
        [StringLength(DocumentManagerConsts.Max50Length)]
        [Phone(ErrorMessage = "手机号码输入错误")]
        public string ContactPhone { get; set; }
    }
}
