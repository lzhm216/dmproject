using System.Threading.Tasks;
using Abp.Application.Services;
using SPA.DocumentManager.Sessions.Dto;

namespace SPA.DocumentManager.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
