using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using SPA.DocumentManager.Configuration.Dto;

namespace SPA.DocumentManager.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : DocumentManagerAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
