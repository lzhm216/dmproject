using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.PlanProjects.Dtos;

namespace SPA.DocumentManager.Plans.Dtos
{
    public class PlanListWithProjectDto
    {
        public int Id { get; set; }
        public string PlanName { get; set; }
        public string PlanYear { get; set; }
        public string FileNo { get; set; }
        public DateTime PublishDate { get; set; }
        public string CompilationBasis { get; set; }
        public string MainContent { get; set; }
        public double FundBudget { get; set; }
        public string FinancialSource { get; set; }

        public virtual ICollection<PlanProjectListDto> PlanProjects { get; set; }
    }
}