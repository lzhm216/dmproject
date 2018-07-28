import { Component, OnInit, Injector, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { SpecialPlanTypeServiceProxy, SpecialPlanTypeEditDto, CreateOrUpdateSpecialPlanTypeInput } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
  selector: 'app-create-specialplantype',
  templateUrl: './create-specialplantype.component.html',
  styleUrls: ['./create-specialplantype.component.css']
})
export class CreateSpecialplantypeComponent  extends AppComponentBase {

    
  @ViewChild('createSpecialPlanTypeModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;
  
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  active: boolean = false;
  saving: boolean = false;

  specialPlanType: SpecialPlanTypeEditDto = new SpecialPlanTypeEditDto();
  specialPlanType_create: CreateOrUpdateSpecialPlanTypeInput = new CreateOrUpdateSpecialPlanTypeInput();

  constructor(
    injector:Injector,
    private _specialPlanTypeService: SpecialPlanTypeServiceProxy
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
    this.specialPlanType_create.specialPlanType = this.specialPlanType;
    this._specialPlanTypeService.createOrUpdateSpecialPlanType(this.specialPlanType_create).finally(() => {
      this.saving = false;
    }).subscribe(() => {
      this.notify.info(this.l('SavedSuccessfully'));
      this.close();
      this.modalSave.emit(null);
    })
  }
}
