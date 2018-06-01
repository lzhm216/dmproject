import { Component, OnInit, Injector, ViewChild, ElementRef, EventEmitter, Output } from '@angular/core';
import { PlanProjectTypeServiceProxy, PlanProjectTypeEditDto, CreateOrUpdatePlanProjectTypeInput } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
  selector: 'app-create-projecttype',
  templateUrl: './create-projecttype.component.html'
})
export class CreateProjecttypeComponent extends AppComponentBase {

  @ViewChild('createProjectTypeModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  active: boolean = false;
  saving: boolean = false;

  projectType: PlanProjectTypeEditDto;
  projectType_create: CreateOrUpdatePlanProjectTypeInput = new CreateOrUpdatePlanProjectTypeInput();

  constructor(
    injector: Injector,
    private _projectTypeService: PlanProjectTypeServiceProxy
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
    this.projectType_create.planProjectType = this.projectType;
    this._projectTypeService.createOrUpdatePlanProjectType(this.projectType_create).finally(() => {
      this.saving = false;
    }).subscribe(() => {
      this.notify.info(this.l('SavedSuccessfully'));
      this.close();
      this.modalSave.emit(null);
    })
  }
}
