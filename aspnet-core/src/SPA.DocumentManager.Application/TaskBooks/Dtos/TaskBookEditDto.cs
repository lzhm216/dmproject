using System;
using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.TaskBooks;
using SPA.DocumentManager.UnitGroups;

namespace SPA.DocumentManager.TaskBooks.Dtos
{
    public class TaskBookEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }


        /// <summary>
        /// SpecialPlanType
        /// </summary>
        [Required(ErrorMessage = "SpecialPlanType不能为空")]
        public SpecialPlanType SpecialPlanType { get; set; }


        /// <summary>
        /// TaskBookNo
        /// </summary>
        [MaxLength(100, ErrorMessage = "TaskBookNo超出最大长度")]
        [Required(ErrorMessage = "TaskBookNo不能为空")]
        public string TaskBookNo { get; set; }


        /// <summary>
        /// TaskName
        /// </summary>
        [MaxLength(200, ErrorMessage = "TaskName超出最大长度")]
        [Required(ErrorMessage = "TaskName不能为空")]
        public string TaskName { get; set; }


        /// <summary>
        /// Funds
        /// </summary>
        [Required(ErrorMessage = "Funds不能为空")]
        public double Funds { get; set; }


        /// <summary>
        /// UndertakingUnitGroup
        /// </summary>
        [Required(ErrorMessage = "UndertakingUnitGroup不能为空")]
        public UnitGroup UndertakingUnitGroup { get; set; }


        /// <summary>
        /// SignDate
        /// </summary>
        [Required(ErrorMessage = "SignDate不能为空")]
        public DateTime SignDate { get; set; }


        /// <summary>
        /// CompleteDate
        /// </summary>
        [Required(ErrorMessage = "CompleteDate不能为空")]
        public DateTime CompleteDate { get; set; }


        /// <summary>
        /// TaskContent
        /// </summary>
        [MaxLength(500, ErrorMessage = "TaskContent超出最大长度")]
        public string TaskContent { get; set; }


        /// <summary>
        /// Description
        /// </summary>
        [MaxLength(500, ErrorMessage = "Description超出最大长度")]
        public string Description { get; set; }






        //// custom codes 

        //// custom codes end
    }
}