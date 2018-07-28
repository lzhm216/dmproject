using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SPA.DocumentManager.Authorization;
using SPA.DocumentManager.PlanProjects.Authorization;
using SPA.DocumentManager.PlanProjects.Dtos.LTMAutoMapper;
using SPA.DocumentManager.PlanProjectTypes.Dtos.LTMAutoMapper;
using SPA.DocumentManager.Plans.Authorization;
using SPA.DocumentManager.Plans.Dtos.LTMAutoMapper;
using SPA.DocumentManager.SpecialPlans.Authorization;
using SPA.DocumentManager.SpecialPlans.Dtos.LTMAutoMapper;
using SPA.DocumentManager.SpecialPlanTypes.Dtos;
using SPA.DocumentManager.SubSpecialPlans.Authorization;
using SPA.DocumentManager.SubSpecialPlans.Dtos.LTMAutoMapper;
using SPA.DocumentManager.TaskBooks.Authorization;
using SPA.DocumentManager.TaskBooks.Dtos;
using SPA.DocumentManager.UnitGroups.Authorization;
using SPA.DocumentManager.UnitGroups.Dtos;

namespace SPA.DocumentManager
{
    [DependsOn(
        typeof(DocumentManagerCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class DocumentManagerApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<DocumentManagerAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<PlanAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<PlanProjectAppAuthorizationProvider>();

            Configuration.Authorization.Providers.Add<SubSpecialPlanAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<SpecialPlanAppAuthorizationProvider>();

            Configuration.Authorization.Providers.Add<TaskBookAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<UnitGroupAppAuthorizationProvider>();



            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerPlanMapper.CreateMappings);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerPlanProjectMapper.CreateMappings);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerPlanProjectTypeMapper.CreateMappings);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerSubSpecialPlanMapper.CreateMappings);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerSpecialPlanMapper.CreateMappings);
            
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerSpecialPlanTypeMapper.CreateMappings);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerUnitGroupMapper.CreateMappings);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerTaskBookMapper.CreateMappings);
            
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(DocumentManagerApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
