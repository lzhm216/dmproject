using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using SPA.DocumentManager.TaskBooks;

namespace SPA.DocumentManager.TaskBooks.DomainServices
{
    /// <summary>
    /// TaskBook领域层的业务管理
    /// </summary>
    public class TaskBookManager : DocumentManagerDomainServiceBase, ITaskBookManager
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<TaskBook, int> _taskbookRepository;
        /// <summary>
        /// TaskBook的构造方法
        /// </summary>
        public TaskBookManager(IRepository<TaskBook, int> taskbookRepository)
        {
            _taskbookRepository = taskbookRepository;
        }

        //TODO:编写领域业务代码
        /// <summary>
        ///     初始化
        /// </summary>
        public void InitTaskBook()
        {
            throw new NotImplementedException();
        }

    }

}
