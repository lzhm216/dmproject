import { Component, OnInit, Output, ViewChild, ElementRef, EventEmitter, Injector } from '@angular/core';
import { SpecialPlanEditDto, CreateOrUpdateSpecialPlanInput, SpecialPlanTypeListDto, SpecialPlanServiceProxy, EnumServiceProxy, SpecialPlanTypeServiceProxy, PlanListDto, PlanServiceProxy } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';

import * as moment from 'moment';

@Component({
  selector: 'app-create-specialplan',
  templateUrl: './create-specialplan.component.html',
  styleUrls: ['./create-specialplan.component.css']
})
export class CreateSpecialplanComponent extends AppComponentBase implements OnInit {


  @ViewChild('addSpecialPlanModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  active: boolean = false;
  saving: boolean = false;

  specialplan: SpecialPlanEditDto = new SpecialPlanEditDto();
  specialplan_create: CreateOrUpdateSpecialPlanInput = new CreateOrUpdateSpecialPlanInput();

  specialPlanTypes: SpecialPlanTypeListDto[] = [];
  unitTypes: any = null;
  plans: PlanListDto[] = [];
  
  constructor(
    injector: Injector,
    private _planService: PlanServiceProxy,
    private _specialPlanService: SpecialPlanServiceProxy,
    private _specialPlanTypeService: SpecialPlanTypeServiceProxy,
    private _enumService: EnumServiceProxy
  ) {
    super(injector);
  }

  ngOnInit() {

    this.plans = [];
    this.specialPlanTypes = [];
    this.unitTypes = null;
    
    this._planService.getPlanList("", "Id", 20, 0).subscribe(result => {
      this.plans = result;
    });

    this._specialPlanTypeService.getAllSpecialPlanType().subscribe(result => {
      this.specialPlanTypes = result.items;
    });


    this._enumService.getUnitTypeList().subscribe(result => {
      this.unitTypes = result;
    })
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
    var localOffset  = new Date().getTimezoneOffset() * 60000;

    this.specialplan.year = this.specialplan.year ? moment(this.specialplan.year.toString()).subtract('milliseconds', localOffset) : <any>undefined;

    this.specialplan.completeDate = this.specialplan.completeDate ? moment(this.specialplan.completeDate.toString()).subtract('milliseconds', localOffset) : <any>undefined;

    this.specialplan_create.specialPlan = this.specialplan;
    this._specialPlanService.createOrUpdateSpecialPlan(this.specialplan_create).finally(() => {
      this.saving = false;
    }).subscribe(() => {
      this.notify.info(this.l('SavedSuccessfully'));
      this.specialplan = null;
      this.close();
      this.modalSave.emit(null);
      this.specialplan = new SpecialPlanEditDto();
    })
  }
}
