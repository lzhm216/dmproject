import { Component, OnInit, Injector, ViewChild, ElementRef, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { PlanServiceProxy, PlanEditDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
  selector: 'create-plan-modal',
  templateUrl: './create-plan.component.html',
  styleUrls: ['./create-plan.component.css']
})
export class CreatePlanComponent extends AppComponentBase {

  @ViewChild('createPlanModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  plan: PlanEditDto = null;
  active: boolean = false;
  saving: boolean = false;

  constructor(
    injector: Injector,
    private _planService: PlanServiceProxy
  ) {
    super(injector);
  }

  onShow(): void {
    $.AdminBSB.input.active($(this.modalContent.nativeElement));
  }

  show(): void {
    this.active = true;
    this.modal.show();
  }

  close(): void{
    this.active = false;
    this.modal.hide();
  }

  save(): void{
    /* this.saving = true;
    this._planService.createOrUpdatePlan({plan: this.plan}).finally(()=>{
      this.saving = false;
    }).subscribe(()=>{
      this.notify.info(this.l('SavedSuccessfully'));
      this.close();
      this.modalSave.emit(null);
    }) */
  }
}
