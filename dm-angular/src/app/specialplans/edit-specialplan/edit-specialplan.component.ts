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

  year: any = null;
  completeDate: any = null;

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

  show(id: number): void {
    this._specialPlanService.getSpecialPlanByIdAsync(id).subscribe((result) => {
      if(result!=null){
        this.specialplan = result;
        this.year = this.specialplan.year.format('YYYY');
        this.completeDate = this.specialplan.completeDate.format('YYYY-MM-DD');
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
    
    this.specialplan.completeDate = this.completeDate ? moment(this.completeDate.toString()).subtract('milliseconds',localOffset) : <any>undefined;
    this.specialplan.year =this.year ? moment(this.year.toString()).subtract('milliseconds',localOffset) : <any>undefined;

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

  transform(transTime): string {
    let date = new Date(transTime);
    let year = date.getFullYear();
    let month = date.getMonth() + 1;
    let months = month < 10 ? '0' + month : month;
    let d = date.getDate() < 10 ? '0' + date.getDate() : date.getDate();
    return year + '-' + months + '-' + d;
  }

}
