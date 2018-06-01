import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPlanprojectComponent } from './edit-planproject.component';

describe('EditPlanprojectComponent', () => {
  let component: EditPlanprojectComponent;
  let fixture: ComponentFixture<EditPlanprojectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditPlanprojectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditPlanprojectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
