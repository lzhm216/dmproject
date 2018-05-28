import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AbpHttpInterceptor } from '@abp/abpHttpInterceptor';

import * as ApiServiceProxies from './service-proxies';
import { AppSessionService } from '@shared/session/app-session.service';

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
        ApiServiceProxies.SubPlanProjectServiceProxy,
        ApiServiceProxies.SpecialPlanServiceProxy,
        ApiServiceProxies.SubSpecialPlanServiceProxy,
        ApiServiceProxies.TaskBookServiceProxy,
        { provide: HTTP_INTERCEPTORS, useClass: AbpHttpInterceptor, multi: true }
    ]
})
export class ServiceProxyModule { }
