using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;

namespace SPA.DocumentManager.SubPlanProjects.DomainServices
{
    public interface ISubPlanProjectManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        /// </summary>
        void InitSubPlanProject();

    }
}
