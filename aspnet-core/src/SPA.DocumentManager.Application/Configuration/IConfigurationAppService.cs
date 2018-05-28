using System.Threading.Tasks;
using SPA.DocumentManager.Configuration.Dto;

namespace SPA.DocumentManager.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
