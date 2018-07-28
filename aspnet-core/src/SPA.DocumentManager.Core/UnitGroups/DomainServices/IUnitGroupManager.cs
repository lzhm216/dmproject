using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using SPA.DocumentManager.UnitGroups;


namespace SPA.DocumentManager.UnitGroups.DomainServices
{
    public interface IUnitGroupManager : IDomainService
    {
        
        /// <summary>
        /// 初始化方法
        /// </summary>
        void InitUnitGroup();


		
		//// custom codes 
		
        //// custom codes end

    }
}
