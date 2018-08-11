import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { TaskBookListDto, TaskBookServiceProxy, PagedResultDtoOfTaskBookListDto, TaskBookEditDto } from '@shared/service-proxies/service-proxies';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { EditTaskbookComponent } from '@app/taskbooks/edit-taskbook/edit-taskbook.component';
import { DetailTaskbookComponent } from '@app/taskbooks/detail-taskbook/detail-taskbook.component';
import { AddTaskbookComponent } from '@app/taskbooks/add-taskbook/add-taskbook.component';

@Component({
  selector: 'app-taskbooks',
  templateUrl: './taskbooks.component.html',
  animations: [appModuleAnimation()]
})
export class TaskbooksComponent extends PagedListingComponentBase<TaskBookListDto> implements OnInit {

  @ViewChild('addTaskBookModal') addTaskBookModal: AddTaskbookComponent;
  @ViewChild('editTaskBookModal') editTaskBookModal: EditTaskbookComponent;
  @ViewChild('detailTaskBookModal') detailTaskBookModal: DetailTaskbookComponent;

  filter: string = '';
  taskbooks: TaskBookListDto[] = [];
  cost: any[] = [];
  constructor(
    injector: Injector,
    private _taskBookService: TaskBookServiceProxy
  ) {
    super(injector);
  }

  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    this._taskBookService.getPagedTaskBooks(this.filter, 'Id', request.maxResultCount, request.skipCount).finally(() => {
      // $('#line_chart').html('');
      // ((window as any).Morris).Line({
      //   element: 'line_chart',
      //   data: this.cost,
      //   xkey: 'year',
      //   ykeys: ['value'],
      //   labels: ['计划总成本'],
      //   yLabelFormat: function (y) { return y.toString() + '万元'; }
      // });
      finishedCallback();
    }).subscribe((result: PagedResultDtoOfTaskBookListDto) => {

      this.taskbooks = result.items;
      this.cost = [];
      this.taskbooks.forEach(taskbook => {
        this.cost.push({ year: taskbook.year, value: taskbook.funds });
      });

      this.showPaging(result, pageNumber);
    })
  }

  protected delete(entity: TaskBookListDto): void {
    abp.message.confirm(
      "是否删除测绘任务书 '" + entity.taskName + "'?",
      (result: boolean) => {
        if (result) {
          this._taskBookService.deleteTaskBook(entity.id)
            .subscribe(() => {
              abp.notify.info("测绘任务书: " + entity.taskName + "已删除");
              this.refresh();
            });
        }
      }
    );
  }

  createTaskbook(): void {
    this.addTaskBookModal.show();
  }

  edit(entity: TaskBookEditDto): void {
    this.editTaskBookModal.show(entity.id);
  }

  detail(entity: TaskBookListDto): void {
    this.detailTaskBookModal.show(entity.id);
  }

}
