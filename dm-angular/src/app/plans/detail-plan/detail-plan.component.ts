import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { PlanServiceProxy, PlanListDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
  selector: 'app-detail-plan',
  templateUrl: './detail-plan.component.html',
  styleUrls: ['./detail-plan.component.css']
})
export class DetailPlanComponent extends AppComponentBase  {

  @ViewChild('detailPlanModal') modal: ModalDirective;
  
  plan: PlanListDto = new PlanListDto();
  active: boolean = false;

  constructor(
    injector: Injector,
    private _planService: PlanServiceProxy
  ) { 
    super(injector);
  }

  show(id: number): void {
    this._planService.getPlanByIdAsync(id).finally(()=>{

    }).subscribe((result)=>{
      this.plan = result;
      this.active = true;
      this.modal.show();
    })
  }

  
  close(): void{
    this.active = false;
    this.modal.hide();
  }
}
