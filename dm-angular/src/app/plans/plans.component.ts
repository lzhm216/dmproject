import { Component, OnInit, Injector, ViewChild, AfterViewInit, ElementRef } from '@angular/core';
import { PagedResultDtoOfPlanListDto, PlanListDto, PlanServiceProxy, PlanEditDto } from '@shared/service-proxies/service-proxies';
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
export class PlansComponent extends PagedListingComponentBase<PlanListDto> implements AfterViewInit {

  @ViewChild('createPlanModal') createPlanModal: CreatePlanComponent;
  @ViewChild('editPlanModal') editPlanModal: EditPlanComponent;

  filter: string = '';
  plans: PlanListDto[] = [];
  cost: number[] = [];
  constructor(
    injector: Injector,
    private _planService: PlanServiceProxy,
  ) {
    super(injector);
  }

  ngAfterViewInit(): void {
    $(function () {
      initBarChart();
    });

    function initBarChart() {
      ((window as any).Morris).Line({
        element: 'line_chart',
        data: [{
          year: '2016', value: 2860
        }, {
          year: '2017', value: 2680
        }, {
          year: '2018', value: 2444
        }
        ],
        xkey: 'year',
        ykeys: ['value'],
        labels: ['计划总成本'],
        yLabelFormat: function (y) { return y.toString() + '万元'; }
      });
    }
  }

  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    this._planService.getPagedPlans(this.filter, 'Id', request.maxResultCount, request.skipCount).finally(() => {
      finishedCallback();
    }).subscribe((result: PagedResultDtoOfPlanListDto) => {
      this.plans = result.items;
      this.plans.forEach(plan => {
        this.cost.push(plan.fundBudget);
      });
      this.showPaging(result, pageNumber);
    })
  }

  protected delete(entity: PlanListDto): void {
    abp.message.confirm(
      "是否删除基础测绘计划 '" + entity.planName + "'?",
      (result: boolean) => {
        if (result) {
          this._planService.deletePlan(entity.id)
            .subscribe(() => {
              abp.notify.info("基础测绘计划: " + entity.planName + "已删除");
              this.refresh();
            });
        }
      }
    );
  }

  //TODO
  protected detail(entity: PlanListDto): void {
    //this.editPlanModal.show(entity.id);
  }

  createPlan(): void {
    this.createPlanModal.show();
  }

  editPlan(plan: PlanEditDto): void {
    this.editPlanModal.show(plan.id);
  }
}
