using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;

namespace SPA.DocumentManager.SpecialPlans.DomainServices
{
    public interface ISpecialPlanManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        /// </summary>
        void InitSpecialPlan();

    }
}
