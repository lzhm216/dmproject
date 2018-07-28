using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.TaskBooks;
using System.Collections.Generic;

namespace SPA.DocumentManager.SpecialPlanTypes.Dtos
{
    public class SpecialPlanTypeListDto : FullAuditedEntityDto<int>
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }


        /// <summary>
        /// SpecialPlanTypeName
        /// </summary>
        [MaxLength(50, ErrorMessage = "SpecialPlanTypeName超出最大长度")]
        public string SpecialPlanTypeName { get; set; }


        /// <summary>
        /// TaskBooks
        /// </summary>
        public ICollection<TaskBook> TaskBooks { get; set; }






        //// custom codes 

        //// custom codes end
    }
}