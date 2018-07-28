import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateUnitgroupsComponent } from './create-unitgroups.component';

describe('CreateUnitgroupsComponent', () => {
  let component: CreateUnitgroupsComponent;
  let fixture: ComponentFixture<CreateUnitgroupsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateUnitgroupsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateUnitgroupsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
