using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SPA.DocumentManager.Authorization;
using SPA.DocumentManager.PlanProjects.Authorization;
using SPA.DocumentManager.PlanProjects.Dtos.LTMAutoMapper;
using SPA.DocumentManager.PlanProjectTypes.Authorization;
using SPA.DocumentManager.PlanProjectTypes.Dtos.LTMAutoMapper;
using SPA.DocumentManager.Plans.Authorization;
using SPA.DocumentManager.Plans.Dtos.LTMAutoMapper;

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
            Configuration.Authorization.Providers.Add<PlanProjectTypeAppAuthorizationProvider>();

            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerPlanMapper.CreateMappings);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerPlanProjectMapper.CreateMappings);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerPlanProjectTypeMapper.CreateMappings);

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
