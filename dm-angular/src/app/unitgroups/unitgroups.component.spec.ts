import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UnitgroupsComponent } from './unitgroups.component';

describe('UnitgroupsComponent', () => {
  let component: UnitgroupsComponent;
  let fixture: ComponentFixture<UnitgroupsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UnitgroupsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UnitgroupsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
