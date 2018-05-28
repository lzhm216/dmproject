using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using SPA.DocumentManager.TaskBooks;

namespace SPA.DocumentManager.TaskBooks.DomainServices
{
    public interface ITaskBookManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        /// </summary>
        void InitTaskBook();

    }
}
