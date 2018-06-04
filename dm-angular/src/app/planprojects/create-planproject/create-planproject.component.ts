import { Component, OnInit, Injector, ViewChild, Output, EventEmitter, ElementRef } from '@angular/core';
import { PlanProjectServiceProxy, PlanProjectTypeServiceProxy, PlanProjectListDto, PlanProjectEditDto, CreateOrUpdatePlanProjectInput, PlanProjectTypeListDto, EnumServiceProxy, PlanListDto } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal/modal.directive';
import { AppComponentBase } from '@shared/app-component-base';
import { RESOURCE_CACHE_PROVIDER } from '@angular/platform-browser-dynamic';

@Component({
  selector: 'app-create-planproject',
  templateUrl: './create-planproject.component.html'
})

export class CreatePlanprojectComponent extends AppComponentBase implements OnInit {

  active: boolean = false;
  saving: boolean = false;

  plans: PlanListDto[]=[];
  planProject: PlanProjectEditDto = new PlanProjectEditDto();
  planProject_create: CreateOrUpdatePlanProjectInput = new CreateOrUpdatePlanProjectInput();
  planProjectTypes: PlanProjectTypeListDto[] = [];
  unitTypes: any = null;

  @ViewChild('createPlanProjectModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _planProjectService: PlanProjectServiceProxy,
    private _planProjectTypeService: PlanProjectTypeServiceProxy,
    private _enumService: EnumServiceProxy,
  ) {
    super(injector);
  }

  ngOnInit() {
    this._planProjectTypeService.getPagedPlanProjectTypes("", "", 10, 0).subscribe(result => {
      this.planProjectTypes = result.items;
    });

    this._planProjectService.getAllPlansAsync().subscribe(result=>{
      this.plans = result.items;
    });

    this._enumService.getUnitTypeList().subscribe(result=>{
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
    this.planProject_create.planProject = this.planProject;
    this._planProjectService.createOrUpdatePlanProject(this.planProject_create).finally(() => {
      this.saving = false;
    }).subscribe(() => {
      this.notify.info(this.l('SavedSuccessfully'));
      this.close();
      this.modalSave.emit(null);
    })
  }
}
