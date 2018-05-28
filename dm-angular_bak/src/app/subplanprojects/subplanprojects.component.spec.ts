import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SubplanprojectsComponent } from './subplanprojects.component';

describe('SubplanprojectsComponent', () => {
  let component: SubplanprojectsComponent;
  let fixture: ComponentFixture<SubplanprojectsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubplanprojectsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubplanprojectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
