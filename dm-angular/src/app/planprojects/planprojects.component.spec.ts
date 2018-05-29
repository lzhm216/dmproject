import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanprojectsComponent } from './planprojects.component';

describe('PlanprojectsComponent', () => {
  let component: PlanprojectsComponent;
  let fixture: ComponentFixture<PlanprojectsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlanprojectsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanprojectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
