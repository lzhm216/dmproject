﻿using SPA.DocumentManager.Enums.Extensions;
using SPA.DocumentManager.Plans;
using System.ComponentModel.DataAnnotations;

namespace SPA.DocumentManager.PlanProjects.Dtos
{
    public class PlanProjectEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }

        /// <summary>
        ///项目名称ID
        /// </summary>
        public int PlanProjectTypeId { get; set; }

        /// <summary>
        /// 综合工序及成果成图
        /// </summary>
        [Required]
        [MaxLength(DocumentManagerConsts.MaxSubProjectNameLength)]
        public string SubProjectName { get; set; }


        /// <summary>
        /// 计划工作量
        /// </summary>
        [Required]
        public double PlannedWorkLoad { get; set; }


        /// <summary>
        /// 计划总成本
        /// </summary>
        [Required]
        public double PlannedCost { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        [Required]
        public UnitType Unit { get; set; }

        public string UnitTypeDescription => Unit.ToDescription();

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(DocumentManagerConsts.MaxProjectDescriptionLength)]
        public string Description { get; set; }

        /// <summary>
        /// 规划与计划ID
        /// </summary>
        public int PlanId { get; set; }

        
    }
}