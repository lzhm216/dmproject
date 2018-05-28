using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

namespace SPA.DocumentManager.Plans.DomainServices
{
    /// <summary>
    /// Plan领域层的业务管理
    /// </summary>
    public class PlanManager : DocumentManagerDomainServiceBase, IPlanManager
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<Plan, int> _planRepository;
        /// <summary>
        /// Plan的构造方法
        /// </summary>
        public PlanManager(IRepository<Plan, int> planRepository)
        {
            _planRepository = planRepository;
        }

        //TODO:编写领域业务代码
        /// <summary>
        ///     初始化
        /// </summary>
        public void InitPlan()
        {
            throw new NotImplementedException();
        }

    }

}
