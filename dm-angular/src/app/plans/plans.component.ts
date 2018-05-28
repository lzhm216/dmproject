import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { PagedResultDtoOfPlanListDto, PlanListDto, PlanServiceProxy } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { CreatePlanComponent } from '@app/plans/create-plan/create-plan.component';

@Component({
  selector: 'app-plans',
  templateUrl: './plans.component.html',
  styleUrls: ['./plans.component.css'],
  animations: [appModuleAnimation()]
})
export class PlansComponent extends PagedListingComponentBase<PlanListDto> {

  @ViewChild('createPlanModal') createPlanModal: CreatePlanComponent;

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
    throw new Error("Method not implemented.");
  }

  createPlan(): void {
    this.createPlanModal.show();
  }


}
