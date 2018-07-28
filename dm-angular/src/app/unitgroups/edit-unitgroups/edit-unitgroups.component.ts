import { Component, OnInit, ViewChild, ElementRef, Output, EventEmitter, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { UnitGroupEditDto, CreateOrUpdateUnitGroupInput, UnitGroupServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-unitgroups',
  templateUrl: './edit-unitgroups.component.html',
  styleUrls: ['./edit-unitgroups.component.css']
})
export class EditUnitgroupsComponent extends AppComponentBase {

  
  @ViewChild('editUnitGroupModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;
  
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  
  unitGroup: UnitGroupEditDto = new UnitGroupEditDto();
 unitGroup_create: CreateOrUpdateUnitGroupInput = new CreateOrUpdateUnitGroupInput();

  active: boolean = false;
  saving: boolean = false;

  constructor(
    injector: Injector,    
    private _unitGroupService: UnitGroupServiceProxy

  ) {
    super(injector);
  }

  onShown(): void {
    $.AdminBSB.input.activate($(this.modalContent.nativeElement));
  }

  show(id: number): void {
    this._unitGroupService.getUnitGroupForEdit(id).finally(()=>{

    }).subscribe((result)=>{
      this.unitGroup = result.unitGroup;
      this.active = true;
      this.modal.show();
    })
  }

  close(): void{
    this.active = false;
    this.modal.hide();
  }
  
  save(): void {
    this.saving = true;
    this.unitGroup_create.unitGroup = this.unitGroup;
    this._unitGroupService.createOrUpdateUnitGroup(this.unitGroup_create).finally(()=>{
      this.saving = false;
    }).subscribe(()=>{
      this.notify.info(this.l('SavedSuccessfully'));
      this.close();
      this.modalSave.emit(null);
    })
  }

}
