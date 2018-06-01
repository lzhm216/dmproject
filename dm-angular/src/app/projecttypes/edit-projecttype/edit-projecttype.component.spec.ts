import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditProjecttypeComponent } from './edit-projecttype.component';

describe('EditProjecttypeComponent', () => {
  let component: EditProjecttypeComponent;
  let fixture: ComponentFixture<EditProjecttypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditProjecttypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditProjecttypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
