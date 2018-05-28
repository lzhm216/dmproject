using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SPA.DocumentManager.Configuration;

namespace SPA.DocumentManager.Web.Host.Startup
{
    [DependsOn(
       typeof(DocumentManagerWebCoreModule))]
    public class DocumentManagerWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public DocumentManagerWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DocumentManagerWebHostModule).GetAssembly());
        }
    }
}
