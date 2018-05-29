using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using SPA.DocumentManager.PlanProjectTypes;

namespace SPA.DocumentManager.PlanProjectTypes.DomainServices
{
    /// <summary>
    /// PlanProjectType领域层的业务管理
    /// </summary>
    public class PlanProjectTypeManager : DocumentManagerDomainServiceBase, IPlanProjectTypeManager
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<PlanProjectType, int> _planprojecttypeRepository;
        /// <summary>
        /// PlanProjectType的构造方法
        /// </summary>
        public PlanProjectTypeManager(IRepository<PlanProjectType, int> planprojecttypeRepository)
        {
            _planprojecttypeRepository = planprojecttypeRepository;
        }

        //TODO:编写领域业务代码
        /// <summary>
        ///     初始化
        /// </summary>
        public void InitPlanProjectType()
        {
            throw new NotImplementedException();
        }

    }

}
