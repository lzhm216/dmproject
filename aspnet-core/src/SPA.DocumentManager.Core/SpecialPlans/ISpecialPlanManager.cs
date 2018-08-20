

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using SPA.DocumentManager.SpecialPlans;


namespace SPA.DocumentManager.SpecialPlans
{
    public interface ISpecialPlanManager : IDomainService
    {

        /// <summary>
    /// 初始化方法
    ///</summary>
        void InitSpecialPlan();



		//// custom codes
 
        //// custom codes end

    }
}
