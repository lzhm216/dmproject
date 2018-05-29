import { Component, OnInit, Injector, ViewChild, ElementRef, Output, EventEmitter } from '@angular/core';
import { PlanEditDto, PlanServiceProxy, CreateOrUpdatePlanInput } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';

import * as moment from 'moment';

@Component({
  selector: 'app-edit-plan',
  templateUrl: './edit-plan.component.html'
})
export class EditPlanComponent extends AppComponentBase implements OnInit {
  
  @ViewChild('editPlanModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;
  
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  
  plan: PlanEditDto = new PlanEditDto();
  plan_edit: CreateOrUpdatePlanInput = new CreateOrUpdatePlanInput();
  active: boolean = false;
  saving: boolean = false;
  constructor(
    injector: Injector,
    private _planService: PlanServiceProxy

  ) {
    super(injector);
  }

  ngOnInit() {
  }

  onShown(): void {
    $.AdminBSB.input.activate($(this.modalContent.nativeElement));
  }

  show(id: number): void {
    this._planService.getPlanByIdAsync(id).finally(()=>{

    }).subscribe((result)=>{
      this.plan = result;
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
    this.plan.publishDate = moment(this.plan.publishDate.toString());
    this.plan_edit.plan = this.plan;
    this._planService.createOrUpdatePlan(this.plan_edit).finally(()=>{
      this.saving = false;
    }).subscribe(()=>{
      this.notify.info(this.l('SavedSuccessfully'));
      this.close();
      this.modalSave.emit(null);
    })
  }
}
