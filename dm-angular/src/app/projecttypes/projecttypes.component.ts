import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { PlanProjectTypeServiceProxy, PlanProjectTypeListDto, PlanProjectTypeEditDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { CreateProjecttypeComponent } from '@app/projecttypes/create-projecttype/create-projecttype.component';
import { EditProjecttypeComponent } from '@app/projecttypes/edit-projecttype/edit-projecttype.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';

@Component({
  selector: 'app-projecttypes',
  templateUrl: './projecttypes.component.html',
  animations: [appModuleAnimation()]
})
export class ProjecttypesComponent extends PagedListingComponentBase<PlanProjectTypeListDto> implements OnInit {

  @ViewChild('createProjectTypeModal') createProjectTypeModal: CreateProjecttypeComponent;
  @ViewChild('editProjectTypeModal') editProjectTypeModal: EditProjecttypeComponent;

  filter: string = "";
  projectTypes: PlanProjectTypeListDto[] = [];

  constructor(
    injector: Injector,
    private _projectTypeService: PlanProjectTypeServiceProxy
  ) {
    super(injector);
  }

  ngOnInit() {
  }


  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    this._projectTypeService.getPagedPlanProjectTypes(this.filter, "Id", request.maxResultCount, request.skipCount).finally(() => {
      finishedCallback();
    }).subscribe(result => {
      this.projectTypes = result.items;
      this.showPaging(result, pageNumber);
    })
  }

  protected delete(entity: PlanProjectTypeListDto): void {
    abp.message.confirm(
      "Delete ProjectType '" + entity.planProjectTypeName + "'?",
      (result: boolean) => {
        if (result) {
          this._projectTypeService.deletePlanProjectType(entity.id)
            .subscribe(() => {
              abp.notify.info("Deleted ProjectType: " + entity.planProjectTypeName);
              this.refresh();
            });
        }
      }
    );
  }

  createProjectType(): void {
    this.createProjectTypeModal.show();
  }

  editProjectType(projectTypes: PlanProjectTypeEditDto): void{
    this.editProjectTypeModal.show(projectTypes.id);
  }
}
