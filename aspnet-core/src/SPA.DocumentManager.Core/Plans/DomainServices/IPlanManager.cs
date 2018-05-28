using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;

namespace SPA.DocumentManager.Plans.DomainServices
{
    public interface IPlanManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        /// </summary>
        void InitPlan();

    }
}
