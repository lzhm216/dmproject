import { Component, OnInit, Injector, ViewChild, ElementRef } from '@angular/core';
import { PlanEditDto, PlanServiceProxy } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
  selector: 'app-edit-plan',
  templateUrl: './edit-plan.component.html'
})
export class EditPlanComponent extends AppComponentBase implements OnInit {
  
  @ViewChild('editPlanModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;
  
  plan: PlanEditDto = new PlanEditDto();
  active:boolean = false;

  constructor(
    injector: Injector,
    _planService: PlanServiceProxy

  ) {
    super(injector);
  }

  ngOnInit() {
  }

  onShown(): void {
    $.AdminBSB.input.active($(this.modalContent.nativeElement));
  }

  show(): void {
    this.active = true;
    this.modal.show();
  }

  close(): void{
    this.active = false;
    this.modal.hide();
  }
  
  save(): void {

  }
}
