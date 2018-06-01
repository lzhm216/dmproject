import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePlanprojectComponent } from './create-planproject.component';

describe('CreatePlanprojectComponent', () => {
  let component: CreatePlanprojectComponent;
  let fixture: ComponentFixture<CreatePlanprojectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatePlanprojectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatePlanprojectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
