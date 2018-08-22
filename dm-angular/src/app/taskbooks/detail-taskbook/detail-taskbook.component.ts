import { Component, OnInit, ViewChild, ElementRef, Output, EventEmitter, Injector } from '@angular/core';
import { TaskBookEditDto, CreateOrUpdateTaskBookInput, TaskBookServiceProxy, UnitGroupServiceProxy, SpecialPlanTypeServiceProxy, UnitGroupListDto, SpecialPlanTypeListDto, TaskBookListDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap/modal/modal.directive';

@Component({
  selector: 'app-detail-taskbook',
  templateUrl: './detail-taskbook.component.html'
})
export class DetailTaskbookComponent extends AppComponentBase {

  @ViewChild('detailTaskBookModal') modal: ModalDirective;

  active: boolean = false;
  taskbook: TaskBookListDto = new TaskBookListDto();

  completeDate: any = null;
  signDate: any = null;

  constructor(injector: Injector,
    private _taskBookService: TaskBookServiceProxy
  ) {
    super(injector);
  }

  show(id: number): void {
    this._taskBookService.getTaskBookDetailByIdAsync(id).subscribe((result) => {
      if (result != null) {

        this.taskbook = result;
        this.completeDate = this.taskbook.completeDate.format('YYYY-MM-DD');
        this.signDate = this.taskbook.signDate.format('YYYY-MM-DD');
        
        this.active = true;
        this.modal.show();
      }
    })
  }


  close(): void {
    this.active = false;
    this.modal.hide();
  }

}
