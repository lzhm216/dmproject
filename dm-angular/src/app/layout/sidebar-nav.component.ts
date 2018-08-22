import { Component, Injector, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { MenuItem } from '@shared/layout/menu-item';

@Component({
    templateUrl: './sidebar-nav.component.html',
    selector: 'sidebar-nav',
    encapsulation: ViewEncapsulation.None
})
export class SideBarNavComponent extends AppComponentBase {

    menuItems: MenuItem[] = [
        new MenuItem(this.l("HomePage"), "", "home", "/app/home"),
        new MenuItem(this.l("Tenants"), "Pages.Tenants", "business", "/app/tenants"),
        // new MenuItem(this.l("Users"), "Pages.Users", "people", "/app/users"),
        // new MenuItem(this.l("Roles"), "Pages.Roles", "local_offer", "/app/roles"),
        // new MenuItem(this.l("Plan"), "", "menu", "", [
        //     new MenuItem(this.l("Plan"), "Pages.Plan", "local_offer", "/app/plans"),            
        //     new MenuItem(this.l("PlanProject"), "Pages.PlanProject", "local_offer", "/app/planprojects"),
        //     new MenuItem(this.l("SpecialPlan"), "Pages.SpecialPlan", "local_offer", "/app/specialplans")
        // ]),
        new MenuItem(this.l("Plan"), "Pages.Plan", "layers", "/app/plans"),         
        new MenuItem(this.l("PlanProject"), "Pages.PlanProject", "local_mall", "/app/planprojects"),
        new MenuItem(this.l("SpecialPlan"), "Pages.SpecialPlan", "event_note", "/app/specialplans"),
        new MenuItem(this.l("TaskBooks"), "Pages.TaskBook", "local_post_office", "/app/taskbooks"),
        new MenuItem(this.l("Settings"), "", "menu", "", [
            new MenuItem(this.l("PlanProjectType"), "", "local_offer", "/app/projecttypes"),
            new MenuItem(this.l("SpecialPlanType"), "", "local_offer", "/app/specialplantypes"),
            new MenuItem(this.l("UnitGroup"), "Pages.UnitGroup", "local_offer", "/app/unitgroups")
        ]),
        new MenuItem("权限管理", "", "security", "", [
            new MenuItem(this.l("Users"), "Pages.Users", "people", "/app/users"),
            new MenuItem(this.l("Roles"), "Pages.Roles", "local_offer", "/app/roles")
        ]),
        new MenuItem(this.l("About"), "", "info", "/app/about"),
        new MenuItem(this.l("Upload"), "", "info", "/app/uploads")
    ];

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    showMenuItem(menuItem): boolean {
        if (menuItem.permissionName) {
            return this.permission.isGranted(menuItem.permissionName);
        }

        return true;
    }
}