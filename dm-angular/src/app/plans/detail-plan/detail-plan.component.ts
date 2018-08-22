import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { PlanServiceProxy, PlanListDto, AttachmentListDto, AttachmentServiceProxy, API_BASE_URL, AttachmentDownloadInput } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { FileDownloadService } from '@shared/utils/file-download.service';

@Component({
  selector: 'app-detail-plan',
  templateUrl: './detail-plan.component.html'
})
export class DetailPlanComponent extends AppComponentBase {

  @ViewChild('detailPlanModal') modal: ModalDirective;  

  plan: PlanListDto = new PlanListDto();
  active: boolean = false;
  attachments: AttachmentListDto[] = [];
  filter: string = "";

  downloadInput: AttachmentDownloadInput= new AttachmentListDto();

  publishDate: any = null;

  constructor(
    injector: Injector,
    private _planService: PlanServiceProxy,
    private _attachmentService: AttachmentServiceProxy,
    private _fileDownloadService: FileDownloadService
  ) {
    super(injector);
  }

  show(id: number): void {
    this._planService.getPlanByIdAsync(id).subscribe((result) => {
      if (result != null) {
        this._attachmentService.getPagedAttachmentsByPlanId(this.filter, result.id, "Id", 20, 0).subscribe(result1 => {
          this.attachments = result1.items;
          
        });
        this.plan = result;
        this.publishDate = this.plan.publishDate.format('YYYY-MM-DD');
          this.active = true;
          this.modal.show();
      }
    })
  }


  close(): void {
    this.active = false;
    this.modal.hide();
  }

  download(entity: AttachmentListDto): void{
    this.downloadInput.planId = entity.planId;
    this.downloadInput.fileName = entity.fileName;

    this._attachmentService.download(this.downloadInput).subscribe((result) => {      
      this._fileDownloadService.downloadTempFile(encodeURI(result.newFileName));
    });
    
  }
}
