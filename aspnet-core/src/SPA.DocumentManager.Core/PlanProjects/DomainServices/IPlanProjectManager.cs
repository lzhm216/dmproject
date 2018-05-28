using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;

namespace SPA.DocumentManager.PlanProjects.DomainServices
{
    public interface IPlanProjectManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        /// </summary>
        void InitPlanProject();

    }
}
