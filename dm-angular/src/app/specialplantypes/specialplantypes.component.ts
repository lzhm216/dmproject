import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { SpecialPlanTypeServiceProxy, SpecialPlanTypeListDto, SpecialPlanTypeEditDto } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { EditSpecialplantypepeComponent } from '@app/specialplantypes/edit-specialplantypepe/edit-specialplantypepe.component';
import { CreateSpecialplantypeComponent } from '@app/specialplantypes/create-specialplantype/create-specialplantype.component';

@Component({
  selector: 'app-specialplantypes',
  templateUrl: './specialplantypes.component.html',
  animations: [appModuleAnimation()]
})
export class SpecialplantypesComponent extends PagedListingComponentBase<SpecialPlanTypeListDto> {

  @ViewChild('createSpecialPlanTypeModal') createSpecialPlanTypeModal: CreateSpecialplantypeComponent;
  @ViewChild('editSpecialPlanTypeModal') editSpecialPlanTypeModal: EditSpecialplantypepeComponent;

  
  filter: string = "";
  specialPlanTypes:SpecialPlanTypeListDto[] = [];

  constructor( injector: Injector,
    private _specialPlanTypeService: SpecialPlanTypeServiceProxy
  ) {
    super(injector);
   }


  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    this._specialPlanTypeService.getPagedSpecialPlanTypes(this.filter, "Id", request.maxResultCount, request.skipCount).finally(() => {
      finishedCallback();
    }).subscribe(result => {
      this.specialPlanTypes = result.items;
      this.showPaging(result, pageNumber);
    })
  }
  
  protected delete(entity: SpecialPlanTypeListDto): void {
    abp.message.confirm(
      "是否删除专项测绘计划名称 '" + entity.specialPlanTypeName + "'?",
      (result: boolean) => {
        if (result) {
          this._specialPlanTypeService.deleteSpecialPlanType(entity.id)
            .subscribe(() => {
              abp.notify.info("测绘计划项目名称: " + entity.specialPlanTypeName + "已删除");
              this.refresh();
            });
        }
      }
    );
  }

  protected createSpecialPlanType(){
    this.createSpecialPlanTypeModal.show();
  }

  protected editProjectType(specialPlanType: SpecialPlanTypeEditDto): void{
    this.editSpecialPlanTypeModal.show(specialPlanType.id);
  }
}
