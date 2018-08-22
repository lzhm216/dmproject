import { Component, OnInit, Injector, ViewChild, ElementRef, EventEmitter, Output } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { PlanServiceProxy, PlanEditDto, CreateOrUpdatePlanInput, AttachmentEditDto, AttachmentServiceProxy } from '@shared/service-proxies/service-proxies';
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

  active: boolean = false;
  saving: boolean = false;

  plan: PlanEditDto = new PlanEditDto();
  plan_create: CreateOrUpdatePlanInput = new CreateOrUpdatePlanInput();

  attachment: AttachmentEditDto = new AttachmentEditDto();

  constructor(
    injector: Injector,
    private _planService: PlanServiceProxy,
    private _attachmentService: AttachmentServiceProxy
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

  close(): void {
    this.active = false;
    this.modal.hide();
  }

  save(): void {
    this.saving = true;
    this.plan.publishDate = this.plan.publishDate ? moment(this.plan.publishDate.toString()) : <any>undefined;
    this.plan_create.plan = this.plan;

    this._planService.createOrUpdatePlan(this.plan_create).subscribe((result) => {
      const fileUpload = document.getElementById('attachment') as HTMLInputElement;
      if (fileUpload.files[0]) {
        this._attachmentService.upload(result.id, fileUpload.files[0]).subscribe((result2) => {
        });
      }

      this.notify.info(this.l('SavedSuccessfully'));
      this.close();
      this.modalSave.emit(null);
    })
  }
}
