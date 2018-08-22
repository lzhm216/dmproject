import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { PlanProjectServiceProxy, EnumServiceProxy, PlanListDto, PlanServiceProxy, PagedResultDtoOfPlanListDto, PagedResultDtoOfPlanListWithProjectDto, PlanListWithProjectDto, PlanProjectListDto } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { CreatePlanprojectComponent } from '@app/planprojects/create-planproject/create-planproject.component';
import { EditPlanprojectComponent } from '@app/planprojects/edit-planproject/edit-planproject.component';

@Component({
  selector: 'app-planprojects',
  templateUrl: './planprojects.component.html',
  animations: [appModuleAnimation()]
})

export class PlanprojectsComponent extends PagedListingComponentBase<PlanListWithProjectDto> implements OnInit {

  @ViewChild('createPlanProjectModal') createPlanProjectModal: CreatePlanprojectComponent;
  @ViewChild('editPlanProjectModal') editPlanProjectModal: EditPlanprojectComponent;


  filter: string = '';
  plans: PlanListWithProjectDto[] = [];
  cost: any[] = [];
  unitType: any = null;

  editingPlan: PlanListWithProjectDto = null;

  constructor(
    injector: Injector,
    private _planService: PlanServiceProxy,
    private _planProjectService: PlanProjectServiceProxy,
    private _enumService: EnumServiceProxy
  ) {
    super(injector);
  }

  ngOnInit() {
    this._enumService.getUnitTypeList().subscribe(result => {
      this.unitType = result;
    });
    this.refresh();
  }

  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    this._planService.getPagedPlansWithProject(this.filter, 'Id', request.maxResultCount, request.skipCount).finally(() => {

      finishedCallback();
    }).subscribe((result: PagedResultDtoOfPlanListWithProjectDto) => {

      this.plans = result.items;

      this.showPaging(result, pageNumber);
    })
  }

  protected delete(entity: PlanListWithProjectDto): void {
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

  showPlanProjectsByPlan(entity: PlanListWithProjectDto): void {
    if (entity === this.editingPlan) {
      this.editingPlan = null;
    } else {
      if (entity.planProjects.length <= 0) {
        abp.notify.info("该测绘计划没有测绘计划项目");
        return;
      }
      this.editingPlan = entity;
    }
  }

  protected deletePlanProject(entity: PlanProjectListDto): void {
    abp.message.confirm(
      "是否删除基础测绘计划项目 '" + entity.planProjectTypeName + "'?",
      (result: boolean) => {
        if (result) {
          this._planProjectService.deletePlanProject(entity.id)
            .subscribe(() => {
              abp.notify.info("基础测绘计划项目: " + entity.planName + "已删除");
              this.refresh();
            });
        }
      }
    );
  }

  createPlanProject(): void {
    this.createPlanProjectModal.show();
  }

  editPlanProject(entity: PlanProjectListDto): void {
    this.editPlanProjectModal.show(entity.id);
  }

  reset(): void {
    this.filter = '';
  }

  search(): void {
    this.refresh();
  }
  refresh1(): void {
    this.reset();
    this.refresh();
  }
}
