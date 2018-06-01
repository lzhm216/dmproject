import { Component, OnInit, Injector } from '@angular/core';
import { PlanProjectServiceProxy, PagedResultDtoOfPlanProjectListDto, PlanProjectListDto, EnumServiceProxy } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';

@Component({
  selector: 'app-planprojects',
  templateUrl: './planprojects.component.html',
  animations: [appModuleAnimation()]
})

export class PlanprojectsComponent extends PagedListingComponentBase<PlanProjectListDto> implements OnInit {

  filter: string = "";
  planProjects: PlanProjectListDto[] = [];
  unitType: any = null;

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
      result.items.forEach(element => {
        switch(element.unit) {
          case 0：element.unit = this.unitType.
        }
      });
      this.planProjects = result.items;
      this.showPaging(result, pageNumber);
    })
  }

  protected delete(entity: PlanProjectListDto): void {
    throw new Error("Method not implemented.");
  }
}
