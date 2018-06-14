import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { JsonpModule } from '@angular/http';
import { HttpClientModule, HttpResponse } from '@angular/common/http';

import { ModalModule } from 'ngx-bootstrap';
import { NgxPaginationModule } from 'ngx-pagination';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AbpModule } from '@abp/abp.module';

import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { SharedModule } from '@shared/shared.module';

import { HomeComponent } from '@app/home/home.component';
import { AboutComponent } from '@app/about/about.component';
import { UsersComponent } from '@app/users/users.component';
import { CreateUserComponent } from '@app/users/create-user/create-user.component';
import { EditUserComponent } from './users/edit-user/edit-user.component';
import { RolesComponent } from '@app/roles/roles.component';
import { CreateRoleComponent } from '@app/roles/create-role/create-role.component';
import { EditRoleComponent } from './roles/edit-role/edit-role.component';
import { TenantsComponent } from '@app/tenants/tenants.component';
import { CreateTenantComponent } from './tenants/create-tenant/create-tenant.component';
import { EditTenantComponent } from './tenants/edit-tenant/edit-tenant.component';
import { TopBarComponent } from '@app/layout/topbar.component';
import { TopBarLanguageSwitchComponent } from '@app/layout/topbar-languageswitch.component';
import { SideBarUserAreaComponent } from '@app/layout/sidebar-user-area.component';
import { SideBarNavComponent } from '@app/layout/sidebar-nav.component';
import { SideBarFooterComponent } from '@app/layout/sidebar-footer.component';
import { RightSideBarComponent } from '@app/layout/right-sidebar.component';
import { MaterialInput } from '@shared/directives/material-input.directive';
import { PlansComponent } from './plans/plans.component';
import { CreatePlanComponent } from './plans/create-plan/create-plan.component';
import { EditPlanComponent } from './plans/edit-plan/edit-plan.component';
import { PlanprojectsComponent } from './planprojects/planprojects.component';
import { CreatePlanprojectComponent } from './planprojects/create-planproject/create-planproject.component';
import { EditPlanprojectComponent } from './planprojects/edit-planproject/edit-planproject.component';
import { ProjecttypesComponent } from './projecttypes/projecttypes.component';
import { CreateProjecttypeComponent } from './projecttypes/create-projecttype/create-projecttype.component';
import { EditProjecttypeComponent } from './projecttypes/edit-projecttype/edit-projecttype.component';
import { TestsComponent } from './tests/tests.component';
import { DetailPlanComponent } from './plans/detail-plan/detail-plan.component';
import { UploadsComponent } from './uploads/uploads.component';

import { FileDownloadService } from '@shared/utils/file-download.service';
import { PlanAttachmentComponent } from './plans/plan-attachment/plan-attachment.component';

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        AboutComponent,
        TenantsComponent,
		CreateTenantComponent,
		EditTenantComponent,
        UsersComponent,
		CreateUserComponent,
		EditUserComponent,
      	RolesComponent,        
		CreateRoleComponent,
		EditRoleComponent,
        TopBarComponent,
        TopBarLanguageSwitchComponent,
        SideBarUserAreaComponent,
        SideBarNavComponent,
        SideBarFooterComponent,
        RightSideBarComponent,
        PlansComponent,
        CreatePlanComponent,
        EditPlanComponent,
        PlanprojectsComponent,
        CreatePlanprojectComponent,
        EditPlanprojectComponent,
        ProjecttypesComponent,
        CreateProjecttypeComponent,
        EditProjecttypeComponent,
        TestsComponent,
        DetailPlanComponent,
        UploadsComponent,
        PlanAttachmentComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        JsonpModule,
        ModalModule.forRoot(),
        AbpModule,
        AppRoutingModule,
        ServiceProxyModule,
        SharedModule,
        NgxPaginationModule
    ],
    providers: [
        FileDownloadService
    ]
})
export class AppModule { }
