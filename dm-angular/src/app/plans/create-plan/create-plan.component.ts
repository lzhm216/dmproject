import { Component, OnInit, Injector, ViewChild, ElementRef, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { PlanServiceProxy, PlanEditDto, CreateOrUpdatePlanInput } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';

import * as moment from 'moment';

@Component({
  selector: 'app-plan-modal',
  templateUrl: './create-plan.component.html'
})
export class CreatePlanComponent extends AppComponentBase implements OnInit {

  @ViewChild('createPlanModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  plan: PlanEditDto = new PlanEditDto();
  active: boolean = false;
  saving: boolean = false;
  plan_create: CreateOrUpdatePlanInput = new CreateOrUpdatePlanInput();

  constructor(
    injector: Injector,
    private _planService: PlanServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {

  }

  onShown(): void {
    $.AdminBSB.input.activate($(this.modalContent.nativeElement));
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
    this.saving = true;
    this.plan.publishDate = moment(this.plan.publishDate.toString());
    this.plan_create.plan = this.plan;
    this._planService.createOrUpdatePlan(this.plan_create).finally(()=>{
      this.saving = false;
    }).subscribe(()=>{
      this.notify.info(this.l('SavedSuccessfully'));
      this.close();
      this.modalSave.emit(null);
    })
  }
}
