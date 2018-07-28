import { Component, OnInit, ViewChild, ElementRef, Output, EventEmitter, Injector } from '@angular/core';
import { UnitGroupEditDto, CreateOrUpdateUnitGroupInput, UnitGroupServiceProxy } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
  selector: 'app-create-unitgroups',
  templateUrl: './create-unitgroups.component.html',
  styleUrls: ['./create-unitgroups.component.css']
})
export class CreateUnitgroupsComponent   extends AppComponentBase {

    
  @ViewChild('createUnitGroupModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;
  
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  active: boolean = false;
  saving: boolean = false;

  unitGroup: UnitGroupEditDto = new UnitGroupEditDto();
 unitGroup_create: CreateOrUpdateUnitGroupInput = new CreateOrUpdateUnitGroupInput();

  constructor(
    injector:Injector,
    private _unitGroupService: UnitGroupServiceProxy
  ) {
    super(injector);
  }

  onShown(): void {
    $.AdminBSB.input.activate($(this.modalContent.nativeElement));
  }


  show(): void {
    this.active = true;
    this.modal.show();
    
  }

  close(): void {
    this.active = false;
    this.modal.hide();
  }

  save(): void {
    this.saving = true;
    this.unitGroup_create.unitGroup = this.unitGroup;
    this._unitGroupService.createOrUpdateUnitGroup(this.unitGroup_create).finally(() => {
      this.saving = false;
    }).subscribe(() => {
      this.notify.info(this.l('SavedSuccessfully'));
      this.close();
      this.modalSave.emit(null);
    })
  }
}
