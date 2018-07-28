import { Component, OnInit, ViewChild, Output, EventEmitter, ElementRef, Injector } from '@angular/core';
import { SpecialPlanTypeEditDto, CreateOrUpdateSpecialPlanTypeInput, SpecialPlanTypeServiceProxy } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
  selector: 'app-edit-specialplantypepe',
  templateUrl: './edit-specialplantypepe.component.html',
  styleUrls: ['./edit-specialplantypepe.component.css']
})
export class EditSpecialplantypepeComponent extends AppComponentBase{

  
  @ViewChild('editSpecialPlanTypeModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;
  
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  
  specialPlanType: SpecialPlanTypeEditDto = new SpecialPlanTypeEditDto();
  specialPlanType_edit: CreateOrUpdateSpecialPlanTypeInput = new CreateOrUpdateSpecialPlanTypeInput();

  active: boolean = false;
  saving: boolean = false;

  constructor(
    injector: Injector,
    private _specialPlanTypeService: SpecialPlanTypeServiceProxy
  ) {
    super(injector);
  }

  onShown(): void {
    $.AdminBSB.input.activate($(this.modalContent.nativeElement));
  }

  show(id: number): void {
    this._specialPlanTypeService.getSpecialPlanTypeByIdAsync(id).finally(()=>{

    }).subscribe((result)=>{
      this.specialPlanType = result;
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
    this.specialPlanType_edit.specialPlanType = this.specialPlanType;
    this._specialPlanTypeService.createOrUpdateSpecialPlanType(this.specialPlanType_edit).finally(()=>{
      this.saving = false;
    }).subscribe(()=>{
      this.notify.info(this.l('SavedSuccessfully'));
      this.close();
      this.modalSave.emit(null);
    })
  }
}
