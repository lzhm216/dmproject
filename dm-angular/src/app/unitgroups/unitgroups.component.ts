import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { UnitGroupListDto, UnitGroupServiceProxy, UnitGroupEditDto } from '@shared/service-proxies/service-proxies';
import { CreateUnitgroupsComponent } from '@app/unitgroups/create-unitgroups/create-unitgroups.component';
import { EditUnitgroupsComponent } from '@app/unitgroups/edit-unitgroups/edit-unitgroups.component';

@Component({
  selector: 'app-unitgroups',
  templateUrl: './unitgroups.component.html',
  styleUrls: ['./unitgroups.component.css']
})
export class UnitgroupsComponent extends PagedListingComponentBase<UnitGroupListDto> {

 
  @ViewChild('createUnitGroupModal') createUnitGroupModal: CreateUnitgroupsComponent;
  @ViewChild('editUnitGroupModal') editUnitGroupModal: EditUnitgroupsComponent;

  
  filter: string = "";
  unitGroups: UnitGroupListDto[] = [];

  constructor( injector: Injector,
    private _unitGroupService: UnitGroupServiceProxy
  ) {
    super(injector);
   }

 
   protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    this._unitGroupService.getPagedUnitGroups(this.filter, "Id", request.maxResultCount, request.skipCount).finally(() => {
      finishedCallback();
    }).subscribe(result => {
      this.unitGroups = result.items;
      this.showPaging(result, pageNumber);
    })
  }
  
  protected delete(entity: UnitGroupListDto): void {
    abp.message.confirm(
      "是否删除专项测绘计划名称 '" + entity.unitGroupName + "'?",
      (result: boolean) => {
        if (result) {
          this._unitGroupService.deleteUnitGroup(entity.id)
            .subscribe(() => {
              abp.notify.info("测绘计划项目名称: " + entity.unitGroupName + "已删除");
              this.refresh();
            });
        }
      }
    );
  }

  protected createUnitGroup(){
    this.createUnitGroupModal.show();
  }

  protected editUnitGroup(unitGroup: UnitGroupEditDto): void{
    this.editUnitGroupModal.show(unitGroup.id);
  }

}
