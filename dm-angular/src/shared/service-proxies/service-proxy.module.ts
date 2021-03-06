import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AbpHttpInterceptor } from '@abp/abpHttpInterceptor';

import * as ApiServiceProxies from './service-proxies';

@NgModule({
    providers: [
        ApiServiceProxies.RoleServiceProxy,
        ApiServiceProxies.SessionServiceProxy,
        ApiServiceProxies.TenantServiceProxy,
        ApiServiceProxies.UserServiceProxy,
        ApiServiceProxies.TokenAuthServiceProxy,
        ApiServiceProxies.AccountServiceProxy,
        ApiServiceProxies.ConfigurationServiceProxy,
        ApiServiceProxies.PlanServiceProxy,
        ApiServiceProxies.PlanProjectServiceProxy,
        ApiServiceProxies.SpecialPlanServiceProxy,
        ApiServiceProxies.PlanProjectTypeServiceProxy,
        ApiServiceProxies.EnumServiceProxy,
        ApiServiceProxies.AttachmentServiceProxy,
        ApiServiceProxies.TaskBookServiceProxy,
        ApiServiceProxies.UnitGroupServiceProxy,
        ApiServiceProxies.SpecialPlanTypeServiceProxy,
        { provide: HTTP_INTERCEPTORS, useClass: AbpHttpInterceptor, multi: true }
    ]
})
export class ServiceProxyModule { }
