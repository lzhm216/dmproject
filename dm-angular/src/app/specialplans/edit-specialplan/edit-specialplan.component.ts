import { Component, OnInit, ViewChild, ElementRef, Output, EventEmitter, Injector } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { SpecialPlanEditDto, CreateOrUpdateSpecialPlanInput, SpecialPlanTypeListDto, SpecialPlanServiceProxy, SpecialPlanTypeServiceProxy, EnumServiceProxy, PlanServiceProxy, PlanListDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';

import * as moment from 'moment';

@Component({
  selector: 'app-edit-specialplan',
  templateUrl: './edit-specialplan.component.html',
  styleUrls: ['./edit-specialplan.component.css']
})
export class EditSpecialplanComponent extends AppComponentBase implements OnInit {

  @ViewChild('editSpecialPlanModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  active: boolean = false;
  saving: boolean = false;

  specialplan: SpecialPlanEditDto = new SpecialPlanEditDto();
  specialplan_edit: CreateOrUpdateSpecialPlanInput = new CreateOrUpdateSpecialPlanInput();

  specialPlanTypes: SpecialPlanTypeListDto[] = [];
  unitTypes: any = null;
  plans: PlanListDto[] = [];

  
  constructor( injector: Injector,
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
    
    this._planService.getPlanList("", "", 100, 0).subscribe(result => {
      this.plans = result;
    });


    this._specialPlanTypeService.getAllSpecialPlanType().subscribe(result => {
      this.specialPlanTypes = result.items;
    });


    this._enumService.getUnitTypeList().subscribe(result => {
      this.unitTypes = result;
    })
  }

  show(id: number): void {
    this._specialPlanService.getSpecialPlanByIdAsync(id).subscribe((result) => {
      if(result!=null){
        this.specialplan = result;
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

    
    this.specialplan.completeDate = this.specialplan.completeDate ? moment(this.specialplan.completeDate.toString()).subtract('milliseconds',localOffset) : <any>undefined;
    this.specialplan.year =this.specialplan.year ? moment(this.specialplan.year.toString()).subtract('milliseconds',localOffset) : <any>undefined;

    this.specialplan_edit.specialPlan = this.specialplan;
    this._specialPlanService.createOrUpdateSpecialPlan(this.specialplan_edit).finally(() => {
      this.saving = false;
      this.specialplan = new SpecialPlanEditDto();
    }).subscribe(() => {
      this.notify.info(this.l('SavedSuccessfully'));
      this.close();
      this.modalSave.emit(null);
    })
  }

}
