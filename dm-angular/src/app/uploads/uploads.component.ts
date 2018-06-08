import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http';
import { AttachmentEditDto, AttachmentServiceProxy } from '@shared/service-proxies/service-proxies';
@Component({
  selector: 'app-uploads',
  templateUrl: './uploads.component.html'
})
export class UploadsComponent extends AppComponentBase  {

  constructor(
    injector: Injector,
    private _attachmentService: AttachmentServiceProxy
  ) { 
    super(injector);
  }
  
  upload(files) {
    if (files.length === 0)
      return;

    for (let file of files){
      //const formData = new FormData();
    //formData.append('file', file);
      this._attachmentService.upload(3, file).subscribe(() => {
        
        this.notify.info(this.l('SavedSuccessfully'));
      });
    }
  }
}
