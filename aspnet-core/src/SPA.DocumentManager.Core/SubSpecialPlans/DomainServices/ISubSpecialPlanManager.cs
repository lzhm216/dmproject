using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;

namespace SPA.DocumentManager.SubSpecialPlans.DomainServices
{
    public interface ISubSpecialPlanManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        /// </summary>
        void InitSubSpecialPlan();

    }
}
