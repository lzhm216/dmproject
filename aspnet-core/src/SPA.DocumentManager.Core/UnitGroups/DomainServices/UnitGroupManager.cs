using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using SPA.DocumentManager.UnitGroups;

namespace SPA.DocumentManager.UnitGroups.DomainServices
{
    /// <summary>
    /// UnitGroup领域层的业务管理
    /// </summary>
    public class UnitGroupManager :DocumentManagerDomainServiceBase, IUnitGroupManager
    {
        private readonly IRepository<UnitGroup, int> _unitgroupRepository;

        /// <summary>
        /// UnitGroup的构造方法
        /// </summary>
        public UnitGroupManager(IRepository<UnitGroup, int> unitgroupRepository)
        {
            _unitgroupRepository = unitgroupRepository;
        }
		
		
		/// <summary>
		///     初始化
		/// </summary>
		public void InitUnitGroup()
		{
			throw new NotImplementedException();
		}

		//TODO:编写领域业务代码


		
		//// custom codes 
		
        //// custom codes end

    }
}
