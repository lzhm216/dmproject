import { Component, OnInit, Injector, Input } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { AttachmentListDto, PagedResultDtoOfAttachmentListDto, AttachmentServiceProxy } from '@shared/service-proxies/service-proxies';
import * as _ from 'lodash';

@Component({
  selector: 'app-plan-attachment',
  templateUrl: './plan-attachment.component.html',
  styleUrls: ['./plan-attachment.component.css']
})
export class PlanAttachmentComponent extends PagedListingComponentBase<AttachmentListDto>  {

  @Input() attachments: AttachmentListDto []=[];
   pagedattachmentdto: PagedResultDtoOfAttachmentListDto = new PagedResultDtoOfAttachmentListDto();
  constructor(
    injector: Injector,
    private _attachmentService: AttachmentServiceProxy
  ) {
    super(injector);
  }

  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    this.pagedattachmentdto.items = this.attachments;
    this.showPaging(this.pagedattachmentdto, pageNumber);
    finishedCallback();
  }

  protected delete(entity: AttachmentListDto): void {
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
