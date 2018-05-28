using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

namespace SPA.DocumentManager.SpecialPlans.DomainServices
{
    /// <summary>
    /// SpecialPlan领域层的业务管理
    /// </summary>
    public class SpecialPlanManager : DocumentManagerDomainServiceBase, ISpecialPlanManager
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<SpecialPlan, int> _specialplanRepository;
        /// <summary>
        /// SpecialPlan的构造方法
        /// </summary>
        public SpecialPlanManager(IRepository<SpecialPlan, int> specialplanRepository)
        {
            _specialplanRepository = specialplanRepository;
        }

        //TODO:编写领域业务代码
        /// <summary>
        ///     初始化
        /// </summary>
        public void InitSpecialPlan()
        {
            throw new NotImplementedException();
        }

    }

}
