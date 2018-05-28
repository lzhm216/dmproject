using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

namespace SPA.DocumentManager.PlanProjects.DomainServices
{
    /// <summary>
    /// PlanProject领域层的业务管理
    /// </summary>
    public class PlanProjectManager : DocumentManagerDomainServiceBase, IPlanProjectManager
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<PlanProject, int> _planprojectRepository;
        /// <summary>
        /// PlanProject的构造方法
        /// </summary>
        public PlanProjectManager(IRepository<PlanProject, int> planprojectRepository)
        {
            _planprojectRepository = planprojectRepository;
        }

        //TODO:编写领域业务代码
        /// <summary>
        ///     初始化
        /// </summary>
        public void InitPlanProject()
        {
            throw new NotImplementedException();
        }

    }

}
