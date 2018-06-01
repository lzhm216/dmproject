import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjecttypesComponent } from './projecttypes.component';

describe('ProjecttypesComponent', () => {
  let component: ProjecttypesComponent;
  let fixture: ComponentFixture<ProjecttypesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjecttypesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjecttypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
