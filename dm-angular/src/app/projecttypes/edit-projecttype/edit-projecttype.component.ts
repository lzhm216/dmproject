import { Component, OnInit, Injector, ViewChild, ElementRef, EventEmitter, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { PlanProjectTypeEditDto, CreateOrUpdatePlanProjectTypeInput, PlanProjectTypeServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
  selector: 'app-edit-projecttype',
  templateUrl: './edit-projecttype.component.html'
})
export class EditProjecttypeComponent extends AppComponentBase {
  
  @ViewChild('editProjectTypeModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;
  
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  
  projectType: PlanProjectTypeEditDto = new PlanProjectTypeEditDto();;
  projectType_edit: CreateOrUpdatePlanProjectTypeInput = new CreateOrUpdatePlanProjectTypeInput();

  active: boolean = false;
  saving: boolean = false;

  constructor(
    injector: Injector,
    private _projectTypeService: PlanProjectTypeServiceProxy
  ) {
    super(injector);
  }

  onShown(): void {
    $.AdminBSB.input.activate($(this.modalContent.nativeElement));
  }

  show(id: number): void {
    this._projectTypeService.getPlanProjectTypeForEdit(id).finally(()=>{

    }).subscribe((result)=>{
      this.projectType = result.planProjectType;
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
    this.projectType_edit.planProjectType = this.projectType;
    this._projectTypeService.createOrUpdatePlanProjectType(this.projectType_edit).finally(()=>{
      this.saving = false;
    }).subscribe(()=>{
      this.notify.info(this.l('SavedSuccessfully'));
      this.close();
      this.modalSave.emit(null);
    })
  }
}
