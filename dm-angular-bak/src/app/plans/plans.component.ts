import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { PagedResultDtoOfPlanListDto, PlanListDto, PlanServiceProxy } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { CreatePlanComponent } from '@app/plans/create-plan/create-plan.component';
import { EditPlanComponent } from '@app/plans/edit-plan/edit-plan.component';

@Component({
  selector: 'app-plans',
  templateUrl: './plans.component.html',
  styleUrls: ['./plans.component.css'],
  animations: [appModuleAnimation()]
})
export class PlansComponent extends PagedListingComponentBase<PlanListDto> {

  @ViewChild('createPlanModal') createPlanModal: CreatePlanComponent;
  @ViewChild('editPlanModal') editPlanModal: EditPlanComponent;

  filter: string = '';
  plans: PlanListDto[] = [];
  constructor(
    injector: Injector,
    private _planService: PlanServiceProxy,
  ) {
    super(injector);
  }

  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    this._planService.getPagedPlans(this.filter, 'Id', request.maxResultCount, request.skipCount).finally(() => {
      finishedCallback();
    }).subscribe((result: PagedResultDtoOfPlanListDto) => {
      this.plans = result.items;
      this.showPaging(result, pageNumber);
    })
  }

  protected delete(entity: PlanListDto): void {
    abp.message.confirm(
            "Delete plan '" + entity.planName + "'?",
            (result: boolean) => {
                if (result) {
                    this._planService.deletePlan(entity.id)
                        .subscribe(() => {
                            abp.notify.info("Deleted Plan: " + entity.planName);
                            this.refresh();
                        });
                }
            }
        );
  }

  createPlan(): void {
    this.createPlanModal.show();
  }

  editPlan(): void {
    this.editPlanModal.show();
  }
}