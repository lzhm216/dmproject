import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTaskbookComponent } from './add-taskbook.component';

describe('AddTaskbookComponent', () => {
  let component: AddTaskbookComponent;
  let fixture: ComponentFixture<AddTaskbookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddTaskbookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddTaskbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
