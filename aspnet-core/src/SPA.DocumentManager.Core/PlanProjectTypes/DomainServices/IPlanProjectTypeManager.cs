using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using SPA.DocumentManager.PlanProjectTypes;

namespace SPA.DocumentManager.PlanProjectTypes.DomainServices
{
    public interface IPlanProjectTypeManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        /// </summary>
        void InitPlanProjectType();

    }
}
