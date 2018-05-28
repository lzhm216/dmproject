using System.Threading.Tasks;
using Abp.Application.Services;
using SPA.DocumentManager.Authorization.Accounts.Dto;

namespace SPA.DocumentManager.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
