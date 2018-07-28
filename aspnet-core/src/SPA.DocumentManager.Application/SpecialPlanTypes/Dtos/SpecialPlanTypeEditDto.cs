using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.TaskBooks;

namespace SPA.DocumentManager.SpecialPlanTypes.Dtos
{
    public class SpecialPlanTypeEditDto
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