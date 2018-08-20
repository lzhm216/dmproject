

using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using SPA.DocumentManager.Enums.Extensions;
using SPA.DocumentManager.Plans;
using SPA.DocumentManager.SpecialPlans;

namespace SPA.DocumentManager.SpecialPlans.Dtos
{
    public class SpecialPlanEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }


        /// <summary>
        /// SpecialPlanTypeId
        /// </summary>
        [Required(ErrorMessage = "SpecialPlanTypeId不能为空")]
        public int SpecialPlanTypeId { get; set; }


        /// <summary>
        /// MainContent
        /// </summary>
        [MaxLength(100, ErrorMessage = "MainContent超出最大长度")]
        [Required(ErrorMessage = "MainContent不能为空")]
        public string MainContent { get; set; }


        /// <summary>
        /// Unit
        /// </summary>
        [Required(ErrorMessage = "Unit不能为空")]
        public UnitType Unit { get; set; }

        public string UnitTypeDescription => Unit.ToDescription();

        /// <summary>
        /// PlannedWorkLoad
        /// </summary>
        [Required(ErrorMessage = "PlannedWorkLoad不能为空")]
        public double PlannedWorkLoad { get; set; }


        /// <summary>
        /// PlannedCost
        /// </summary>
        [Required(ErrorMessage = "PlannedCost不能为空")]
        public double PlannedCost { get; set; }


        /// <summary>
        /// CompleteDate
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [Required(ErrorMessage = "CompleteDate不能为空")]
        public DateTime CompleteDate { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy}")]
        [Required(ErrorMessage = "Year不能为空")]
        public DateTime Year { get; set; }

        /// <summary>
        /// PlanId
        /// </summary>
        public int PlanId { get; set; }


        //// custom codes

        //// custom codes end
    }
}