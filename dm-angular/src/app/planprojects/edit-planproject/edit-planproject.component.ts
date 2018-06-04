import { Component, OnInit, ViewChild, ElementRef, Output, EventEmitter, Injector } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal/modal.directive';
import { PlanProjectServiceProxy, PlanProjectTypeServiceProxy, PlanProjectTypeListDto, CreateOrUpdatePlanProjectInput, PlanProjectEditDto, PlanListDto, EnumServiceProxy } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
  selector: 'app-edit-planproject',
  templateUrl: './edit-planproject.component.html'
})
export class EditPlanprojectComponent extends AppComponentBase implements OnInit {

  @ViewChild('editPlanProjectModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  active: boolean = false;
  saving: boolean = false;

  plans: PlanListDto[] = [];
  planProjectTypes: PlanProjectTypeListDto[] = [];
  planProject_edit: CreateOrUpdatePlanProjectInput = new CreateOrUpdatePlanProjectInput();
  planProject: PlanProjectEditDto = new PlanProjectEditDto();
  unitTypes: any = null;

  constructor(
    injector: Injector,
    private _planProjectService: PlanProjectServiceProxy,
    private _planProjectTypeService: PlanProjectTypeServiceProxy,
    private _enumService: EnumServiceProxy

  ) {
    super(injector);
  }

  ngOnInit() {
    this._planProjectTypeService.getPagedPlanProjectTypes("", "Id", 50, 0).subscribe(result => {
      this.planProjectTypes = result.items;
    });

    this._planProjectService.getAllPlansAsync().subscribe(result => {
      this.plans = result.items;
    });

    this._enumService.getUnitTypeList().subscribe(result => {
      this.unitTypes = result;
    })

  }

  onShown(): void {
    $.AdminBSB.input.activate($(this.modalContent.nativeElement));
  }

  show(id: number): void {

    this._planProjectService.getPlanProjectByIdAsync(id).finally(() => {

    }).subscribe((result) => {
      this.planProject = result;

      this.active = true;
      this.modal.show();
    });
  }

  close(): void {
    this.active = false;
    this.modal.hide();
  }

  save(): void {
    this.saving = true;
    this.planProject_edit.planProject = this.planProject;
    this._planProjectService.createOrUpdatePlanProject(this.planProject_edit).finally(() => {
      this.saving = false;
    }).subscribe(() => {
      this.notify.info(this.l('SavedSuccessfully'));
      this.close();
      this.modalSave.emit(null);
    })
  }
}
