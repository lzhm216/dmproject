import { Component, OnInit, ViewChild, Output, ElementRef, EventEmitter, Injector } from '@angular/core';
import { ModalDirective } from '../../../../node_modules/ngx-bootstrap';
import { TaskBookEditDto, CreateOrUpdateTaskBookInput, TaskBookServiceProxy, UnitGroupServiceProxy, SpecialPlanTypeServiceProxy, UnitGroupListDto, SpecialPlanTypeListDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';

import * as moment from 'moment';

@Component({
  selector: 'app-add-taskbook',
  templateUrl: './add-taskbook.component.html',
  styleUrls: ['./add-taskbook.component.css']
})
export class AddTaskbookComponent extends AppComponentBase implements OnInit {
  
  @ViewChild('addTaskBookModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  active: boolean = false;
  saving: boolean = false;

  taskbook: TaskBookEditDto = new TaskBookEditDto();
  taskbook_create: CreateOrUpdateTaskBookInput = new CreateOrUpdateTaskBookInput();

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

  onShown(): void {
    $.AdminBSB.input.activate($(this.modalContent.nativeElement));
  }

  ngOnInit() {
    this._unitGroupService.getAllUnitGroups().subscribe(result => {
      this.unitGroups = result.items;
    });

    this._specialPlanTypeService.getAllSpecialPlanType().subscribe(result => {
      this.specialPlanTypes = result.items;
    });
    
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
    this.taskbook.signDate = moment(this.taskbook.signDate.toString());
    this.taskbook.completeDate = moment(this.taskbook.completeDate.toString());
    this.taskbook.year = moment(this.taskbook.year.toString());
    this.taskbook_create.taskBook = this.taskbook;
    this._taskBookService.createOrUpdateTaskBook(this.taskbook_create).finally(() => {
      this.saving = false;
    }).subscribe((result) => {    
      this.notify.info(this.l('SavedSuccessfully'));
      this.close();
      this.modalSave.emit(null);

    })
  }
}
