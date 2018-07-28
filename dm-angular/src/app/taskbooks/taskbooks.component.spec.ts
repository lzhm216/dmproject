import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskbooksComponent } from './taskbooks.component';

describe('TaskbooksComponent', () => {
  let component: TaskbooksComponent;
  let fixture: ComponentFixture<TaskbooksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaskbooksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskbooksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
