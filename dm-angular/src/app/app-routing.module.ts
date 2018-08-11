import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from "app/roles/roles.component";
import { PlansComponent } from '@app/plans/plans.component';
import { PlanprojectsComponent } from '@app/planprojects/planprojects.component';
import { ProjecttypesComponent } from '@app/projecttypes/projecttypes.component';
import { UploadsComponent } from '@app/uploads/uploads.component';
import { SpecialplansComponent } from '@app/specialplans/specialplans.component';
import { SpecialplantypesComponent } from '@app/specialplantypes/specialplantypes.component';
import { UnitgroupsComponent } from '@app/unitgroups/unitgroups.component';
import { TaskbooksComponent } from '@app/taskbooks/taskbooks.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent,  canActivate: [AppRouteGuard] },
                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'plans', component: PlansComponent, data: { permission: 'Pages.Plan' }, canActivate: [AppRouteGuard] },
                    { path: 'projecttypes', component: ProjecttypesComponent, data: { }, canActivate: [AppRouteGuard] },
                    { path: 'specialplantypes', component: SpecialplantypesComponent, data: { }, canActivate: [AppRouteGuard] },
                    { path: 'planprojects', component: PlanprojectsComponent, data: { permission: 'Pages.PlanProject' }, canActivate: [AppRouteGuard] },
                    { path: 'specialplans', component: SpecialplansComponent, data: { permission: 'Pages.SpecialPlan' }, canActivate: [AppRouteGuard] },
                    { path: 'unitgroups', component: UnitgroupsComponent, data: { permission: 'Pages.UnitGroup' }, canActivate: [AppRouteGuard] },
                    { path: 'taskbooks', component: TaskbooksComponent, data: { permission: 'Pages.TaskBook' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'about', component: AboutComponent },
                    { path: 'upload', component: UploadsComponent }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }