import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditUnitgroupsComponent } from './edit-unitgroups.component';

describe('EditUnitgroupsComponent', () => {
  let component: EditUnitgroupsComponent;
  let fixture: ComponentFixture<EditUnitgroupsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditUnitgroupsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditUnitgroupsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
