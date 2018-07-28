import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditTaskbookComponent } from './edit-taskbook.component';

describe('EditTaskbookComponent', () => {
  let component: EditTaskbookComponent;
  let fixture: ComponentFixture<EditTaskbookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditTaskbookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditTaskbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
