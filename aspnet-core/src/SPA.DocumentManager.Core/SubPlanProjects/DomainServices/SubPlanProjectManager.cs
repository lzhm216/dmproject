using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

namespace SPA.DocumentManager.SubPlanProjects.DomainServices
{
    /// <summary>
    /// SubPlanProject领域层的业务管理
    /// </summary>
    public class SubPlanProjectManager : DocumentManagerDomainServiceBase, ISubPlanProjectManager
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<SubPlanProject, int> _subplanprojectRepository;
        /// <summary>
        /// SubPlanProject的构造方法
        /// </summary>
        public SubPlanProjectManager(IRepository<SubPlanProject, int> subplanprojectRepository)
        {
            _subplanprojectRepository = subplanprojectRepository;
        }

        //TODO:编写领域业务代码
        /// <summary>
        ///     初始化
        /// </summary>
        public void InitSubPlanProject()
        {
            throw new NotImplementedException();
        }

    }

}
