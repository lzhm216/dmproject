

using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using SPA.DocumentManager;
using SPA.DocumentManager.SpecialPlans;


namespace SPA.DocumentManager.SpecialPlans
{
    /// <summary>
    /// SpecialPlan领域层的业务管理
    ///</summary>
    public class SpecialPlanManager :DocumentManagerDomainServiceBase, ISpecialPlanManager
    {
    private readonly IRepository<SpecialPlan,int> _specialplanRepository;

        /// <summary>
            /// SpecialPlan的构造方法
            ///</summary>
        public SpecialPlanManager(IRepository<SpecialPlan, int>
specialplanRepository)
            {
            _specialplanRepository =  specialplanRepository;
            }


            /// <summary>
                ///     初始化
                ///</summary>
            public void InitSpecialPlan()
            {
            throw new NotImplementedException();
            }

            //TODO:编写领域业务代码



            //// custom codes
             
            //// custom codes end

            }
            }
