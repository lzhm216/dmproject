import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanAttachmentComponent } from './plan-attachment.component';

describe('PlanAttachmentComponent', () => {
  let component: PlanAttachmentComponent;
  let fixture: ComponentFixture<PlanAttachmentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlanAttachmentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanAttachmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
