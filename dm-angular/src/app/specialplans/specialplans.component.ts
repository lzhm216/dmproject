import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import { CreateSpecialplanComponent } from '@app/specialplans/create-specialplan/create-specialplan.component';
import { EditSpecialplanComponent } from '@app/specialplans/edit-specialplan/edit-specialplan.component';
import { SpecialPlanListDto, SpecialPlanTypeListDto, PlanListDto, SpecialPlanServiceProxy, SpecialPlanTypeServiceProxy, EnumServiceProxy, SpecialPlanEditDto, PagedResultDtoOfSpecialPlanListDto, PlanServiceProxy } from '@shared/service-proxies/service-proxies';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedRequestDto, PagedListingComponentBase } from '@shared/paged-listing-component-base';

@Component({
  selector: 'app-specialplans',
  templateUrl: './specialplans.component.html',
  styleUrls: ['./specialplans.component.css'],
  animations: [appModuleAnimation()]
})
export class SpecialplansComponent extends PagedListingComponentBase<SpecialPlanListDto> implements OnInit {

  @ViewChild('addSpecialPlanModal') addSpecialPlanModal: CreateSpecialplanComponent;
  @ViewChild('editSpecialPlanModal') editSpecialPlanModal: EditSpecialplanComponent;

  filter: string = '';
  specialPlans: SpecialPlanListDto[] = [];
  cost: any[] = [];

  filterYear: string = "";
  years: string[] = [];

  filterSpecialPlanType: number = -1;
  specialPlanTypes: SpecialPlanTypeListDto[] = [];

  filterUnitGroup: number = -1;
  plans: PlanListDto[] = [];
  unitTypes: any = null;

  constructor(
    injector: Injector,
    private _planService: PlanServiceProxy,
    private _specialPlanService: SpecialPlanServiceProxy,
    private _specialPlanTypeService: SpecialPlanTypeServiceProxy,
    private _enumService: EnumServiceProxy
  ) {
    super(injector);
  }

  ngOnInit() {

    this.plans = [];
    this.specialPlanTypes = [];
    this.unitTypes = null;
    this.years = [];
    /* this._planService.getPlanList("", "", 30, 0).subscribe(result => {
      result.forEach(element => {
        this.years.push(element.planYear);
      })
    }); */

    this._specialPlanTypeService.getAllSpecialPlanType().subscribe(result => {
      this.specialPlanTypes = result.items;
    });

    this._enumService.getUnitTypeList().subscribe(result => {
      this.unitTypes = result;
    });

    this._specialPlanService.getSpecialPlanYears().subscribe(result => {
      this.years = result.items;
    });

    this.refresh();
  }

  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    this._specialPlanService.getPagedSpecialPlans(this.filter, this.filterSpecialPlanType, this.filterYear, 'Id', request.maxResultCount, request.skipCount).finally(() => {
      // $('#line_chart').html('');
      // ((window as any).Morris).Line({
      //   element: 'line_chart',
      //   data: this.cost,
      //   xkey: 'year',
      //   ykeys: ['value'],
      //   labels: ['计划总成本'],
      //   yLabelFormat: function (y) { return y.toString() + '万元'; }
      // });
      finishedCallback();
    }).subscribe((result: PagedResultDtoOfSpecialPlanListDto) => {

      this.specialPlans = result.items;
      this.cost = [];
      this.specialPlans.forEach(entity => {
        this.cost.push({ year: entity.year, value: entity.plannedCost });
      });

      this.showPaging(result, pageNumber);
    })
  }

  protected delete(entity: SpecialPlanListDto): void {
    abp.message.confirm(
      "是否删除测绘专项计划?",
      (result: boolean) => {
        if (result) {
          this._specialPlanService.deleteSpecialPlan(entity.id)
            .subscribe(() => {
              abp.notify.info("测绘专项计划已删除");
              this.refresh();
            });
        }
      }
    );
  }

  createTaskbook(): void {
    this.addSpecialPlanModal.show();
  }

  edit(entity: SpecialPlanEditDto): void {
    this.editSpecialPlanModal.show(entity.id);
  }


  search(): void {
    this.refresh();
  }


  reset(): void {
    this.filter = "";
    this.filterYear = "";
    this.filterUnitGroup = -1;
    this.filterSpecialPlanType = -1;
  }

  refreshbtn(): void{
    this.reset();
    this.refresh();
  }
}
