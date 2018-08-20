import { Component, OnInit, ViewChild, ElementRef, Output, EventEmitter, Injector } from '@angular/core';
import { TaskBookEditDto, CreateOrUpdateTaskBookInput, TaskBookServiceProxy, UnitGroupServiceProxy, SpecialPlanTypeServiceProxy, UnitGroupListDto, SpecialPlanTypeListDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';

import * as moment from 'moment';

@Component({
  selector: 'app-edit-taskbook',
  templateUrl: './edit-taskbook.component.html'
})
export class EditTaskbookComponent extends AppComponentBase implements OnInit {

  @ViewChild('editTaskBookModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  active: boolean = false;
  saving: boolean = false;

  taskbook: TaskBookEditDto = new TaskBookEditDto();
  taskbook_edit: CreateOrUpdateTaskBookInput = new CreateOrUpdateTaskBookInput();

  unitGroups: UnitGroupListDto[] = [];
  specialPlanTypes: SpecialPlanTypeListDto[] = [];

  constructor(
    injector: Injector,
    private _taskBookService: TaskBookServiceProxy,
    private _unitGroupService: UnitGroupServiceProxy,
    private _specialPlanTypeService: SpecialPlanTypeServiceProxy
  ) {
    super(injector);
  }

  ngOnInit() {

  }

  onShown(): void {
    this._unitGroupService.getAllUnitGroups().subscribe(result => {
      this.unitGroups = result.items;
    });

    this._specialPlanTypeService.getAllSpecialPlanType().subscribe(result => {
      this.specialPlanTypes = result.items;
    });
    
    $.AdminBSB.input.activate($(this.modalContent.nativeElement));
  }

  show(id: number): void {
    this._taskBookService.getTaskBookByIdAsync(id).subscribe((result) => {
      if(result!=null){
        this.taskbook = result;
      }
    });
    this.active = true;
    this.modal.show();
  }

  close(): void {
    this.active = false;
    this.modal.hide();
  }

  save(): void {
    this.saving = true;
    var localOffset  = new Date().getTimezoneOffset() * 60000;

    this.taskbook.signDate = this.taskbook.signDate ? moment(this.taskbook.signDate.toString()).subtract('milliseconds',localOffset) : <any>undefined;
    this.taskbook.completeDate = this.taskbook.completeDate ? moment(this.taskbook.completeDate.toString()).subtract('milliseconds',localOffset) : <any>undefined;
    this.taskbook.year =this.taskbook.year ? moment(this.taskbook.year.toString()).subtract('milliseconds',localOffset) : <any>undefined;

    this.taskbook_edit.taskBook = this.taskbook;
    this._taskBookService.createOrUpdateTaskBook(this.taskbook_edit).finally(() => {
      this.saving = false;
      this.taskbook = new TaskBookEditDto();
    }).subscribe(() => {
      this.notify.info(this.l('SavedSuccessfully'));
      this.close();
      this.modalSave.emit(null);
    })
  }

}
