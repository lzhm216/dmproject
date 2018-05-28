using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

namespace SPA.DocumentManager.SubSpecialPlans.DomainServices
{
    /// <summary>
    /// SubSpecialPlan领域层的业务管理
    /// </summary>
    public class SubSpecialPlanManager : DocumentManagerDomainServiceBase, ISubSpecialPlanManager
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<SubSpecialPlan, int> _subspecialplanRepository;
        /// <summary>
        /// SubSpecialPlan的构造方法
        /// </summary>
        public SubSpecialPlanManager(IRepository<SubSpecialPlan, int> subspecialplanRepository)
        {
            _subspecialplanRepository = subspecialplanRepository;
        }

        //TODO:编写领域业务代码
        /// <summary>
        ///     初始化
        /// </summary>
        public void InitSubSpecialPlan()
        {
            throw new NotImplementedException();
        }

    }

}
