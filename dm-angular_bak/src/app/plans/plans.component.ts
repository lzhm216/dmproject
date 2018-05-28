import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { PlanServiceProxy, PlanListDto, PagedResultDtoOfPlanListDto } from '@shared/service-proxies/service-proxies';
import { CreatePlanComponent } from "app/plans/create-plan/create-plan.component";
import { appModuleAnimation } from '@shared/animations/routerTransition';

@Component({
  selector: 'app-plans',
  templateUrl: './plans.component.html',
  styleUrls: ['./plans.component.css']
})
export class PlansComponent extends PagedListingComponentBase<PlanListDto> {

  @ViewChild('createPlanModal') createPlanModal: CreatePlanComponent;

  filter = '';
  plans: PlanListDto[] = [];

  constructor(
    injector: Injector,
    private planService: PlanServiceProxy
  ) {
    super(injector);
  }


  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    this.planService.getPagedPlans(this.filter, 'Id', request.maxResultCount, request.skipCount).finally(() => {
      finishedCallback();
    }).subscribe((result: PagedResultDtoOfPlanListDto) => {
      this.plans = result.items;
      this.showPaging(result, pageNumber);
    });
  }

  protected delete(entity: PlanListDto): void {
    abp.message.confirm('是否确认删除' + entity.planName + '的信息?', (isComfirmed) => {
      if (isComfirmed) {
        this.planService.deletePlan(entity.id).subscribe(
          () => {
            abp.message.info(entity.planName + '已删除');
            this.refresh();
          }
        );
      }
    })
  }

  createPlan(): void {
    this.createPlanModal.show();
  }
}
