import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { PlanProjectServiceProxy, PagedResultDtoOfPlanProjectListDto, PlanProjectListDto, EnumServiceProxy } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { CreatePlanprojectComponent } from '@app/planprojects/create-planproject/create-planproject.component';
import { EditPlanprojectComponent } from '@app/planprojects/edit-planproject/edit-planproject.component';

@Component({
  selector: 'app-planprojects',
  templateUrl: './planprojects.component.html',
  animations: [appModuleAnimation()]
})

export class PlanprojectsComponent extends PagedListingComponentBase<PlanProjectListDto> implements OnInit {

  filter: string = "";
  planProjects: PlanProjectListDto[] = [];
  unitType: any = null;

  @ViewChild('createPlanProjectModal') createPlanProjectModal: CreatePlanprojectComponent;
  @ViewChild('editPlanProjectModal') editPlanProjectModal: EditPlanprojectComponent;

  constructor(
    injector: Injector,
    private _planProjectService: PlanProjectServiceProxy,
    private _enumService: EnumServiceProxy
  ) {
    super(injector);
  }

  ngOnInit() {
    this._enumService.getUnitTypeList().subscribe(result => {
      this.unitType = result;
    });
  }


  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    this._planProjectService.getPagedPlanProjects(this.filter, 'Id', request.maxResultCount, request.skipCount).finally(() => {
      finishedCallback();
    }).subscribe((result: PagedResultDtoOfPlanProjectListDto) => {
      this.planProjects = result.items;
      this.showPaging(result, pageNumber);
    })
  }

  protected delete(entity: PlanProjectListDto): void {
    throw new Error("Method not implemented.");
  }

  createPlanProject(): void{
    this.createPlanProjectModal.show();
  }

  editPlanProject(): void{
    this.editPlanProjectModal.show();
  }
}
