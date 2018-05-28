using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.MultiTenancy.Dto;

namespace SPA.DocumentManager.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
