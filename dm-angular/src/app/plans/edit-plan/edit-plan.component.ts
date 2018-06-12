import { Component, OnInit, Injector, ViewChild, ElementRef, Output, EventEmitter } from '@angular/core';
import { PlanEditDto, PlanServiceProxy, CreateOrUpdatePlanInput, AttachmentListDto, AttachmentServiceProxy } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';

import * as moment from 'moment';
import * as _ from 'lodash';

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
  attachments: AttachmentListDto[] = [];
  active: boolean = false;
  saving: boolean = false;
  constructor(
    injector: Injector,
    private _planService: PlanServiceProxy,
    private _attachmentService: AttachmentServiceProxy

  ) {
    super(injector);
  }

  ngOnInit() {
  }

  onShown(): void {
    $.AdminBSB.input.activate($(this.modalContent.nativeElement));
  }

  show(id: number): void {
    this._planService.getPlanByIdAsync(id).finally(() => {

    }).subscribe((result) => {
      if (result != null) {
        this._attachmentService.getPagedAttachmentsByPlanId("", result.id, "Id", 20, 0).subscribe(result1 => {
          this.attachments = result1.items;
          this.plan = result;
          this.active = true;
          this.modal.show();
        })
      }
    })
  }

  close(): void {
    this.active = false;
    this.modal.hide();
  }

  save(): void {
    this.saving = true;
    this.plan.publishDate = moment(this.plan.publishDate.toString());
    this.plan_edit.plan = this.plan;
    this._planService.createOrUpdatePlan(this.plan_edit).finally(() => {
      this.saving = false;
    }).subscribe(() => {
      this.notify.info(this.l('SavedSuccessfully'));
      this.close();
      this.modalSave.emit(null);
    })
  }

  deleteattachment(entity: AttachmentListDto): void {
    abp.message.confirm("是否确定删除附件" + entity.fileName, (result) => {
      if (result) {
        this._attachmentService.deleteAttachment(entity.id).subscribe(() => {
          this.notify.success(this.l("SuccessfullyDeleted"));
          _.remove(this.attachments, entity);
        })
      }
    });
  }
}
